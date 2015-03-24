using ApiSchema.v1;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Api.v1
{
    public interface CompaniesApi
    {
        [Get("/api/v1/companies/{companyId}")]
        Task<Company> GetCompany(int companyId);

        [Get("/api/v1/companies")]
        Task<List<Company>> GetAllCompanies();
    }
}
