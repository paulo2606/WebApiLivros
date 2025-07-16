using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
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
        public Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor)
        {
            throw new NotImplementedException();
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
