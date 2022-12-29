using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Category
    {
        [Key]
        public int kod_zap { get; set; }
        public string? name { get; set; }
        public string? short_name { get; set; }
        public string? color { get; set; }
        public Nullable<int> parent_kod_zap { get; set; }

        [ForeignKey("parent_kod_zap")]
        public Category? Parent { get; set; }
    }
}
