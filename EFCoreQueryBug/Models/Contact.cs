﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreQueryBug.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Statement> Statements { get; set; }
    }
}
