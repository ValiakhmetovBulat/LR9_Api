using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Sklad_prihod
    {
        public Sklad_prihod()
        {
            this.Sklad_prihod_tov = new HashSet<Sklad_prihod_tov>();
        }
        [Key]
        public int kod_zap { get; set; }
        public DateTime date_prih { get; set; }
        public int id_polz { get; set; }
        public string? prim { get; set; }
        public int nom_prih { get; set; }
        public Nullable<int> kod_poluch { get; set; }
        //public string oplata_dost { get; set; }
        public Nullable<bool> transport_ot_post { get; set; }
        public Nullable<bool> is_corrected { get; set; }
        public bool is_in_sklad { get; set; }
        //public Nullable<bool> is_tr_opl { get; set; }
        public Nullable<int> kod_perevoz { get; set; }
        public Nullable<int> kod_shet { get; set; }
        public Nullable<double> dop_rash { get; set; }
        public Nullable<double> cost_dost { get; set; }
        public virtual ICollection<Sklad_prihod_tov> Sklad_prihod_tov { get; set; }
        [ForeignKey("id_polz")]
        public virtual User? Polz { get; set; }
    }
}
