using ETicaret.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class UrunRepository : RepositoryBase<Urun>
    {
        public UrunRepository(RepositoryContext context) : base(context)
        {

        }
        public List<Urun> UrunleriGetirByKategoriId(int kategoriId)
        {
            List<Urun> items = (from u in RepositoryContext.Urunler
                                join k in RepositoryContext.UrunKategori on u.Id equals k.UrunId
                                where k.KategoriId == kategoriId
                                select u).ToList<Urun>();
            return items;
        }

    }
}
