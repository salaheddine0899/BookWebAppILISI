using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApp.Model
{
    [Table("books")]
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required,MaxLength(20)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required, MaxLength(20)]
        public string Author { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
