using System.ComponentModel.DataAnnotations;

namespace DosyaTakipSistemi.Models
{
    public class DosyaModel
    {
        public int Id { get; set; }
        public string Mahkeme { get; set; }
        public string EsasNo { get; set; }
        public string KararNo { get; set; }
        public DateTime KararTarihi { get; set; }
        public DateTime KararTebligTarihi { get; set; }
        public bool HarcDurumu { get; set; }
        public KararTuru kararTur { get; set; }

       
        public DateTime HarcYazmaSonTarihi => KararTebligTarihi.AddDays(30);
        public List<TarafModel> Taraflar { get; set; } = new();

        public DateTime KesinlesmeTarihi
        {
            get
            {
                if (kararTur == KararTuru.KesinKarar)
                    return KararTarihi;

                if (kararTur == KararTuru.IstinafaTabi && Taraflar.Any(t => t.IstinafTalebi))
                    return DateTime.MaxValue;

                if (kararTur == KararTuru.TemyizeTabi && Taraflar.Any(t => t.TemyizTalebi))
                    return DateTime.MaxValue;

                var enSonTeblig = (Taraflar != null && Taraflar.Any())
                    ? Taraflar.Max(t => t.TebligTarihi)
                    : KararTebligTarihi;

                return enSonTeblig.AddDays(16);
            }
        }
        public bool TemyizTalebiVar => Taraflar != null && Taraflar.Any(t => t.TemyizTalebi);
        public bool IstinafTalebiVar => Taraflar != null && Taraflar.Any(t => t.IstinafTalebi);
        public bool ItirazVar => TemyizTalebiVar || IstinafTalebiVar;



    }

    public enum KararTuru
    {
        [Display(Name = "Kesin Karar")]
        KesinKarar = 0,
        [Display(Name = "İstinafa Tabi")]
        IstinafaTabi = 1,
        [Display(Name = "Temyize Tabi")]
        TemyizeTabi = 2,
    }

}
