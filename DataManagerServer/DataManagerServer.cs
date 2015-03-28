using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Akavache;
using ApiSchema.v1;

namespace TestMonkeys.DataManager
{
    class DataManagerServer
    {
        static void Main(string[] args)
        {
            BlobCache.ApplicationName = "DataManager";

            Company company = 
                new Company { Address="AkavacheCompanyAddress", Id=552, Name="AkavacheCompany Name" };
            BlobCache.UserAccount.InsertObject("AkavacheCompany", company);

            var com = CheckTheDbRead();
            Task.WaitAll(com);
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
