using ApiSampleService.common;
using ApiSchema.v1;
using Nancy;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.v1
{
    public class CompaniesApi : NancyModule
    {
        public CompaniesApi() : this("/api/v1") {}

        public CompaniesApi(string versionString)
            : base(versionString)
        {
            Get["/companies/{companyId:int}"] = parameters =>
            {
                this.RequiresAuthentication();
                Company company = new Company();
                company.Id = parameters.companyId;
                company.Name = string.Format("Company {0} Name", parameters.companyId);
                company.Address = string.Format("Company {0} Address", parameters.companyId);

                SingleResult result = new SingleResult { Result = company, Success = true };
                return Response.AsJson(result);
            };

            Get["/companies"] = parameters =>
            {
                List<object> companiesResult = new List<object>();
                for (int i = 0; i < 100; i++)
                {
                    Company company = new Company();
                    company.Id = i;
                    company.Name = string.Format("Company {0} Name", i);
                    company.Address = string.Format("Company {0} Addres", i);
                    companiesResult.Add(company);
                }
                ArrayResult result = new ArrayResult { Result = companiesResult, Success = true };
                return Response.AsJson(result);
            };

            Post["/companies"] = _ =>
            {
                this.RequiresAuthentication();
                return "Welcome";
            };

            Get["/companies/products/{productId:int}"] = parameters => { return new { Result = "Eveything's good" }; };
        }
    }
}
