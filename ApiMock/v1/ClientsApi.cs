using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.v1
{
    public class ClientsApi : NancyModule
    {
        public ClientsApi() : base("/api/v1")
        {
            Get["/clients/{clientId:int}"] = parameters => { return new { Result = "Clients"}; };
            Post["/clients/{clientId:int}"] = parameters => { return new { Result = "Clients"}; };
            Put["/clients/{clientId:int}"] = parameters => { return new { Result = "Clients"}; };
            Delete["/clients/{clientId:int}"] = parameters => { return new { Result = "Clients" }; };
        }
    }
}
