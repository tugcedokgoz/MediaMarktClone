using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model
{
    [Table("tblUrunKategori")]
    public class UrunKategori
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int KategoriId { get; set; }
    }
}
