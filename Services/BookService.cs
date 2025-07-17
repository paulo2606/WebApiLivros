using Microsoft.EntityFrameworkCore;
using WebApiLivros.Data;
using WebApiLivros.Model;

namespace WebApiLivros.Services
{
    public class BookService : IBook
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<BookModel>>> ListBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
                var books = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Data = books;
                response.Message = "Books retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBookByName(string Title)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var bookByName = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(BookDataBase => BookDataBase.Title == Title);
                if (bookByName == null)
                {
                    response.Message = "Book not found.";
                    return response;
                }
                response.Data = bookByName;
                response.Status = true;
                response.Message = "Book retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookModel newBook)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
                _context.Books.Add(newBook);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Status = true;
                response.Message = "Book created successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public Task<ResponseModel<List<BookModel>>> EditBook(BookModel bookEdited)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<BookModel>> DeleteBook(int idBook)
        {
            throw new NotImplementedException();
        }
    }
}
