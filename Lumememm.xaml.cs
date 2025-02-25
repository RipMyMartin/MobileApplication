using Microsoft.Maui.Layouts;

namespace MobileApplication;

public partial class Lumememm : ContentPage
{
    StackLayout st;
    Label lbl;
    Button btn, btnColor;
    Stepper stp;
    Slider sld, sld1, sld2, sld3;
    Frame box, box2, box3_vedro;
    AbsoluteLayout abs;
    Random rnd;

    public Lumememm(int v)
    {
    //    // Updated BackgroundColor
    //    BackgroundColor = Color.FromRgb(245, 245, 245);

    //    // Styling for box1
    //    box = new Frame
    //    {
    //        CornerRadius = 100,
    //        BackgroundColor = Color.FromRgb(0, 122, 255),
    //        WidthRequest = 140,
    //        HeightRequest = 140,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.CenterAndExpand,
    //        HasShadow = true,
    //        BorderColor = Color.FromRgb(0, 122, 255),
    //        Padding = new Thickness(10)
    //    };

    //    // Styling for box2
    //    box2 = new Frame
    //    {
    //        CornerRadius = 150,
    //        BackgroundColor = Color.FromRgb(0, 150, 136),
    //        WidthRequest = 200,
    //        HeightRequest = 200,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.CenterAndExpand,
    //        HasShadow = true,
    //        BorderColor = Color.FromRgb(0, 150, 136),
    //        Padding = new Thickness(15)
    //    };

    //    // Styling for the "vedro" (bucket)
    //    box3_vedro = new Frame
    //    {
    //        BackgroundColor = Color.FromRgb(255, 87, 34),
    //        WidthRequest = 130,
    //        HeightRequest = 110,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.FillAndExpand,
    //        CornerRadius = 25,
    //        HasShadow = true,
    //        BorderColor = Color.FromRgb(255, 87, 34),
    //        Padding = new Thickness(5)
    //    };

    //    lbl = new Label { Text = "Läbipaistvus: 100%", TextColor = Color.Black, FontSize = 20, HorizontalOptions = LayoutOptions.Center };

    //    // Updated Slider styling
    //    sld = new Slider
    //    {
    //        Minimum = 0,
    //        Maximum = 1,
    //        Value = 1,
    //        MinimumTrackColor = Color.FromRgb(0, 122, 255),
    //        MaximumTrackColor = Color.Gray,
    //        ThumbColor = Color.FromRgb(0, 122, 255),
    //        HorizontalOptions = LayoutOptions.FillAndExpand
    //    };
    //    sld.ValueChanged += Sld_ValueChanged;

    //    // Updated Button styling
    //    btn = new Button
    //    {
    //        Text = "Peida",
    //        BackgroundColor = Color.FromRgb(0, 122, 255),
    //        TextColor = Colors.White,
    //        BorderRadius = 30,
    //        Padding = new Thickness(15),
    //        HorizontalOptions = LayoutOptions.Center
    //    };
    //    btn.Clicked += Btn_Clicked;

    //    // Random Color Button with updated style
    //    btnColor = new Button
    //    {
    //        Text = "Random värv",
    //        BackgroundColor = Color.FromRgb(0, 150, 136),
    //        TextColor = Colors.White,
    //        BorderRadius = 30,
    //        Padding = new Thickness(15),
    //        HorizontalOptions = LayoutOptions.Center
    //    };
    //    btnColor.Clicked += BtnColor_Clicked;

    //    // Stepper styling
    //    stp = new Stepper
    //    {
    //        Minimum = -50,
    //        Maximum = 50,
    //        Increment = 5,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.EndAndExpand,
    //        BackgroundColor = Color.Transparent,
    //        TextColor = Color.FromRgb(0, 122, 255)
    //    };
    //    stp.ValueChanged += Stp_ValueChanged;

    //    // Slider styling for translations
    //    sld1 = new Slider
    //    {
    //        WidthRequest = 300,
    //        Minimum = -200,
    //        Maximum = 200,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.EndAndExpand,
    //        MinimumTrackColor = Color.FromRgb(0, 122, 255),
    //        ThumbColor = Color.FromRgb(0, 122, 255)
    //    };
    //    sld1.ValueChanged += Sld1_ValueChanged;

    //    sld2 = new Slider
    //    {
    //        WidthRequest = 300,
    //        Minimum = -200,
    //        Maximum = 200,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.EndAndExpand,
    //        MinimumTrackColor = Color.FromRgb(0, 122, 255),
    //        ThumbColor = Color.FromRgb(0, 122, 255)
    //    };
    //    sld2.ValueChanged += Sld2_ValueChanged;

    //    sld3 = new Slider
    //    {
    //        WidthRequest = 300,
    //        Minimum = -200,
    //        Maximum = 200,
    //        HorizontalOptions = LayoutOptions.Center,
    //        VerticalOptions = LayoutOptions.EndAndExpand,
    //        MinimumTrackColor = Color.FromRgb(0, 122, 255),
    //        ThumbColor = Color.FromRgb(0, 122, 255)
    //    };
    //    sld3.ValueChanged += Sld3_ValueChanged;

    //    st = new StackLayout { Children = { lbl, sld, btn, btnColor, stp, sld1, sld2, sld3 }, Spacing = 10 };

    //    abs = new AbsoluteLayout { Children = { st, box2, box, box3_vedro } };

    //    // Adjust layout bounds
    //    AbsoluteLayout.SetLayoutBounds(box3_vedro, new Rect(0.5, 0.03, 130, 110));
    //    AbsoluteLayout.SetLayoutFlags(box3_vedro, AbsoluteLayoutFlags.PositionProportional);

    //    AbsoluteLayout.SetLayoutBounds(box, new Rect(0.5, 0.1, 200, 245));
    //    AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.PositionProportional);

    //    AbsoluteLayout.SetLayoutBounds(box2, new Rect(0.5, 0.37, 200, 280));
    //    AbsoluteLayout.SetLayoutFlags(box2, AbsoluteLayoutFlags.PositionProportional);

    //    AbsoluteLayout.SetLayoutBounds(st, new Rect(0.5, 0.95, 300, 280));
    //    AbsoluteLayout.SetLayoutFlags(st, AbsoluteLayoutFlags.PositionProportional);

    //    Content = abs;
    //}

    //private void Sld3_ValueChanged(object sender, ValueChangedEventArgs e) => box.TranslationX = e.NewValue;
    //private void Sld2_ValueChanged(object sender, ValueChangedEventArgs e) => box2.TranslationX = e.NewValue;
    //private void Sld1_ValueChanged(object sender, ValueChangedEventArgs e) => box3_vedro.TranslationX = e.NewValue;

    //private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    box.TranslationX = e.NewValue;
    //    box3_vedro.TranslationX = e.NewValue;
    //    box2.TranslationX = e.NewValue;
    //}

    //private void BtnColor_Clicked(object sender, EventArgs e)
    //{
    //    rnd = new Random();
    //    box3_vedro.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
    //    box.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
    //    box2.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
    //}

    //private void Btn_Clicked(object sender, EventArgs e)
    //{
    //    if (box.IsVisible && box2.IsVisible && box3_vedro.IsVisible)
    //    {
    //        box.IsVisible = false;
    //        box2.IsVisible = false;
    //        box3_vedro.IsVisible = false;
    //        sld.Value = 0;
    //    }
    //}

    //private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    box.IsVisible = true;
    //    box2.IsVisible = true;
    //    box3_vedro.IsVisible = true;
    //    lbl.Text = $"Läbipaistmatus: {e.NewValue * 100:F1}%";
    //    box3_vedro.Opacity = e.NewValue;
    //    box.Opacity = e.NewValue;
    //    box2.Opacity = e.NewValue;
    }
}
