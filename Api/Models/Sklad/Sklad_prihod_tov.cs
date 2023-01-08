using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Sklad_prihod_tov
    {
        [Key]
        public int kod_zap { get; set; }
        public Nullable<int> kod_prihoda { get; set; }
        public Nullable<int> kod_tovara { get; set; }
        public Nullable<int> count { get; set; }
        public Nullable<double> zena { get; set; }
        public Nullable<double> zena_with_dost { get; set; }
        /*        public Nullable<decimal> cost { get; set; }
                public decimal? Стоимость_с_доставкой { get; set; }*/
        [ForeignKey("kod_prihoda")]
        public virtual Sklad_prihod? Sklad_prihod { get; set; }
        [ForeignKey("kod_tovara")]
        public virtual Tovary? Tovar { get; set; }
    }
}
