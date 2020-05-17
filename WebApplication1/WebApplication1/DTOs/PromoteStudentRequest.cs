﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class PromoteStudentRequest
    {

        [Required]
        public string Studies { get; set; }
        [Required]
        public Nullable<int> Semester { get; set; }


    }
}
