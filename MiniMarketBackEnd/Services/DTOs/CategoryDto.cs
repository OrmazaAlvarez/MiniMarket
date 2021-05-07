using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarketBackEnd.Services.DTOs
{
    public class CategoryDto
    {
        public short CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
