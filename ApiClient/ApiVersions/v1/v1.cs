using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace ApiClient.ApiVersions.v1
{
    public class v1 : ApiVersion
    {
        string _apiHost;

        public v1(string endpoint) {
            this._apiHost = endpoint;
        }

        public IProductsApi Products { get { return RestService.For<IProductsApi>(_apiHost); } }
    }
}
