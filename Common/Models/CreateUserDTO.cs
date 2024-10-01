﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        
        [MinLength(12)]
        public string Password { get; set; }
    }
}
