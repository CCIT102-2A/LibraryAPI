using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using LibraryBorrowingApi.Models;

namespace LibraryBorrowingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                ISBN = "9780134494166",
                Title = "The C# Player's Guide",
                Author = "RB Whitaker",
                Category = "Programming / C#",
                Publisher = "Starbound Software",
                PublicationYear = 2021,
                Quantity = 5,
                AvailableCopies = 5
            },

            new Book
            {
                Id = 2,
                ISBN = "9780135974445",
                Title = "C# 10 in a Nutshell",
                Author = "Joseph Albahari",
                Category = "Programming / C#",
                Publisher = "O'Reilly Media",
                PublicationYear = 2022,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 3,
                ISBN = "9781491950171",
                Title = "Learning React",
                Author = "Alex Banks",
                Category = "Web Development",
                Publisher = "O'Reilly Media",
                PublicationYear = 2020,
                Quantity = 6,
                AvailableCopies = 6
            },

            new Book
            {
                Id = 4,
                ISBN = "9780135957059",
                Title = "Database System Concepts",
                Author = "Abraham Silberschatz",
                Category = "Database Systems",
                Publisher = "McGraw-Hill",
                PublicationYear = 2019,
                Quantity = 5,
                AvailableCopies = 5
            },

            new Book
            {
                Id = 5,
                ISBN = "9780133594140",
                Title = "Computer Networking",
                Author = "James Kurose",
                Category = "Computer Networks",
                Publisher = "Pearson",
                PublicationYear = 2021,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 6,
                ISBN = "9781119565216",
                Title = "Cybersecurity Essentials",
                Author = "Charles J. Brooks",
                Category = "Cybersecurity",
                Publisher = "Wiley",
                PublicationYear = 2018,
                Quantity = 3,
                AvailableCopies = 3
            },

            new Book
            {
                Id = 7,
                ISBN = "9780135181962",
                Title = "Software Engineering",
                Author = "Ian Sommerville",
                Category = "Software Engineering",
                Publisher = "Pearson",
                PublicationYear = 2019,
                Quantity = 5,
                AvailableCopies = 5
            },

            new Book
            {
                Id = 8,
                ISBN = "9781119281233",
                Title = "Management Information Systems",
                Author = "Kenneth Laudon",
                Category = "Information Systems",
                Publisher = "Pearson",
                PublicationYear = 2020,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 9,
                ISBN = "9780262046305",
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen",
                Category = "Data Structures and Algorithms",
                Publisher = "MIT Press",
                PublicationYear = 2022,
                Quantity = 6,
                AvailableCopies = 6
            },

            new Book
            {
                Id = 10,
                ISBN = "9780134610993",
                Title = "Artificial Intelligence",
                Author = "Stuart Russell",
                Category = "Artificial Intelligence",
                Publisher = "Pearson",
                PublicationYear = 2021,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 11,
                ISBN = "9781119456339",
                Title = "Operating System Concepts",
                Author = "Abraham Silberschatz",
                Category = "Operating Systems",
                Publisher = "Wiley",
                PublicationYear = 2018,
                Quantity = 5,
                AvailableCopies = 5
            },

            new Book
            {
                Id = 12,
                ISBN = "9780128119051",
                Title = "Computer Organization and Architecture",
                Author = "William Stallings",
                Category = "Computer Architecture",
                Publisher = "Pearson",
                PublicationYear = 2019,
                Quantity = 3,
                AvailableCopies = 3
            },

            new Book
            {
                Id = 13,
                ISBN = "9781119563998",
                Title = "Cloud Computing",
                Author = "Thomas Erl",
                Category = "Cloud Computing",
                Publisher = "Prentice Hall",
                PublicationYear = 2019,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 14,
                ISBN = "9780134289104",
                Title = "Android Programming",
                Author = "Bill Phillips",
                Category = "Mobile Development",
                Publisher = "Big Nerd Ranch",
                PublicationYear = 2021,
                Quantity = 3,
                AvailableCopies = 3
            },

            new Book
            {
                Id = 15,
                ISBN = "9781491924464",
                Title = "Designing Interfaces",
                Author = "Jenifer Tidwell",
                Category = "UI/UX Design",
                Publisher = "O'Reilly Media",
                PublicationYear = 2020,
                Quantity = 5,
                AvailableCopies = 5
            },

            new Book
            {
                Id = 16,
                ISBN = "9780135228387",
                Title = "Project Management",
                Author = "Harold Kerzner",
                Category = "Project Management",
                Publisher = "Wiley",
                PublicationYear = 2022,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 17,
                ISBN = "9781260080917",
                Title = "Business Management",
                Author = "Stephen Robbins",
                Category = "Business Management",
                Publisher = "McGraw-Hill",
                PublicationYear = 2020,
                Quantity = 3,
                AvailableCopies = 3
            },

            new Book
            {
                Id = 18,
                ISBN = "9780321982384",
                Title = "Discrete Mathematics",
                Author = "Kenneth Rosen",
                Category = "Mathematics",
                Publisher = "McGraw-Hill",
                PublicationYear = 2019,
                Quantity = 5,
                AvailableCopies = 5
            },

            new Book
            {
                Id = 19,
                ISBN = "9780133750172",
                Title = "Communication Skills",
                Author = "John W. Santrock",
                Category = "Communication",
                Publisher = "Pearson",
                PublicationYear = 2018,
                Quantity = 4,
                AvailableCopies = 4
            },

            new Book
            {
                Id = 20,
                ISBN = "9781506336132",
                Title = "Research Methods",
                Author = "John W. Creswell",
                Category = "Research Methods",
                Publisher = "SAGE Publications",
                PublicationYear = 2018,
                Quantity = 3,
                AvailableCopies = 3
            }
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    message = "Book not found."
                });
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            book.Id = books.Count == 0
                ? 1
                : books.Max(b => b.Id) + 1;

            books.Add(book);

            return CreatedAtAction(
                nameof(GetBook),
                new { id = book.Id },
                book
            );
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    message = "Book not found."
                });
            }

            book.ISBN = updatedBook.ISBN;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;
            book.Publisher = updatedBook.Publisher;
            book.PublicationYear = updatedBook.PublicationYear;
            book.Quantity = updatedBook.Quantity;
            book.AvailableCopies = updatedBook.AvailableCopies;

            return Ok(book);
        }

        // PATCH: api/books/1
        [HttpPatch("{id}")]
        public IActionResult PatchBook(
            int id,
            JsonPatchDocument<Book> patchDocument)
        {
            // Find the book using the supplied ID
            var book = books.FirstOrDefault(b => b.Id == id);

            // Check if the book exists
            if (book == null)
            {
                return NotFound(new
                {
                    message = "Book not found."
                });
            }

            // Check if the PATCH document was supplied
            if (patchDocument == null)
            {
                return BadRequest(new
                {
                    message = "Patch document is required."
                });
            }

            // Apply the JSON PATCH operations
            patchDocument.ApplyTo(book);

            // Return the updated book
            return Ok(book);
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(new
                {
                    message = "Book not found."
                });
            }

            books.Remove(book);

            return Ok(new
            {
                message = "Book deleted successfully."
            });
        }
    }
}