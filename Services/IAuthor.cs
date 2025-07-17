using WebApiLivros.Model;

namespace WebApiLivros.Services
{
    public interface IAuthor 
    {
        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByName(string nameAuthor);
        //Task<ResponseModel<List<AuthorModel>>> EditAuthor(BookModel bookEdited);
    }
}
