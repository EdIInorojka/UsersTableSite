using System.ComponentModel.DataAnnotations;

namespace DataAPI.Models
{
    public class CompanyHistoryModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string? StoreCity { get; set; }
    }
}
