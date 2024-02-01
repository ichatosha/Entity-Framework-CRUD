using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public  class Invoice
    {

        public int Id { get; set; }

        // default empty
        public string CustomerTitle { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        // title + name :
        public string DescriptionName { get; set; } /*=> CustomerTitle + " " + CustomerName;*/

        public decimal Price { get; set; }

        public int Qty { get; set; } /*= 1;*/

        public decimal total { get; set; } /*=> Qty * Price;*/

        public DateTime CreatedDate { get; set; } /* = DateTime.Now;*/
    }
}
