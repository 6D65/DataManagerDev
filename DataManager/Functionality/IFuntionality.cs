using ApiSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Functionality
{
    public interface IFuntionality
    {
        public T CreateObject<T>() where T: ApiSchemaObject;
        public T DeleteObject<T>() where T: ApiSchemaObject;
    }
}
