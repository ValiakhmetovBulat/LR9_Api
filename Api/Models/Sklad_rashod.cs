using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_rashod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int nom_rash { get; set; }
        public DateTime date_rash { get; set; }
        public DateTime? date_otgruzki { get; set; }
        public DateTime date_sozdania { get; set; }
        public int userID { get; set; }
        public string? prim { get; set; }
        public int? shetID { get; set; }
        public bool otgruzheno { get; set; }
        public bool oplacheno { get; set; }
        public string? phone_customer { get; set; }
        public string? name_customer { get; set; }
        public int type_oplatyID { get; set; }
        public DateTime? date_oplaty { get; set; }

        public double SummaAll
        {
            get { return Sklad_rashod_tov != null ? Sklad_rashod_tov.Sum(p => Math.Ceiling(p.Summa)) : 0; }
        }
        public virtual ICollection<Sklad_rashod_prods>? Sklad_rashod_tov { get; set; }
        public virtual ICollection<Sklad_dostavki>? Sklad_dostavki { get; set; }

        [ForeignKey("shetID")]
        public virtual Shet? Shet { get; set; }

        [ForeignKey("type_oplatyID")]
        public virtual Type_oplaty? Spr_oplat_sklad { get; set; }
        [ForeignKey("userID")]
        public virtual User? Polz { get; set; }
    }
}
