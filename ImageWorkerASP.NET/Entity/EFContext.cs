﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageWorkerASP.NET.Entity
{
    public class EFContext:DbContext
    {
        public EFContext():base ("DefaultConnection")   {       }
        public DbSet<Product> products { get; set; }
    }
}