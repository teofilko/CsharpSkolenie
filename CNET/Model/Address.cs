﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Address
    {
        public string City { get; set; }

        public string Street { get; set; }

        public override string ToString()
            => $"{City} {Street}";

    }
}
