﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Karta
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
    }
}
