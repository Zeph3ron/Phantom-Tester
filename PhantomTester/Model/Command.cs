﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    public class Command
    {
        public string Cmd { get; set; }
        public string[] Parameters { get; set; }
    }
}
