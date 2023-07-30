using System.ComponentModel.DataAnnotations;

namespace DataAPI.Models
{
    public class CompanyEmployeesModel
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int InvoiceNumber { get; set; }
        public string? Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Position { get; set; }
    }
}
