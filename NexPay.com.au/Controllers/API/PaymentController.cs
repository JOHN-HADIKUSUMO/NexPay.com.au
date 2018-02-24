using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.Http;
using log4net;
using NexPay.com.au.Models;
using NexPay.com.au.Business;

namespace NexPay.com.au.Controllers.API
{
    [RoutePrefix("API/PAYMENT")]
    public class PaymentController : ApiController
    {
        private static ILog log = LogManager.GetLogger("PaymentController");
        [AcceptVerbs("POST")]
        [Route("SAVE")]
        public async Task<IHttpActionResult> Save(PaymentModel model)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["Path"].ToString();
                var status = await Task.Run(() => new { status = Payment.SaveToDisk(path, model) });
                log.Info("Payment has been processed successfully");
                return Ok(status);
            }
            catch(Exception ex)
            {
                log.Error("Payment was fail to be processed");
                return InternalServerError();
            }            
        }
    }
}