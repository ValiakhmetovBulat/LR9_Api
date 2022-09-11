﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Sklad_rashod_tov
    {
        [Key]
        public decimal kod_zap { get; set; }
        public Nullable<decimal> kod_rashoda { get; set; }
        public Nullable<decimal> tov { get; set; } 
        public Nullable<decimal> count { get; set; }
        public Nullable<decimal> count_pachek { get; set; }
        public Nullable<decimal> nom_prih { get; set; }
        public Nullable<decimal> zena { get; set; }
        public Nullable<decimal> pribyl { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> volume { get; set; }
        //public Nullable<decimal> ploshad { get; set; }
        [ForeignKey("kod_rashoda")]
        public virtual Sklad_rashod? Sklad_rashod { get; set; }

    }
}