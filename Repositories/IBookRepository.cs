using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(string sort);

        Task<Book> GetByIdAsync(int id);

        Task AddAsync(Book book);

        Task UpdateAsync(Book book);

        Task DeleteAsync(Book book);
    }
}
