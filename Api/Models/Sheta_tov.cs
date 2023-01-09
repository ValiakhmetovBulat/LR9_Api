using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sheta_tov
    {
        [Key]
        public int kod_zap { get; set; }
        public int kod_sheta { get; set; }
        public int kod_tovara { get; set; }
        public double kol { get; set; }
        public Nullable<double> zena { get; set; }
        public Nullable<double> summa { get; set; }
        public Nullable<double> summa_nds { get; set; }
        [ForeignKey("kod_sheta")]
        public virtual Shet? Sheta { get; set; }
        [ForeignKey("kod_tovara")]
        public virtual Tovary? Tovar { get; set; }
    }
}
