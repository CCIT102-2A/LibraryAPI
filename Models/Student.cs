namespace LibraryBorrowingApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string RFID { get; set; } = string.Empty;

        public string StudentNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public int YearLevel { get; set; }

        public string Department { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}