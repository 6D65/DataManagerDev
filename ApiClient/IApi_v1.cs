using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonkeys
{
    public interface IApi_v1
    {
        [Get("/api/v1/companies/{companyId}")]
        Task<Company> GetCompany(int companyId);
    }

    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}
