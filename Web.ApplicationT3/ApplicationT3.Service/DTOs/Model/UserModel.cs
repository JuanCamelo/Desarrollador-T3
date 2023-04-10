using System.Text.Json.Serialization;

namespace ApplicationT3.Service.DTOs.Model
{
    public class UserModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }
}
