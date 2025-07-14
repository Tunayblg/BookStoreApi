using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class BookDto
    {
        public string Name { get; set; }

        public decimal Price {  get; set; }

        public int PageCount { get; set; }

        public string Author { get; set; }
    }
}
