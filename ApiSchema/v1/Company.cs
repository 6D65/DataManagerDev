﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSchema.v1
{
    public class Company : ApiSchemaObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}
