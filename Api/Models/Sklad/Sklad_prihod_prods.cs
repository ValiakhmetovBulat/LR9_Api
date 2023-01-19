using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Sklad_prihod_prods
    {
        [Key]
        public int ID { get; set; }
        public int prihodID { get; set; }
        public int productID { get; set; }
        public int count { get; set; }
        public double price { get; set; }
        public double price_with_deliv { get; set; }
        
        [ForeignKey("prihodID")]
        public virtual Sklad_prihod? Sklad_prihod { get; set; }
        [ForeignKey("productID")]
        public virtual Product? Tovar { get; set; }
    }
}
