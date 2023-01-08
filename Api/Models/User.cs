using Newtonsoft.Json;

namespace Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
