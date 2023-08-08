using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Model
{
    [Table("tblKategori")]  //tablonun ismini verdim
    public class Kategori
    {
        public Kategori()
        {
            AltKategoriler=new HashSet<Kategori>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public int? UstKategoriId { get; set; }

        public int Sira{ get; set; }
        public string? Foto{ get; set; }
        public bool Aktif{ get; set; }

        public virtual Kategori? UstKategori { get; set; }  //kategorinin bir üst kategorisi olabilir oda null olabilir
        public virtual ICollection<Kategori> AltKategoriler { get; set; } // bu kategorinin birden fazla alt kategorisi olabilir.
    }
}