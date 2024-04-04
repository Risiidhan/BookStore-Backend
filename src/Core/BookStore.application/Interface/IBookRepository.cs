
using BookStore.domain.Models;

namespace BookStore.application.Interface
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetBookDetailList();
        Task<Book?> GetBookDetailList(int id);

    }
}

