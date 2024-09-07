using APICodeFirst.Interface;
using APICodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace APICodeFirst.Repository
{
    public class CompanyRepository : ICompany
    {
        private readonly EmployeeContext _context;
        public CompanyRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companys.Include(c=> c.employees).ToListAsync();
        }
        public async Task<Company> GetCompanyById(int id)
        {
            return await _context.Companys.FirstOrDefaultAsync(c=>c.companyId == id);

        }

        public async Task AddCompany(Company c)
        {
             await _context.Companys.AddAsync(c);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteCompany(int cid)
        {
            var com = await _context.Companys.FindAsync(cid);
            if (com != null)
            {
                _context.Companys.Remove(com);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCompany(int id, Company company)
        {
            if (id == company.companyId)
            {
                _context.Entry(company).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
