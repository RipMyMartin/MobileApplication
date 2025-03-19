namespace MobileApplication
{
    public partial class FrendsContact : ContentPage
    {
        //private string imageFilePath;
        private string photoFilePath;

        private List<string> greetings = new List<string>
        {
            "Head uut aastat! Soovin sulle kõike head!",
            "Rõõmsaid pühi ja palju õnne!",
            "Olgu su aasta täis õnne, armastust ja edu!",
            "Soovin sulle rahu ja armastust uuel aastal!",
            "Õnnelikku ja edukat uut aastat!"
        };
        public FrendsContact(int k)
        {
            InitializeComponent();
        }

        private async void Sc_OnChange(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                imageTableView.IsVisible = true;
                toggleLabel.Text = "Näita";
            }
            else
            {
                imageTableView.IsVisible = false;
                toggleLabel.Text = "Peida";
            }
        }
        private async void TakePhotoButton_Clicked(object sender, EventArgs e)
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                photoFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newFileStream = File.OpenWrite(photoFilePath))
                {
                    await stream.CopyToAsync(newFileStream);
                }

                imageTableView.IsVisible = true;
                var imageSource = ImageSource.FromFile(photoFilePath);
                var imageCell = new ImageCell
                {
                    ImageSource = imageSource,
                    Text = nameEntry.Text,
                    Detail = "Pilt tehtud kaameraga"
                };
                var section = new TableSection();
                section.Add(imageCell);
                imageTableView.Root.Add(section);
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

            if (string.IsNullOrEmpty(photoFilePath))
            {
                if (!string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(message))
                {
                    await Sms.ComposeAsync(new SmsMessage(message, phoneNumber));
                }
                else
                {
                    await DisplayAlert("Viga", "Telefoninumber või sõnum puudub", "OK");
                }
            }
            else
            {
                var fullMessage = $"{message}\nPilt: {photoFilePath}";
                if (!string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(fullMessage))
                {
                    await Sms.ComposeAsync(new SmsMessage(fullMessage, phoneNumber));
                }
                else
                {
                    await DisplayAlert("Viga", "Telefoninumber või sõnum puudub", "OK");
                }
            }
        }

        private async void SendEmailButton_Clicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var message = messageEntry.Text;

            if (string.IsNullOrEmpty(photoFilePath))
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(message))
                {
                    await Email.ComposeAsync("Pühadetervitus", message, email);
                }
                else
                {
                    await DisplayAlert("Viga", "Email või sõnum puudub", "OK");
                }
            }
            else
            {
                var emailMessage = new EmailMessage
                {
                    Subject = "Pühadetervitus",
                    Body = message,
                    To = new List<string> { email }
                };

                var attachment = new EmailAttachment(photoFilePath);
                emailMessage.Attachments.Add(attachment);

                await Email.ComposeAsync(emailMessage);
            }
        }

        /*
        private async void AddImageButton_Clicked(object sender, EventArgs e)
        {
            var file = await MediaPicker.PickPhotoAsync();
            if (file != null)
            {
                imageFilePath = Path.Combine(FileSystem.CacheDirectory, file.FileName);
                using (var stream = await file.OpenReadAsync())
                using (var newFileStream = File.OpenWrite(imageFilePath))
                {
                    await stream.CopyToAsync(newFileStream);
                }

                greetingImage.Source = ImageSource.FromFile(imageFilePath);
            }
        }
        */

        private async void SendRandomGreetingButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            string selectedGreeting = greetings[random.Next(greetings.Count)];

            string contactMethod = await DisplayActionSheet("Vali saatmisviis", "Tühista", null, "Saada SMS", "Saada E-post");

            if (contactMethod == "Saada SMS")
            {
                var phoneNumber = phoneEntry.Text;
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    await Sms.ComposeAsync(new SmsMessage(selectedGreeting, phoneNumber));
                    await DisplayAlert("Õnnestus", "Tervitus saadetud SMS-iga!", "OK");
                }
                else
                {
                    await DisplayAlert("Viga", "Telefoninumber puudub", "OK");
                }
            }
            else if (contactMethod == "Saada E-post")
            {
                var email = emailEntry.Text;
                if (!string.IsNullOrEmpty(email))
                {
                    await Email.ComposeAsync("Pühadetervitus", selectedGreeting, email);
                    await DisplayAlert("Õnnestus", "Tervitus saadetud e-posti teel!", "OK");
                }
                else
                {
                    await DisplayAlert("Viga", "E-posti aadress puudub", "OK");
                }
            }
        }
        /*
        private async void ResetPhoto(object sender, EventArgs e)
        {
            photoFilePath = null;
            imageTableView.IsVisible = false;
        }
        */
    }
}
