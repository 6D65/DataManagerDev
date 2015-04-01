using ApiSchema.v1;
using NNanomsg.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonkeys.DataManager
{
    public class DataManagerClient
    {
        string _url;

        public DataManagerClient(){
        }

        public DataManagerClient(string url) : base() {
            _url = url;
        }

        public ApiSchema.ApiObject SendMessage(string message)
        { 
            using(var s = new RequestSocket())
            {
                s.Connect(_url);
                s.Send(Encoding.UTF8.GetBytes(message));

                //return Encoding.UTF8.GetString(s.Receive());
                return ApiSchema.Helpers.DeserializeObject(s.Receive());
            }
        }
    }
}
