﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingContest1.BLL.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; }
    }
}
