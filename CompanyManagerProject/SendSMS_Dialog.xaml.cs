using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows;
using System.Web;

namespace CompanyManagerProject
{
    public partial class SendSMS_Dialog : Window
    {
        public SendSMS_Dialog()
        {
            InitializeComponent();
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            SendSMS();
        }

        private string SendSMS()
        {
            String message = HttpUtility.UrlEncode(TxtMessage.Text);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "eBStkkopVbI-eEKRcZHXiCNPRKnmFNTtkVxgkgqoDh"},
                {"numbers" , TxtPhoneNo.Text},
                {"message" , message},
                {"sender" , "Your Company"},
                //{"test", "true" }
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }

        //private string SendSMS()
        //{
        //    String result;
        //    string apiKey = "eBStkkopVbI-eEKRcZHXiCNPRKnmFNTtkVxgkgqoDh";
        //    string numbers = TxtPhoneNo.Text;
        //    string message = TxtMessage.Text;
        //    string sendFrom = "Your Company";

        //    String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sendFrom;
        //    //refer to parameters to complete correct url string

        //    StreamWriter myWriter = null;
        //    HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

        //    objRequest.Method = "POST";
        //    objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
        //    objRequest.ContentType = "application/x-www-form-urlencoded";
        //    try
        //    {
        //        myWriter = new StreamWriter(objRequest.GetRequestStream());
        //        myWriter.Write(url);
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //    finally
        //    {
        //        myWriter.Close();
        //    }

        //    HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //    using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        //    {
        //        result = sr.ReadToEnd();
        //        // Close and clean up the StreamReader
        //        sr.Close();
        //    }
        //    return result;
        //}
    }
    
}
