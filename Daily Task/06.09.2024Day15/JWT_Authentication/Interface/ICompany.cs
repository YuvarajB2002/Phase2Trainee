using APICodeFirst.Model;

namespace APICodeFirst.Interface
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetAllCompanies();

        Task<Company> GetCompanyById(int id);

        Task AddCompany(Company company);

        Task UpdateCompany(int id, Company c);
        Task DeleteCompany(int  id);
    }
}
