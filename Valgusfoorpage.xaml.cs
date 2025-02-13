
using Microsoft.Maui.Graphics;  // For .NET MAUI

namespace MobileApplication
{
    public partial class Valgusfoorpage : ContentPage
    {
        Frame fr;
        Frame fr2;
        Frame fr3;
        Label lbl;
        Label lbl1;
        Label lbl2;
        Label lbl3;
        Button btn;
        Button btn1;
        Label timerLabel;
        bool bl = false;

        public Valgusfoorpage()
        {
            lbl = new Label()
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.FromRgb(0, 0, 0),
                TextColor = Color.FromRgb(255, 255, 255)
            };

            lbl1 = new Label()
            {
                Text = "Punane",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            fr = new Frame
            {
                Content = lbl1,
                WidthRequest = 150,
                HeightRequest = 150,
                BackgroundColor = Color.FromRgb(128, 128, 128),
                CornerRadius = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            lbl2 = new Label()
            {
                Text = "Kollane",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            fr2 = new Frame
            {
                Content = lbl2,
                WidthRequest = 150,
                HeightRequest = 150,
                BackgroundColor = Color.FromRgb(128, 128, 128),
                CornerRadius = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            lbl3 = new Label()
            {
                Text = "Roheline",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            fr3 = new Frame
            {
                Content = lbl3,
                WidthRequest = 150,
                HeightRequest = 150,
                BackgroundColor = Color.FromRgb(128, 128, 128),
                CornerRadius = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            btn = new Button
            {
                Text = "Sisse",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start
            };

            btn.Clicked += Btn_Clicked;

            btn1 = new Button
            {
                Text = "Välja",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End
            };

            btn1.Clicked += Btn1_Clicked;

            timerLabel = new Label
            {
                Text = "00:00",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout st = new StackLayout
            {
                Children =
                    {
                        lbl, fr, fr2, fr3, timerLabel,
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                btn, btn1
                            }
                        }
                    }
            };

            Content = st;
        }

        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            bl = false;
            fr.BackgroundColor = Color.FromRgb(128, 128, 128);
            fr2.BackgroundColor = Color.FromRgb(128, 128, 128);
            fr3.BackgroundColor = Color.FromRgb(128, 128, 128);
            lbl1.Text = "Punane";
            lbl2.Text = "Kollane";
            lbl3.Text = "Roheline";

            await DisplayAlert("Valgusfoor", "Valgusfoor on välja lülitatud.", "OK");
        }
        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Valgusfoor", "Valgusfoor on sisse lülitatud.", "OK");
            bl = true;
            while (bl)
            {
                fr.BackgroundColor = Color.FromRgb(255, 0, 0);
                lbl1.Text = "STOP!";
                for (int i = 3; i > 0; i--)
                {
                    timerLabel.Text = $"{i:D2}:00";
                    await Task.Delay(1000);
                }
                timerLabel.Text = "00:00";
                if (!bl) break;
                fr.BackgroundColor = Color.FromRgb(128, 128, 128);
                lbl1.Text = "Punane";
                fr2.BackgroundColor = Color.FromRgb(255, 255, 0);
                lbl2.Text = "OOTA!";
                for (int i = 3; i > 0; i--)
                {
                    timerLabel.Text = $"{i:D2}:00";
                    await Task.Delay(1000);
                }
                timerLabel.Text = "00:00";
                if (!bl) break;
                fr2.BackgroundColor = Color.FromRgb(128, 128, 128);
                lbl2.Text = "Kollane";
                fr3.BackgroundColor = Color.FromRgb(0, 153, 0);
                lbl3.Text = "MINE!";
                for (int i = 3; i > 0; i--)
                {
                    timerLabel.Text = $"{i:D2}:00";
                    await Task.Delay(1000);
                }
                timerLabel.Text = "00:00";
                if (!bl) break;
                fr3.BackgroundColor = Color.FromRgb(128, 128, 128);
                lbl3.Text = "Roheline";
                fr.BackgroundColor = Color.FromRgb(255, 0, 0);
                lbl1.Text = "STOP!";
            }
        }

        //contoll
}
}