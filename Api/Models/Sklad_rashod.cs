using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_rashod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? kod_zap { get; set; }
        public Nullable<System.DateTime> data_rash { get; set; }
        public Nullable<int> org { get; set; }
        public Nullable<int> oplata { get; set; }
        public string? otpustil { get; set; }
        public string? prim { get; set; }
        public Nullable<int> nom_rash { get; set; }
        public Nullable<int> shet { get; set; }
        public Nullable<bool> otgruzheno { get; set; }
        public Nullable<decimal> summa { get; set; }
        public string? name_pokup { get; set; }
        public string? phone_pokup { get; set; }
        public Nullable<bool> sdano { get; set; }
        public Nullable<decimal> summa_beznal { get; set; }
        public Nullable<decimal> summa_karta { get; set; }
        public Nullable<bool> На_производство { get; set; }
        public Nullable<bool> opl_pok_karta { get; set; }
        public Nullable<bool> opl_pok_nal { get; set; }
        public Nullable<bool> opl_voditel { get; set; }
        public Nullable<bool> isTovOpl { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> volume { get; set; }
        public Nullable<bool> isChecked { get; set; }
        public Nullable<int> karta { get; set; }
        public string? prim_buh { get; set; }
        public Nullable<System.DateTime> data_opl { get; set; }
        public Nullable<decimal> dolg { get; set; }
        public Nullable<bool> IsInvent { get; set; }
        public Nullable<bool> isNotInProdazhiHistory { get; set; }
        public Nullable<System.DateTime> data_otgruzki { get; set; }
        public Nullable<System.DateTime> data_sozdania { get; set; }
        public Nullable<System.DateTime> opl_pok_data { get; set; }
        public string? primZavSklad { get; set; }
        public Nullable<decimal> nom_inv { get; set; }
        public Nullable<decimal> region { get; set; }
        public string? second_phone { get; set; }
        public string? first_phone { get; set; }
        public string? name_kontact_person { get; set; }
        public string? last_polz { get; set; }
        public string? last_machiname { get; set; }
        public string? last_changes_date { get; set; }
        public Nullable<bool> Na_Pechat_Dost { get; set; }
        public Nullable<decimal> skidka { get; set; }
        public decimal SummaAll
        {
            get { return Sklad_rashod_tov != null ? Sklad_rashod_tov.Sum(p=> oplata != 2 ? Math.Ceiling(p.Summa) : p.Summa) : 0; }
        }
        public int CountDost { get { return Sklad_dostavki != null ? Sklad_dostavki.Count() : 0; } }
        public decimal SummaDost { get { return Sklad_dostavki != null ? Sklad_dostavki.Select(p => p.summa).Sum() : 0; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sklad_rashod_tov>? Sklad_rashod_tov { get; set; }
        public virtual ICollection<Sklad_dostavki>? Sklad_dostavki { get; set; }

        [ForeignKey("shet")]
        public virtual Sheta? Sheta { get; set; }

        [ForeignKey("oplata")]
        public virtual Spr_oplat_sklad? Spr_oplat_sklad { get; set; }

        [ForeignKey("karta")]
        public virtual Karta? Kart { get; set; }
    }
}
