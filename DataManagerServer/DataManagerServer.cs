using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Akavache;
using ApiSchema.v1;
using NNanomsg.Protocols;
using NNanomsg;

namespace TestMonkeys.DataManager
{
    class DataManagerServer
    {
        private static string DBName { get { return "DataManager"; } }

        static void Main(string[] args)
        {
            const string socketAddress = "tcp://127.0.0.1:5088";
            using (var rep = new ReplySocket())
            {
                rep.Bind(socketAddress);

                var listener = new NanomsgListener();
                listener.AddSocket(rep);
                listener.ReceivedMessage += socketId =>
                {
                    Console.WriteLine("Message from CLIENT: " + Encoding.UTF8.GetString(rep.Receive()));
                    const string response = "Hello from the DataManagerServer";
                    rep.Send(Encoding.UTF8.GetBytes(response));
                };

                listener.Listen(null);
                //s.
            }

            //BlobCache.ApplicationName = DBName;
            //BlobCache.LocalMachine.getall

            //var allCompanies = GetAllObjectsAsync();
            //Task.WaitAll(allCompanies);
        }

        public static void CreateABunchOfStuff()
        {
            var tasks = new List<IObservable<System.Reactive.Unit>>();
            for (var i = 0; i < 100; i++)
            {
                Company comp =
                    new Company { Address = string.Format("Address{0}", i), Id = i, Name = string.Format("CompanyName{0}", i) };
                var task = BlobCache.UserAccount.InsertObject(string.Format("AkavacheCompany{0}", i), comp);
                tasks.Add(task);
            }

            Task.WaitAll(tasks.Select(x => x.ToTask()).ToArray());
        }

        public static async Task<IDictionary<string, Company>> GetObjectsAsync()
        { 
            var companies = await BlobCache.UserAccount.GetObjects<Company>(new List<string> { "AkavacheCompany0", "AkavacheCompany1", "AkavacheCompany2" });
            return companies;
        }

        public static async Task<IEnumerable<Company>> GetAllObjectsAsync()
        {
            var allCompanies = await BlobCache.UserAccount.GetAllObjects<Company>();
            return allCompanies;
        }

        public static async Task<Company> CheckTheDbRead() {

            var company = await GetObject<Company>("AkavacheCompany");

            return company;
        }

        public static async Task<T> GetObject<T>(string name)
        {
            BlobCache.ApplicationName = "DataManager";

            var objectOfInterest = await BlobCache.UserAccount.GetObject<T>(name);

            return objectOfInterest;
        }
    }
}
