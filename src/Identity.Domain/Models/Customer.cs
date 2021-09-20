﻿using Identity.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}