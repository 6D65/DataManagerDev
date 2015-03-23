using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.common
{
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
}
