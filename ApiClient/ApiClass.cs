using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    class ApiClass
    {
        static ApiClass()
        {
            System.Net.GlobalProxySelection.Select = new WebProxy(new Uri("127.0.0.1:8888"));
        }
    }
}
