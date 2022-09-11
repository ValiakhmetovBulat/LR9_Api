using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Spr_oplat_sklad
    {
        [Key]
        public decimal kod_zap { get; set; }
        public string naim { get; set; }
    }
}
