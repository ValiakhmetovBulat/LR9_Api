using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Karta
    {
        [Key]
        public decimal kod_zap { get; set; }
        public string name { get; set; }
    }
}
