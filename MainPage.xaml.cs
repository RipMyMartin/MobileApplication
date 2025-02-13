namespace MobileApplication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var valgus_btn = new Button
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.FromRgb(255, 255, 255),
            };

            valgus_btn.Clicked += Valgus_btn_Clicked;

            Content = new StackLayout
            {
                Margin = 20,
                Children =
                {
                    valgus_btn
                }
            };
        }

        private async void Valgus_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoorpage());
        }
    }
}
