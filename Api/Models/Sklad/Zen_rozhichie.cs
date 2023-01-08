using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Zen
    {
        [Key]
        public int tov { get; set; }
        public Nullable<double> zena_ot_lista_bnal { get; set; }
        public Nullable<double> zena_ot_pachki_bnal { get; set; }
        public Nullable<double> zena_ot_4x_pachek_bnal { get; set; }
        public Nullable<double> zena_ot_lista_nal { get; set; }
        public Nullable<double> zena_ot_pachki_nal { get; set; }
        public Nullable<double> zena_ot_4x_pachek_nal { get; set; }
        
        [ForeignKey("tov")]
        public virtual Tovary? Tovar { get; set; }
    }
}
