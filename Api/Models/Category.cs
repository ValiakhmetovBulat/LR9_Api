using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string? name { get; set; }
        public string? short_name { get; set; }
        public int? parentID { get; set; }

        [ForeignKey("parentID")]
        public Category? Parent { get; set; }
    }
}
