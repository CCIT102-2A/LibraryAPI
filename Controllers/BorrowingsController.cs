using Microsoft.AspNetCore.Mvc;
using LibraryBorrowingApi.Models;

namespace LibraryBorrowingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingsController : ControllerBase
    {
        private static readonly List<Borrowing> borrowings = new();

        // GET: api/borrowings
        [HttpGet]
        public ActionResult<IEnumerable<Borrowing>> GetBorrowings()
        {
            return Ok(borrowings);
        }

        // GET: api/borrowings/1
        [HttpGet("{id}")]
        public ActionResult<Borrowing> GetBorrowing(int id)
        {
          
            var borrowing = borrowings.FirstOrDefault(b => b.BorrowingId == id);

            if (borrowing == null)
            {
                return NotFound(new
                {
                    message = "Borrowing record not found."
                });
            }

            return Ok(borrowing);
        }

        // POST: api/borrowings
        [HttpPost]
        public ActionResult<Borrowing> CreateBorrowing(Borrowing borrowing)
        {
            borrowing.BorrowingId = borrowings.Count == 0 ? 1 : borrowings.Max(b => b.BorrowingId) + 1;

            if (borrowing.BorrowDate == default)
            {
                borrowing.BorrowDate = DateTime.Now;
            }

            if (borrowing.DueDate == default)
            {
                borrowing.DueDate =
                    borrowing.BorrowDate.AddDays(7);
            }

            borrowing.Status = "Borrowed";

            borrowings.Add(borrowing);

            return CreatedAtAction(
                nameof(GetBorrowing),
                new { id = borrowing.BorrowingId },
                borrowing
            );
        }

        // PUT: api/borrowings/1
        [HttpPut("{id}")]
        public IActionResult UpdateBorrowing(
            int id,
            Borrowing updatedBorrowing)
        {
            var borrowing = borrowings
                .FirstOrDefault(b => b.BorrowingId == id);

            if (borrowing == null)
            {
                return NotFound(new
                {
                    message = "Borrowing record not found."
                });
            }

            borrowing.StudentId = updatedBorrowing.StudentId;
            borrowing.BookId = updatedBorrowing.BookId;
            borrowing.BorrowDate = updatedBorrowing.BorrowDate;
            borrowing.DueDate = updatedBorrowing.DueDate;
            borrowing.ReturnDate = updatedBorrowing.ReturnDate;
            borrowing.Status = updatedBorrowing.Status;

            return Ok(borrowing);
        }

        // PATCH: api/borrowings/1/status
        [HttpPatch("{id}/status")]
        public IActionResult UpdateStatus(
            int id,
            [FromBody] string status)
        {
            var borrowing = borrowings
                .FirstOrDefault(b => b.BorrowingId == id);

            if (borrowing == null)
            {
                return NotFound(new
                {
                    message = "Borrowing record not found."
                });
            }

            borrowing.Status = status;

            if (status.Equals(
                "Returned",
                StringComparison.OrdinalIgnoreCase))
            {
                borrowing.ReturnDate = DateTime.Now;
            }

            return Ok(borrowing);
        }

        // DELETE: api/borrowings/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBorrowing(int id)
        {
            var borrowing = borrowings
                .FirstOrDefault(b => b.BorrowingId == id);

            if (borrowing == null)
            {
                return NotFound(new
                {
                    message = "Borrowing record not found."
                });
            }

            borrowings.Remove(borrowing);

            return Ok(new
            {
                message =
                    "Borrowing record deleted successfully."
            });
        }
    }
}