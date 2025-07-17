using WebApiLivros.Model;

namespace WebApiLivros.Services
{
    public interface IBook
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<BookModel>> GetBookByName(string Title);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookModel newBook);
        Task<ResponseModel<List<BookModel>>> EditBook(BookModel bookEdited);
        Task<ResponseModel<BookModel>> DeleteBookById(int idBook);
    }
}
