using System.Text.Json.Serialization;

namespace WebApiLivros.Model
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; } = string.Empty;
        public string SurnameAuthor { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<BookModel>? Books { get; set; }
    }
}
