using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.View
{
    [Table("V_AktifKullanicilar")]
    //[PrimaryKey("KullaniciId")]

    public class V_AktifKullanicilar
    {
        public int KullaniciId { get; set; }
        public int RolId { get; set; }
        public string KullaniciAdi  { get; set; }
        public string Ad { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool? EmailOnay { get; set; }
    }
}
