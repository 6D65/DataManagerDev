using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.v2
{
    public class CompaniesApi : ApiSampleService.v1.CompaniesApi
    {
        public CompaniesApi() : base("/api/v2") {}
        public CompaniesApi(string versionString) : base(versionString) {}
    }
}
