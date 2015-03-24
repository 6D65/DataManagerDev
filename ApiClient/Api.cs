using ApiClient.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class Api<T> where T : ApiVersion, new()
    {
    }
}
