using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Shet_prods
    {
        [Key]
        public int ID { get; set; }
        public int shetID { get; set; }
        public int productID { get; set; }
        public double count { get; set; }
        public double price { get; set; }
        [ForeignKey("shetID")]
        public virtual Shet? Sheta { get; set; }
        [ForeignKey("productID")]
        public virtual Product? Tovar { get; set; }
    }
}
