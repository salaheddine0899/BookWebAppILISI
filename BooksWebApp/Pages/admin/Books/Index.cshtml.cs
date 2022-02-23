#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksWebApp.Data;
using BooksWebApp.Model;

namespace BooksWebApp.Pages.admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly BooksWebApp.Data.MyDbContext _context;

        public IndexModel(BooksWebApp.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}
