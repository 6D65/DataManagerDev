using Nancy;
using Nancy.Hosting.Self;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8888");
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;

            using (var host = new NancyHost(new Uri("http://localhost:8000"), new DefaultNancyBootstrapper(), hostConfigs))
            {
                host.Start();

                Console.WriteLine("Mock Server Running..");
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }

    public class ResourceModule : NancyModule
    {
        public ResourceModule()
        {
            Company company = new Company { Address = "BananaStreet", Name = "Company Name" };

            Get["/companies/{companyId:int}"] = parameters =>
            {
                company.Id = parameters.companyId;
                return Response.AsJson(JsonConvert.SerializeObject(company));
            };
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}
