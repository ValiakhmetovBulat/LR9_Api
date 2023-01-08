using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_rashod_tov
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kod_zap { get; set; }
        public Nullable<int> kod_rashoda { get; set; }
        public Nullable<int> kod_tovara { get; set; } 
        public Nullable<int> count { get; set; }
        //public Nullable<decimal> count_pachek { get; set; }
        public Nullable<double> nom_prih { get; set; }
        public Nullable<double> zena { get; set; }
        public Nullable<double> pribyl { get; set; }
        /*public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> volume { get; set; }*/
        public double Summa
        {
            get { return (double)((count != null ? count : 0) * (zena != null ? zena : 0)); }
        }
        //public Nullable<decimal> ploshad { get; set; }
        [ForeignKey("kod_rashoda")]
        public virtual Sklad_rashod? Sklad_rashod { get; set; }

        [ForeignKey("kod_tovara")]
        public virtual Tovary? Tovar { get; set; }
    }
}
