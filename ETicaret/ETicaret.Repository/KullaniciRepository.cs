using ETicaret.Model;
using ETicaret.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class KullaniciRepository : RepositoryBase<Kullanici>
    {
        public KullaniciRepository(RepositoryContext context) : base(context)
        {

        }
        public List<V_AktifKullanicilar> AktifKullanicilariGetir()
        {
            return RepositoryContext.AktifKullanicilar.ToList<V_AktifKullanicilar>();
        }
    }
}
