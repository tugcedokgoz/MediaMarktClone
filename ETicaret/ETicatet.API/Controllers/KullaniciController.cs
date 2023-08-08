using ETicaret.Api.Code.Validations;
using ETicaret.Model;
using ETicaret.Model.View;
using ETicaret.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System;

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
       [Authorize(Roles ="Admin")]
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

        //üyeol
        [HttpPost("UyeOl")]
        public dynamic UyeOl([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string kullaniciAd = json.KullaniciAdi;
            string sifre = json.Sifre;

            Kullanici item = new Kullanici()
            {
                Aktif = true,
                KullaniciAdi = kullaniciAd,
                Sifre = sifre,
                RolId = Enums.Roller.Kullanici
            };
            Kullanici? kullanici = repo.KullaniciRepository.FindByCondition(k => k.KullaniciAdi == item.KullaniciAdi).SingleOrDefault<Kullanici>();
            if (kullanici != null)
            {
                return new
                {
                    success = false,
                    message = "Bu kullanıcı adı zaten kullanılıyor"
                };
            }

            KullaniciValidator validator = new KullaniciValidator();
            validator.ValidateAndThrow(item);

            repo.KullaniciRepository.Create(item);
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }



    }
}
