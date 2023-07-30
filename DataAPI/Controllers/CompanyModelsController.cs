using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAPI.Models;

namespace DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyModelsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CompanyModelsController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CompanyModel> GetCompany()
        {
            var companies = _context.Company;

            if (companies == null)
            {
                return (IEnumerable<CompanyModel>)NotFound();
            }

            return companies;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> GetCompanyById(int id)
        {
            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyModel>> PostCompany(CompanyModel company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyModel company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(long id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyModelExists(int id)
        {
            return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
