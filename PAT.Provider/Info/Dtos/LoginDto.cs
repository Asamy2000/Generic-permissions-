﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Info.Dtos
{
    public class LoginDto
    {
      
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
