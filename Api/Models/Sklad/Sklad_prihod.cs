using System.ComponentModel.DataAnnotations;

namespace Api.Models.Sklad
{
    public partial class Sklad_prihod
    {
        public Sklad_prihod()
        {
            this.Sklad_prihod_tov = new HashSet<Sklad_prihod_tov>();
        }
        [Key]
        public decimal kod_zap { get; set; }
        public Nullable<System.DateTime> data_prih { get; set; }
        public Nullable<decimal> org { get; set; }
        public string prinyal { get; set; }
        public string prim { get; set; }
        public Nullable<decimal> nom_prih { get; set; }
        public string nom_naklad { get; set; }
        public Nullable<System.DateTime> data_naklad { get; set; }
        public Nullable<decimal> kod_poluch { get; set; }
        public Nullable<bool> podshit { get; set; }
        public Nullable<decimal> Стоимость_доставки { get; set; }
        public Nullable<bool> Нал_расчет { get; set; }
        public string Способ_оплаты_доставки { get; set; }
        public Nullable<decimal> Стоимость_без_доставки { get; set; }
        public Nullable<decimal> Стоимость_с_доставкой { get; set; }
        public Nullable<bool> Транспорт_от_поставщика { get; set; }
        public Nullable<bool> korr { get; set; }
        public Nullable<bool> IsCorrected { get; set; }
        public Nullable<bool> IsInSklad { get; set; }
        public Nullable<bool> IsTrOpl { get; set; }
        public Nullable<bool> IsInSrZeny { get; set; }
        public Nullable<decimal> kod_perevoz { get; set; }
        public Nullable<decimal> kod_shet { get; set; }
        public Nullable<decimal> dopRash { get; set; }
        public Nullable<decimal> nom_inv { get; set; }
        public Nullable<decimal> procent_dostavki { get; set; }
        public Nullable<bool> podshit_orig { get; set; }
        public Nullable<bool> podshit_copy { get; set; }

        public virtual ICollection<Sklad_prihod_tov> Sklad_prihod_tov { get; set; }
    }
}
