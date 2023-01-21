using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    [Keyless]
    public partial class Product_stock
    {
        public int kod_tovara { get; set; }
        public int total_stock { get; set; }
        public int rezerved_stock { get; set; }
        public int coming_stock { get; set; }

        [ForeignKey("kod_tovara")]
        public virtual Product? Tovar { get; set; }
    }
}
