﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class GenreType
    {
        public int Id { get; set; }

        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}