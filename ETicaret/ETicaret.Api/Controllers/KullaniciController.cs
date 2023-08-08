using ETicaret.Model;
using ETicaret.Model.View;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {
        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {

        }
        [HttpPost("Getir")]
        public dynamic Getir([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string kullaniciAd = json.KullaniciAdi;
            string sifre = json.Sifre;

            Kullanici item = repo.KullaniciRepository.FindByCondition(k => k.KullaniciAdi == kullaniciAd && k.Sifre == sifre).SingleOrDefault<Kullanici>();
            if (item != null)
            {
                return new
                {
                    success = true,
                    data = item
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "kullanici adı veya şifre hatalı "
                };
            }
        }

        //view için
        [HttpGet("AktifKullanicilar")]
        public dynamic AktifKullanicilar()
        {
            List<V_AktifKullanicilar> items = repo.KullaniciRepository.AktifKullanicilariGetir();
            return new
            {
                success = true,
                data = items
            };
        }

    }
}
