using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class veritabaniyonetimsistemleriContext : DbContext
{
    public veritabaniyonetimsistemleriContext()
    {
    }

    public veritabaniyonetimsistemleriContext(DbContextOptions<veritabaniyonetimsistemleriContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Biletler> Biletlers { get; set; }

    public virtual DbSet<Calisanlar> Calisanlars { get; set; }

    public virtual DbSet<HavaAlaniAracKiralama> HavaAlaniAracKiralamas { get; set; }

    public virtual DbSet<HavaAlaniOtopark> HavaAlaniOtoparks { get; set; }

    public virtual DbSet<HavaAlanlari> HavaAlanlaris { get; set; }

    public virtual DbSet<HavayollariFirmalari> HavayollariFirmalaris { get; set; }

    public virtual DbSet<OtelKonaklama> OtelKonaklamas { get; set; }

    public virtual DbSet<Ucuslar> Ucuslars { get; set; }

    public virtual DbSet<TempZaman> TempZamans { get; set; }

    public virtual DbSet<UcusNo_> UcusNos { get; set; }

    public virtual DbSet<Yolcular> Yolculars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=veritabani yonetim sistemleri; Trusted_Connection=True;TrustServerCertificate=True; MultipleActiveResultSets=true");

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Biletler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Biletler__3214EC27FFDFF5DF");

            entity.ToTable("Biletler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fiyat).HasColumnType("money");
            entity.Property(e => e.SinifKoltuk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Sinif_Koltuk");
            entity.Property(e => e.UcusNumarasi).HasColumnName("Ucus_Numarasi");
            entity.Property(e => e.UcusSirketi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ucus_Sirketi");
            entity.Property(e => e.YolcuAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yolcu_Adi");
        });

        modelBuilder.Entity<Calisanlar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Calisanl__3214EC27512F4751");

            entity.ToTable("Calisanlar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CalisanAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Calisan_Adi");
            entity.Property(e => e.CalisanSoyad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Calisan_Soyad");
            entity.Property(e => e.CalistigiFirma)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Calistigi_Firma");
            entity.Property(e => e.EPosta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E-posta");
            entity.Property(e => e.IseGirisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Ise_Giris_Tarihi");
            entity.Property(e => e.Maas).HasColumnType("money");
            entity.Property(e => e.Meslek)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefon).HasMaxLength(50);
        });

        modelBuilder.Entity<HavaAlaniAracKiralama>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HavaAlan__3214EC2780592BEF");

            entity.ToTable("HavaAlani_Arac_Kiralama");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AracKiralamaFirmasiAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Arac_Kiralama_Firmasi_Adi");
            entity.Property(e => e.OdemeTutari)
                .HasColumnType("money")
                .HasColumnName("Odeme_Tutari");
            entity.Property(e => e.TeslimAlinacakKonum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Teslim_Alinacak_Konum");
            entity.Property(e => e.TeslimAlmaTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Teslim_Alma_Tarihi");
            entity.Property(e => e.TeslimEtmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Teslim_Etme_Tarihi");
        });

        modelBuilder.Entity<HavaAlaniOtopark>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HavaAlani_Otopark");

            entity.Property(e => e.AracCikisSaati).HasColumnName("Arac_Cikis_Saati");
            entity.Property(e => e.AracCikisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Arac_Cikis_Tarihi");
            entity.Property(e => e.AracGirisSaat).HasColumnName("Arac_Giris_Saat");
            entity.Property(e => e.AracGirisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Arac_Giris_Tarihi");
            entity.Property(e => e.AracTipi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Arac_Tipi");
            entity.Property(e => e.Fiyat).HasColumnType("money");
        });

        modelBuilder.Entity<HavaAlanlari>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__HavaAlan__3214EC27E92FB9C2");

            entity.ToTable("HavaAlanlari");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.HavaalaniAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Havaalani_Adi");
            entity.Property(e => e.Varis)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Tip1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Tip2)
               .HasMaxLength(4)
               .IsUnicode(false);
        });

        modelBuilder.Entity<HavayollariFirmalari>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Havayoll__3214EC27DB348B21");

            entity.ToTable("Havayollari_Firmalari");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FaaliyeteGecmeTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Faaliyete_Gecme_Tarihi");
            entity.Property(e => e.FirmaAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Firma_Adi");
            entity.Property(e => e.Sehir)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ulke)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OtelKonaklama>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Otel_Kon__3214EC27BA7CBF46");

            entity.ToTable("Otel_Konaklama");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CikisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Cikis_Tarihi");
            entity.Property(e => e.CocukSayisi).HasColumnName("Cocuk_Sayisi");
            entity.Property(e => e.GirisTarihi)
                .HasColumnType("datetime")
                .HasColumnName("Giris_Tarihi");
            entity.Property(e => e.OdaSayisi).HasColumnName("Oda_Sayisi");
            entity.Property(e => e.YetiskinSayisi).HasColumnName("Yetiskin_Sayisi");
        });

        modelBuilder.Entity<Ucuslar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ucuslar__3214EC273DC488AC");

            entity.ToTable("Ucuslar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HavaAlaniAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HavaAlani_Adi");
            entity.Property(e => e.HavaAlaniVaris)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HavaAlani_Varis");
            entity.Property(e => e.HavaYoluSirketi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KalkisSaati)
                .HasColumnType("datetime")
                .HasColumnName("Kalkis_Saati");
            entity.Property(e => e.Tarih).HasColumnType("datetime");
            entity.Property(e => e.UcusNo).HasMaxLength(50);
            entity.Property(e => e.VarisSaati)
                .HasColumnType("datetime")
                .HasColumnName("Varis_Saati");
        });

        modelBuilder.Entity<Yolcular>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Yolcular__3214EC273B957653");

            entity.ToTable("Yolcular");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adres).IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ulke)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YolcuAd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yolcu_Ad");
            entity.Property(e => e.YolcuSoyad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yolcu_Soyad");
        });


        modelBuilder.Entity<TempZaman>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_temp_zaman");
            entity.ToTable("temp_zaman");

            entity.Property(e => e.id);
            entity.Property(e => e.zaman);

        });

        modelBuilder.Entity<UcusNo_>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_UcusNo");
            entity.ToTable("UcusNo");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.UcusNo)
            .HasMaxLength(50)
            .IsUnicode(false);

            entity.Property(e => e.Tip);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

