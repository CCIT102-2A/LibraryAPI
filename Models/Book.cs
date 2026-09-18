namespace LibraryBorrowingApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string ISBN { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Publisher { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        public int Quantity { get; set; }

        public int AvailableCopies { get; set; }
    }
}