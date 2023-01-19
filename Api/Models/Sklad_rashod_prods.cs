using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_rashod_prods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int rashodID { get; set; }
        public int productID { get; set; } 
        public int count { get; set; }
        public double price { get; set; }
        public double Summa
        {
            get { return count * price; }
        }
        [ForeignKey("rashodID")]
        public virtual Sklad_rashod? Sklad_rashod { get; set; }

        [ForeignKey("productID")]
        public virtual Product? Tovar { get; set; }
    }
}
