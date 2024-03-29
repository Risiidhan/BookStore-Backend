using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.application.DTO.Book
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public int QuantityAvailable { get; set; }
    }
}