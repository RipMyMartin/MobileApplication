namespace MobileApplication;

internal class Menu : ContentPage
{
    List<ContentPage> pages = new List<ContentPage>() { new MainPage(0), new Valgusfoorpage(1), new RGB_mudel(2), new Lumememm(3), new TripsTrapsTrull(4) };
    List<string> txt = new List<string> { "Kodu", "Valgusfoor", "RGB Mudel", "Lumememm", "TripsTrapsTrull" };
    List<Button> btns = new List<Button>();
    public Menu()
	{
        StackLayout stackLayout = new StackLayout
        {
            Padding = 20,
        };

        for (int i = 0; i < pages.Count; i++)
        {
            Button btn = new Button
            {
                Text = txt[i],
                BackgroundColor = Colors.Blue,
                TextColor = Colors.White,
                FontSize = 28,
                CornerRadius = 5,
                Margin = 5,
            };
            btn.BindingContext = i;
            btns.Add(btn);
            btn.Clicked += Btn_Clicked;

            stackLayout.Children.Add(btn);
        }

        Content = stackLayout;
    }
    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        Button button = (Button)sender;
        int i = (int)button.BindingContext; 
        await Navigation.PushAsync(pages[i]);
    }
}
