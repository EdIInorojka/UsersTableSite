using Microsoft.EntityFrameworkCore;
using System;

namespace DataAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            AddCompanies();
        }
        public DbSet<CompanyModel> Company { get; set; } = null!;
        public DbSet<CompanyHistoryModel> History { get; set; } = null!;
        public DbSet<CompanyEmployeesModel> Employee { get; set; } = null!;

        Random _random = new Random();
        public void AddCompanies()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;

            var companies = new List<CompanyModel>();

            for (int i = 0; i < 12; i++)
            {
                CompanyModel company = new CompanyModel()
                {
                    CompanyName = "Comapany " + i.ToString(),
                    CompanyLocationCity = "City " + i.ToString(),
                    CompanyLocationRegion = "Region " + i.ToString(),
                    CompanyEmployees = new List<CompanyEmployeesModel>
                    {
                        new CompanyEmployeesModel
                        {
                            FirstName = "Name " + _random.Next(3).ToString(),
                            LastName = "Surname " + _random.Next(3).ToString(),
                            InvoiceNumber = _random.Next(10000, 100000),
                            Title = "Mr.",
                            BirthDate = start.AddDays(_random.Next(range)),
                            Position = "Worker"
                        },
                        new CompanyEmployeesModel
                        {
                            FirstName = "Name " + _random.Next(3).ToString(),
                            LastName = "Surname " + _random.Next(3).ToString(),
                            InvoiceNumber = _random.Next(10000, 100000),
                            Title = "Mr.",
                            BirthDate = start.AddDays(_random.Next(range)),
                            Position = "Worker"
                        },
                        new CompanyEmployeesModel
                        {
                            FirstName = "Name " + _random.Next(3).ToString(),
                            LastName = "Surname " + _random.Next(3).ToString(),
                            InvoiceNumber = _random.Next(10000, 100000),
                            Title = "Mr.",
                            BirthDate = start.AddDays(_random.Next(range)),
                            Position = "Worker"
                        }
                    },
                    CompanyHistory = new List<CompanyHistoryModel>
                    {
                        new CompanyHistoryModel
                        {
                            OrderDate = start.AddDays(_random.Next(range)),
                            StoreCity = "City " + _random.Next(3)
                        },
                        new CompanyHistoryModel
                        {
                            OrderDate = start.AddDays(_random.Next(range)),
                            StoreCity = "City " + _random.Next(3)
                        },
                        new CompanyHistoryModel
                        {
                            OrderDate = start.AddDays(_random.Next(range)),
                            StoreCity = "City " + _random.Next(3)
                        }
                    }
                };
                companies.Add(company);
            }
            Company.AddRange(companies);
        }
    }
}
