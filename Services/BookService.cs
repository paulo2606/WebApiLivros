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

        public async Task<ResponseModel<BookModel>> DeleteBookById(int idBook)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var Book = _context.Books.FirstOrDefault(BookDataBase => BookDataBase.Id == idBook);
                if (Book == null)
                {
                    response.Message = "Book not found";
                    response.Status = false;
                }

                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();

                response.Data = Book;
                response.Status = true;
                response.Message = "Book deleted successfully.";
                return response;
            }
            catch (Exception ex) 
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> EditBook(int idBook, BookModel bookEdited)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(BookDataBase => BookDataBase.Title.Equals(bookEdited));
                if (book == null)
                {
                    response.Message = "Book not found";
                    response.Status = false;
                }

                book.Title = bookEdited.Title;
                book.Description = bookEdited.Description;
                book.Year = bookEdited.Year;

                //_context.Books.Update(bookEdited);
                await _context.SaveChangesAsync();

                response.Data = book;
                response.Status = true;
                response.Message = "Book edited successfully.";
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
