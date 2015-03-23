using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.v3
{
    public class CompanyApi : ApiSampleService.v2.CompaniesApi
    {
        public CompanyApi() : base("/api/v3") { }
    }
}
