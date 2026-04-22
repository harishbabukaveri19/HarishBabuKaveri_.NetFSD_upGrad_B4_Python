using DALLayer_CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer_CMS.Models
{
    public class Company
    {
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}

