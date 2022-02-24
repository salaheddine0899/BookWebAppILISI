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
using Microsoft.AspNetCore.Authorization;

namespace BooksWebApp.Pages.admin.Books
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly BooksWebApp.Data.MyDbContext _context;

        public DetailsModel(BooksWebApp.Data.MyDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FirstOrDefaultAsync(m => m.BookID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
