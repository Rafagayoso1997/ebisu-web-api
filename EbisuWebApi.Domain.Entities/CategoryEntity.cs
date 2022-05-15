using EbisuWebApi.Crosscutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Entities
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public CategoryType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDefault { get; set; }
    }
}
