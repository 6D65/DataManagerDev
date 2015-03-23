using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSampleService.common
{
    public class ArrayResult
    {
        public bool Success { get; set; }
        public List<object> Result { get; set; }
    }
}
