using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Zen_roznichnie
    {
        [Key]
        public int tov { get; set; }
        public Nullable<decimal> zena_ot_lista { get; set; }
        public Nullable<decimal> zena_ot_pachki { get; set; }
        public Nullable<decimal> zena_ot_4x_pachek { get; set; }
        public Nullable<decimal> zena_ot_lista_nal { get; set; }
        public Nullable<decimal> zena_ot_pachki_nal { get; set; }
        public Nullable<decimal> zena_ot_4x_pachek_nal { get; set; }
        public Nullable<decimal> skidka_nal { get; set; }
        public Nullable<decimal> skidka_opt { get; set; }
        public Nullable<decimal> kod_zagolovka { get; set; }
        public Nullable<bool> monitoring { get; set; }
        public Nullable<bool> Выгрузить { get; set; }
        public Nullable<int> Кол_дней_мониторинг { get; set; }
        public Nullable<bool> Ключевой_товар { get; set; }
        public Nullable<bool> print { get; set; }
        public string? descr_pulse_zen { get; set; }
        public string? sh_descr_pulse_zen { get; set; }
        public string? name_sklad { get; set; }
        public string? name_site { get; set; }
        public string? name_zav_sklad { get; set; }
        [ForeignKey("tov")]
        public virtual Tovary? Tovar { get; set; }

        [ForeignKey("kod_zagolovka")]
        public virtual Prays_zagolovki? Zagolovki { get; set; }
    }
}
