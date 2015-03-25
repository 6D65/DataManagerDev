using ApiClient.ApiVersions;
using ApiClient.ApiVersions.v1;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class Api
    {
        string _apiHost;

        public Api(string apiHost) {this._apiHost = apiHost;}

        public v1 v1 { get { return new v1(this._apiHost); } }
        //public ApiVersion v2 { get;}
    }
}
