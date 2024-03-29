﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Sklad
{
    public partial class Price
    {
        public int ID { get; set; }
        public int productID { get; set; }
        public double price_nal { get; set; }
        public double price_beznal { get; set; }
        [ForeignKey("productID")]
        public virtual Product? Tovar { get; set; }
    }
}
