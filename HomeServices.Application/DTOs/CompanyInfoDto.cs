using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.DTOs
{
    public class CompanyInfoDto
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string companyAddress { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Bank { get; set; }
        public string BankAccount { get; set; }
    }
}
