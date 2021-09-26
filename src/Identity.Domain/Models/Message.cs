﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public abstract class Message
    {

        public string Type { get; protected set; }

        public Guid AggregatedId { get; protected set; }

        public Message()
        {
            Type = this.GetType().Name;
        }
    }
}