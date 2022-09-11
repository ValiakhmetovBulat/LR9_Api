using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Spr_period_filtr
    {
        [Key]
        public decimal kod_zap { get; set; }
        public string naim { get; set; }
        public int day { get; set; }
    }
}
