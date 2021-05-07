using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarketBackEnd.Services.DTOs
{
    public class SupplierDto
    {
        public short SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
    }
}
