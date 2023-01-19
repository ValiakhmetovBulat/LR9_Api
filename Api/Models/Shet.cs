using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class Shet
    {
        public Shet()
        {
            this.Sheta_tov = new HashSet<Shet_prods>();
        }
        [Key]
        public int ID { get; set; }
        public int nom_shet { get; set; }
        public System.DateTime date_sheta { get; set; }
        public int? contractorID { get; set; }
        public int userID { get; set; }
        public string? prim { get; set; }
        public bool is_korr { get; set; }
        public bool oplachen { get; set; }
        public Nullable<System.DateTime> date_oplaty { get; set; }
        public virtual ICollection<Shet_prods> Sheta_tov { get; set; }

        [ForeignKey("contractorID")]
        public virtual Contractor? Contractor { get; set; }
        [ForeignKey("userID")]
        public virtual User? Polz { get; set; }
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sklad_rashod> Sklad_rashod { get; set; }*/
    }
}
