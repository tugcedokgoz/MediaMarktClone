using ETicaret.Model;
using ETicaret.Model.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    //veritabanı işlemlerini yapan sınıf
    public class RepositoryContext : DbContext //entityFramework ekle
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;//ilişkisel kayıtların sürekli getirilmesini engelleyen ayardır.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//modeller oluşturulurken kurallar oluşturulur.
        {
            modelBuilder.Entity<V_AktifKullanicilar>().HasNoKey();
            modelBuilder.Entity<Kullanici>().Property(d => d.KayitTarih).HasDefaultValue();

        }

        //classları burada tanımlanır/ Dependencies referenca ekle model
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<KategoriAnaSayfa> AnaSayfaKategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunKategori> UrunKategori { get; set; }

        public DbSet<V_AktifKullanicilar> AktifKullanicilar { get; set; }

    }
}
