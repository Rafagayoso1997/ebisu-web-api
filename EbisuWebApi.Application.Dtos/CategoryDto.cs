﻿using EbisuWebApi.Crosscutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public bool IsDefault { get; set; }
    }
}
