using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_rashod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kod_zap { get; set; }
        public int nom_rash { get; set; }
        public int oplata { get; set; }
        public DateTime date_rash { get; set; }
        public DateTime? date_otgruzki { get; set; }
        public DateTime? date_sozdania { get; set; }
        public DateTime? date_raspila { get; set; }
        public DateTime? date_opl { get; set; }
        public int id_polz { get; set; }
        public string? prim { get; set; }
        public string? prim_zav_sklad { get; set; }
        public string? prim_buh { get; set; }
        public int? shet { get; set; }
        public bool otgruzheno { get; set; }
        public double? summa_nal { get; set; }
        public double? summa_beznal { get; set; }
        public double? summa_karta { get; set; }
        public double? dolg { get; set; }
        public bool? sdano { get; set; }
        public double? weight { get; set; }
        public double? volume { get; set; }
        public bool? is_invent { get; set; }
        public bool? isnt_in_prodazhi_history { get; set; }
        public string? first_phone { get; set; }
        public string? name_pokup { get; set; }
        public string? name_kontact_person { get; set; }
        public string? second_phone { get; set; }
        public bool? na_raspile { get; set; }
        public bool? na_pechat_dost { get; set; }
        public bool? raspileno { get; set; }
        public bool is_tov_opl { get; set; }
        public double SummaAll
        {
            get { return Sklad_rashod_tov != null ? Sklad_rashod_tov.Sum(p => Math.Ceiling(p.Summa)) : 0; }
        }
        public int CountDost { get { return Sklad_dostavki != null ? Sklad_dostavki.Count() : 0; } }
        public double SummaDost { get { return Sklad_dostavki != null ? Sklad_dostavki.Select(p => p.summa).Sum() : 0; } }

        public virtual ICollection<Sklad_rashod_tov>? Sklad_rashod_tov { get; set; }
        public virtual ICollection<Sklad_dostavki>? Sklad_dostavki { get; set; }

        /*[ForeignKey("shet")]
        public virtual Sheta? Sheta { get; set; }*/

        [ForeignKey("oplata")]
        public virtual Spr_oplat_sklad? Spr_oplat_sklad { get; set; }
        [ForeignKey("id_polz")]
        public virtual User? Polz { get; set; }
    }
}
