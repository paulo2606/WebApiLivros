using WebApiLivros.Model;

namespace WebApiLivros.Services
{
    public interface IAuthor 
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthor();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByName(string nameAuthor);
        


    }
}
