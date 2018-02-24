using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NexPay.com.au.Models;

namespace NexPay.com.au.Business
{
    public static class Payment
    {
        public static bool SaveToDisk(string path,PaymentModel model)
        {
            bool status = true;
            try
            {
                string fullpath = path + @"\Payment.txt";
                string content = model.BSBNo + "|" + model.AccountNo + "|" + model.AccountName + "|" + model.Reference + "|" + model.Amount + Environment.NewLine;
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(content);
                FileStream stream = new FileStream(fullpath, File.Exists(fullpath) ? FileMode.Append:FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}
