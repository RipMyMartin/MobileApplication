using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MobileApplication
{
    public partial class FrendsContact : ContentPage
    {
        public FrendsContact(int k)
        {
            InitializeComponent();
        }

        private void Sc_OnChange(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                imageTableView.IsVisible = true;
                toggleLabel.Text = "Näita vähem"; 
            }
            else
            {
                imageTableView.IsVisible = false;
                toggleLabel.Text = "Näita veel"; 
            }
        }

        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            var phoneNumber = phoneEntry.Text; 
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                PhoneDialer.Open(phoneNumber);
            }
            else
            {
                await DisplayAlert("Viga", "Telefoninumber puudub", "OK");
            }
        }

        private async void SendSmsButton_Clicked(object sender, EventArgs e)
        {
            var phoneNumber = phoneEntry.Text; 
            var message = messageEntry.Text; 

            if (!string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(message))
            {
                await Sms.ComposeAsync(new SmsMessage(message, phoneNumber));
            }
            else
            {
                await DisplayAlert("Viga", "Telefoninumber või sõnum puudub", "OK");
            }
        }

        private async void SendEmailButton_Clicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var message = messageEntry.Text; 

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(message))
            {
                await Email.ComposeAsync("Teema", message, email);
            }
            else
            {
                await DisplayAlert("Viga", "Email või sõnum puudub", "OK");
            }
        }
    }
}
