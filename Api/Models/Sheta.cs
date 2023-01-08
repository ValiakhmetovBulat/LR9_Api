using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public partial class Sheta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sheta()
        {
            /*this.Sklad_dostavki = new HashSet<Sklad_dostavki>();
            this.Sheta_tov = new HashSet<Sheta_tov>();*/
            //this.Sklad_rashod = new HashSet<Sklad_rashod>();
        }
        [Key]
        public int kod_zap { get; set; }
        public int nom { get; set; }
        public System.DateTime date_sheta { get; set; }
        public int pok { get; set; }
        public Nullable<double> summa { get; set; }
        public int id_polz { get; set; }
        public string prim { get; set; }
        public bool korr { get; set; }
        public bool oplachen { get; set; }
        public bool sklad { get; set; }
        public bool prim_is_plat { get; set; }
        public Nullable<System.DateTime> date_oplaty { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Sklad_dostavki> Sklad_dostavki { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Sheta_tov> Sheta_tov { get; set; }
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sklad_rashod> Sklad_rashod { get; set; }*/
    }
}
