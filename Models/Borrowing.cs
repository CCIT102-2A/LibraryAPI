namespace LibraryBorrowingApi.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }

        public int StudentId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }// 2026-09-12T08:00:00 Format

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string Status { get; set; } = "Borrowed";
    }
}