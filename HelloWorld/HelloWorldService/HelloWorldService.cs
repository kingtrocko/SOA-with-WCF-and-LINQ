﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWCFServices
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetMessage(string name)
        {
            return "Hello world from " + name + "!";
        }
    }
}
