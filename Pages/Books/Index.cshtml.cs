using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Models;

namespace RazorPagesBook.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook.Models.RazorPagesBookContext _context;

        public IndexModel(RazorPagesBook.Models.RazorPagesBookContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Genre
                                            select m.Genre;
            var book = from m in _context.Book
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                book = book.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BookGenre))
            {
                book = book.Where(x => x.Genre == BookGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Books = await book.ToListAsync();
        }
    }
}
