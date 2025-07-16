using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApiLivros.Data;
using WebApiLivros.Model;

namespace WebApiLivros.Services
{
    public class AuthorService : IAuthor
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();

            try
            {
                var authorById = await _context.Authors.FirstOrDefaultAsync(AuthorDataBase => AuthorDataBase.Id == idAuthor);

                if (authorById == null)
                {
                    response.Message = "Id not found.";
                    return response;
                }

                response.Data = authorById;
                response.Status = true;
                response.Message = "Author retrieved successfully.";

                return response;
                
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthor()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try 
            {
                var author = await _context.Authors.ToListAsync();
                response.Data = author;
                response.Message = "Authors retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public Task<ResponseModel<AuthorModel>> SearchAuthorByName(string nameAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
