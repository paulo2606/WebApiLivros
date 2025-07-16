using WebApiLivros.Model;

namespace WebApiLivros.Services
{
    public interface IAuthor 
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByName(string nameAuthor);
        Task<ResponseModel<BookModel>> GetBookByName(string Title);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookModel newBook);


    }
}
