﻿using NewsApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
