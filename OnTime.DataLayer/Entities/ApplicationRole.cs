﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnTime.DataLayer.Entities
{
   public class ApplicationRole:IdentityRole
    {
        public ApplicationRole():base()
        {
            
        }

        public ApplicationRole(string name):base(name)
        {
            
        }
    }
}