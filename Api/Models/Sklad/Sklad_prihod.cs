using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Sklad_prihod
    {
        public Sklad_prihod()
        {
            this.Sklad_prihod_tov = new HashSet<Sklad_prihod_prods>();
        }
        [Key]
        public int ID { get; set; }
        public int nom_prih { get; set; }
        public DateTime date_prih { get; set; }
        public Nullable<int> contractorID { get; set; }
        public Nullable<bool> transport_ot_post { get; set; }
        public int userID { get; set; }
        public Nullable<bool> is_korr { get; set; }
        public bool is_in_sklad { get; set; }
        public Nullable<double> deliv_cost { get; set; }
        public Nullable<double> dop_rash { get; set; }
        public string? prim { get; set; }
        public virtual ICollection<Sklad_prihod_prods> Sklad_prihod_tov { get; set; }
        [ForeignKey("userID")]
        public virtual User? Polz { get; set; }
        [ForeignKey("contractorID")]
        public virtual Contractor? Contractor { get; set; }
    }
}
