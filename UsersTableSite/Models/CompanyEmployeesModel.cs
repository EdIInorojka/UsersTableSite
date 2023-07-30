namespace UsersTableSite.Models
{
    public class CompanyEmployeesModel
    {
        public int  CompanyId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InvoiceNumber { get; }
        public string Title { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Position { get; set; }
    }
}
