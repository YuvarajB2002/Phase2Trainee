using APICodeFirst.Interface;
using APICodeFirst.Model;

namespace APICodeFirst.Service
{
    public class CompanyService
    {

        private readonly ICompany _comrepo;
        public CompanyService(ICompany comrepo)
        {
            _comrepo = comrepo;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _comrepo.GetAllCompanies();
        }

        public async Task<Company> GetCompany(int id)
        {
            return await _comrepo.GetCompanyById(id);
        }

        public async Task AddComp(Company c)
        {
            await _comrepo.AddCompany(c);
        }

        public async Task DeleteComp(int id)
        {
            await _comrepo.DeleteCompany(id);
        }

        public async Task UpdateComp(int id, Company c)
        {
            await _comrepo.UpdateCompany(id, c);
        }
    }
}
