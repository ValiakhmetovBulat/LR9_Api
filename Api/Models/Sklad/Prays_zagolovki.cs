using System.ComponentModel.DataAnnotations;

namespace Api.Models.Sklad
{
    public partial class Prays_zagolovki
    {
        [Key]
        public decimal kod_zap { get; set; }
        public string? zagolovok { get; set; }
        public Nullable<decimal> nomer { get; set; }
        public Nullable<decimal> zena_kod { get; set; }
        public bool? розница { get; set; }
        public int? Skidka_ot { get; set; }
        public int? number1 { get; set; }
        public int? number2 { get; set; }
        public string? image { get; set; }
    }
}
