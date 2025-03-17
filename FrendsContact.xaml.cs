using System;
using System.Collections.Generic;

namespace MobileApplication
{
    public partial class FrendsContact : ContentPage
    {
        public FrendsContact(int k)
        {
            InitializeComponent();
        }

        private async void SendSMS_Clicked(object sender, EventArgs e)
        {
            /*string phone = emailPhone.Text;
            var message = "Tere tulemast! saadan sõnumi";
            SmsMessage sms = new SmsMessage(message, phone);
            if (phone != null && Sms.Default.IsComposeSupported)
            {
                await Sms.Default.ComposeAsync(sms);
            }
            */
        }

        private async void SendEmail_Clicked(object sender, EventArgs e)
        {
            var message = "Tere tulemast! saadan email";
            EmailMessage eMail = new EmailMessage
            {
                //Subject = emailPhone.Text,
                Body = message,
                BodyFormat = EmailBodyFormat.PlainText,
                //To = new List<string> { emailPhone.Text }
            };

            if (Email.Default.IsComposeSupported)
            {
                await Email.Default.ComposeAsync(eMail);
            }
        }
    }
}
