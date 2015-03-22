using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.Api.v1
{
    public class CompaniesApi : NancyModule
    {
        public CompaniesApi()
        {
            Get["/api/v1/companies/{companyId:int}"] = parameters =>
            {
                Company company = new Company();
                company.Id = parameters.companyId;
                company.Name = string.Format("Company {0} Name", parameters.companyId);
                company.Address = string.Format("Company {0} Address", parameters.companyId);

                SingleResult result = new SingleResult { Result = company, Success = true };
                return Response.AsJson(result);
            };

            Get["/api/v1/companies"] = parameters =>
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

            Post["/api/v1/companies"] = _ =>
            { 
                this.RequiresAuthentication();
            };

        }
    }

    public class AuthModule : NancyModule
    {
        public AuthModule(ITokenizer tokenizer)
            : base("/auth")
        {
            Post["/token"] = x =>
            {
                IUserIdentity indentity = new BasicIdentity { UserName = "admin", Claims = new List<string> { "Money", "Power" } };
                var token = tokenizer.Tokenize(indentity, Context);
                return new { Token = token };
            };

            Post["/apikey"] = x => 
            {
                return new { ApiKey = "c5c16da7-e0fc-4e14-a522-3dab15a7a593" };
            };
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }

    public class SingleResult
    {
        public bool Success { get; set; }
        public object Result { get; set; }
    }

    public class ArrayResult
    {
        public bool Success { get; set; }
        public List<object> Result { get; set;}
    }

    public class BasicIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}
