using DTOs;
using Entities;
using Repositories;
using AutoMapper;

using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;

        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)

        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.AddAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return;
            await _bookRepository.DeleteAsync(book);
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);//repository den 2 yi çek.
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task UpdateAsync(int id, BookDto bookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null) return;

            _mapper.Map(bookDto, existingBook);
            existingBook.Id = id;
            await _bookRepository.UpdateAsync(existingBook);


        }

        public async Task<List<BookDto>> GetAllAsync(string sort)
        {
            var books = await _bookRepository.GetAllAsync(sort);

            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
