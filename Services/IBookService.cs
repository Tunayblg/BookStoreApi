using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync(string sort);
        Task<BookDto> GetByIdAsync(int id);

        Task AddAsync(BookDto boookDto);

        Task UpdateAsync(int id, BookDto bookDto);

        Task DeleteAsync(int id);
 

    }
}
