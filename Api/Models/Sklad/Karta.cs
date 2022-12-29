using System.ComponentModel.DataAnnotations;

namespace Api.Models.Sklad
{
    public class Karta
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
    }
}
