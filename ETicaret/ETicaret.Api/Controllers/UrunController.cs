using ETicaret.Model;
using ETicaret.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace ETicaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : BaseController
    {
        public UrunController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            
        }
        [HttpGet("api/{kategoriId}")]
        public dynamic Urunler(int kategoriId)
        {
            List<Urun> items = repo.UrunRepository.UrunleriGetirByKategoriId(kategoriId);
            return new
            {
                success = true,
                data = items
            };
        }

    }
}
