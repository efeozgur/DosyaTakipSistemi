using System.ComponentModel.DataAnnotations;

namespace DosyaTakipSistemi.Models
{
    public enum TarafTuru
    {
        [Display(Name = "Davacı")]
        Davaci = 0,
        [Display(Name = "Davalı")]
        Davali = 1,

    }
    public class TarafModel
    {
        public int Id { get; set; }
        public TarafTuru TarafTur { get; set; }
        public string AdSoyad { get; set; }
        public int DosyaId { get; set; }
        public bool IstinafTalebi { get; set; }
        public bool TemyizTalebi { get; set; }

        [Required]
        public DateTime TebligTarihi { get; set; }
        public DosyaModel? Dosya { get; set; }



       
    }


}
