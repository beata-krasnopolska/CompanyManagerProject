using System;
using System.Net;
using System.Collections.Specialized;
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
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }        
    }
    
}
