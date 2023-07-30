using System.ComponentModel.DataAnnotations;

namespace DataAPI.Models
{
    public class CompanyModel
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyLocationCity { get; set; }
        public string? CompanyLocationRegion { get; set; }
        public string? CompanyPhone { get; set; }
        public List<CompanyHistoryModel>? CompanyHistory { get; set; }
        public List<CompanyEmployeesModel>? CompanyEmployees { get; set;}

    }
}
