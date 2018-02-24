using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexPay.com.au.Models
{
    public class PaymentModel
    {
        public string BSBNo { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
    }
}
