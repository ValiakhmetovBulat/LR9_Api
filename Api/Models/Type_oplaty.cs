using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Type_oplaty
    {
        [Key]
        public int ID { get; set; }
        public string naim { get; set; }
    }
}
