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
                    response.Message = "Author not found.";
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

        public async Task<ResponseModel<AuthorModel>> GetAuthorByName(string nameAuthor)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();

            try
            {
                var authorByName = await _context.Authors.FirstOrDefaultAsync(AuthorDataBase => AuthorDataBase.NameAuthor == nameAuthor);

                if (authorByName == null)
                {
                    response.Message = "Id not found.";
                    return response;
                }

                response.Data = authorByName;
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

        
    }
}
