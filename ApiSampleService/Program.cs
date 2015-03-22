using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Authentication.Token;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.Security;
using Nancy.TinyIoc;
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
            var uri = new Uri("http://localhost:8000");
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;

            using (var host = new NancyHost(uri, new ApiKeyAuthBoostrapper(), hostConfigs))
            {
                host.Start();

                Console.WriteLine("Mock Server Running..");
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }

        public class TokenAuthBootstrapper : DefaultNancyBootstrapper
        {
            protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
            {
                TokenAuthentication.Enable(pipelines, new TokenAuthenticationConfiguration(container.Resolve<ITokenizer>()));
            }
        }

        public class ApiKeyAuthBoostrapper : DefaultNancyBootstrapper
        {
            protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
            {
                var config = new StatelessAuthenticationConfiguration(nancyContext => 
                {
                    var apiKey = nancyContext.Request.Headers["x-ApiKey"].FirstOrDefault();

                    if (apiKey == null) { return null; }

                    // In case the ApiKey is passed as a query parameter.
                    //if (!nancyContext.Request.Query.apiKey.HasValue) { return null; }
                    //var apiKey = (string)nancyContext.Request.Query.apiKey.Value;

                    return DataBaseMock.GetUserFromApiKey(apiKey);
                });

                AllowAccessToConsumingSite(pipelines);
                StatelessAuthentication.Enable(pipelines, config);
            }
        }

        static void AllowAccessToConsumingSite(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
            {
                x.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,DELETE,PUT,OPTIONS");
            });
        }

        public class DataBaseMock
        {
            public static AppUserIndentity GetUserFromApiKey(string apiKey)
            {
                if (apiKey == "c5c16da7-e0fc-4e14-a522-3dab15a7a593") 
                {
                    return new AppUserIndentity { UserName = "admin", Claims = new List<string> { "god" } };
                }
                return null;
            }
        }

        public class AppUserIndentity : IUserIdentity
        {
            public IEnumerable<string> Claims { get; set; }
            public string UserName { get; set; }
        }
    }
}
