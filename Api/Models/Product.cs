using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
        }
        [Key]
        public int ID { get; set; }
        public string naim { get; set; }
        public double dlina { get; set; }
        public double shir { get; set; }
        public double tol { get; set; }
        public string? nazn { get; set; }
        public string? sort { get; set; }
        public string? dekor { get; set; }
        public string? zvet { get; set; }
        public string? material { get; set; }
        public int? manufID { get; set; }
        public double ves_lista { get; set; }
        public int kol_list_v_pachke { get; set; }
        public int categoryID { get; set; }

        public bool IsEquals(Product t)
        {
            if (t == null) return false;
            if (this == t) return true;
            if (object.ReferenceEquals(this, t)) return true;
            if (t.naim == this.naim && t.sort == this.sort && t.dlina == this.dlina && t.shir == this.shir && t.tol == this.tol/*КАТЕГОРИЯ*/) return true;
            return false;
        }

        [ForeignKey("categoryID")]
        public Category? Category { get; set; } 

    }
}
