using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NexPay.com.au.Models;
using NexPay.com.au.Business;
using NexPay.com.au.Controllers;

namespace NexPay.com.au.UnitTest
{
    [TestClass]
    public class PaymentTest
    {
        [TestMethod]
        public void Save()
        {
            PaymentModel model = new PaymentModel();
            model.BSBNo = "427772";
            model.AccountNo = "90321166";
            model.AccountName = "John Doe";
            model.Reference = "Paying Bill";
            model.Amount = 350.75M;

            Controllers.API.PaymentController paymentController = new Controllers.API.PaymentController();
            paymentController.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(@"http://localhost:56246/API/PAYMENT/SAVE"),
            };

            Task<IHttpActionResult> response = paymentController.Save(model);
            Assert.IsNotNull(response);
        }
    }
}
