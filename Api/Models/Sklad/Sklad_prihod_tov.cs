using System.ComponentModel.DataAnnotations;

namespace Api.Models.Sklad
{
    public partial class Sklad_prihod_tov
    {
        [Key]
        public decimal kod_zap { get; set; }
        public Nullable<decimal> kod_prihoda { get; set; }
        public Nullable<decimal> kod_tov { get; set; }
        public Nullable<decimal> count { get; set; }
        public Nullable<System.DateTime> data_proizv { get; set; }
        public Nullable<decimal> Цена { get; set; }
        public Nullable<decimal> Цена_с_доставкой { get; set; }
        public Nullable<decimal> Стоимость { get; set; }
        public decimal? Стоимость_с_доставкой { get; set; }

        public virtual Sklad_prihod Sklad_prihod { get; set; }
    }
}
