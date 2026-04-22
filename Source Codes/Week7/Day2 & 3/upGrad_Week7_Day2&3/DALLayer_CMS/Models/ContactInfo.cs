using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer_CMS.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public long MobileNo { get; set; }
        public string? Designation { get; set; }

        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        public Company? Company { get; set; }
        public Department? Department { get; set; }
    }
}

