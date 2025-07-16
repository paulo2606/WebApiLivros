namespace WebApiLivros.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel? Author { get; set; } 
    }
}
