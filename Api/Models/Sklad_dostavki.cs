using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_dostavki
    {
        [Key]
        public int id { get; set; }
        public int sklad_rashod_id { get; set; }
        public string? address { get; set; }
        public double summa { get; set; }
        public int tip_opl_id { get; set; }
        public bool opl_klientom { get; set; }
        public Nullable<System.DateTime> data_opl_klientom { get; set; }
        public bool opl_voditelu { get; set; }
        public string? prim { get; set; }
        public bool provereno { get; set; }
        public Nullable<int> karta_id { get; set; }
        public Nullable<int> perevoz_id { get; set; }
        public Nullable<int> voditel_id { get; set; }
        public Nullable<bool> opl_na_vigruz { get; set; }
        public Nullable<int> shet { get; set; }
        public Nullable<System.DateTime> data_rash { get; set; }
        public Nullable<decimal> platel { get; set; }
        public string? otpustil { get; set; }

        /*
        public virtual Perevozy Perevozy { get; set; }*/
        /*public virtual Sklad_voditely Sklad_voditely { get; set; }*/

        [ForeignKey("shet")]
        public virtual Shet? Sheta { get; set; }

        [ForeignKey("sklad_rashod_id")]
        public virtual Sklad_rashod? Sklad_rashod { get; set; }

        [ForeignKey("tip_opl_id")]
        public virtual Type_oplaty? Spr_oplat_sklad { get; set; }

        [ForeignKey("karta_id")]
        public virtual Karta? Karta { get; set; }
    }
}
