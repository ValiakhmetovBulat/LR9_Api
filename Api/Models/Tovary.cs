using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class Tovary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovary()
        {
        }
        [Key]
        public int kod_tovara { get; set; }
        public string naim { get; set; }
        public Nullable<double> dlina { get; set; }
        public Nullable<double> shir { get; set; }
        public Nullable<double> tol { get; set; }
        public string? nazn { get; set; }
        public string? sort { get; set; }
        public string? dekor { get; set; }
        public string? zvet { get; set; }
        public string? material { get; set; }
        public int? proizv { get; set; }
        public string? gor_otgr { get; set; }
        public Nullable<double> ves_lista { get; set; }
        public Nullable<int> kol_list_v_pachke { get; set; }
        public Nullable<int> kol_pachek_v20fut { get; set; }
        public string? klass_emis { get; set; }
        public Nullable<int> kod_normativa { get; set; }
        public Nullable<bool> udal { get; set; }
        public Nullable<int> kod_1C { get; set; }
        public Nullable<int> kod_categ { get; set; }

        public bool IsEquals(Tovary t)
        {
            if (t == null) return false;
            if (this == t) return true;
            if (object.ReferenceEquals(this, t)) return true;
            if (t.naim == this.naim && t.sort == this.sort && t.dlina == this.dlina && t.shir == this.shir && t.tol == this.tol/*КАТЕГОРИЯ*/) return true;
            return false;
        }

        [ForeignKey("kod_categ")]
        public Category? Category { get; set; } 

    }
}
