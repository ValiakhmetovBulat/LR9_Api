using Newtonsoft.Json;

namespace Api.Models
{
    public class User
    {
        public int ID { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string? papaname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
