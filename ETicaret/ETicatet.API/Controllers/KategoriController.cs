using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : BaseController
    {
        //kategori için yazdıgımız repository kullanamk için yazıyoruz.

        public KategoriController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {

        }

        //tüm kategorileri getiren 
        [HttpGet("TumKategoriler")]
        public dynamic TumKategoriler()
        {
            // throw new ApplicationException("test hata");

            List<Kategori> items;
            if (!cache.TryGetValue("TumKategoriler", out items))
            {
                items = repo.KategoriRepository.FindAll().ToList<Kategori>();

                cache.Set("TumKategoriler", items, DateTimeOffset.UtcNow.AddSeconds(20));

                cache.Remove("TumKategoriler");
            }

            return new
            {
                sucess = true,
                data = items
            };
        }

        //id ye göre getirme
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            Kategori items = repo.KategoriRepository.FindByCondition(a => a.Id == id).SingleOrDefault<Kategori>();
            return new
            {
                sucess = true,
                data = items
            };
        }
        //en üst kategorielr

        [HttpGet("UstKategoriler")]
        public dynamic UstKategoriler()
        {
            List<Kategori> items = repo.KategoriRepository.FindByCondition(a => a.UstKategoriId == null).ToList<Kategori>();
            return new
            {
                sucess = true,
                data = items
            };
        }

        //alt kategoriler
        [HttpGet("AltKategoriler/{id}")]
        public dynamic AltKategoriler(int id)
        {
            List<Kategori> items = repo.KategoriRepository.FindByCondition(a => a.UstKategoriId == null).ToList<Kategori>();
            return new
            {
                sucess = true,
                data = items
            };
        }

        //anasayfa kategorilerini getirdiğimiz 
        [HttpGet("AnaSayfaKategoriler")]
        public dynamic AnaSayfaKategoriler()
        {
            List<Kategori> items = repo.KategoriRepository.AnaSayfaKategorileriniGetir();
            return new
            {
                sucess = true,
                data = items
            };
        }

        //admin kaydetme/güncelleme
        [Authorize(Roles ="Admin,Personel")]
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kategori item = new Kategori()
            {
                Id = json.Id,
                Ad = json.Ad,
                Aktif = json.Aktif,
                Foto = json.Foto,
                Sira = json.Sira,
                UstKategoriId = json.UstKategoriId
            };
            if (item.Id > 0)
                repo.KategoriRepository.Update(item);
            else
                repo.KategoriRepository.Create(item);
            repo.SaveChanges();
            cache.Remove("TumKategoriler");
            return new
            {
                success = true
            };
        }
    }
}
