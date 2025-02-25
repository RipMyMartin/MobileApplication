using Microsoft.Maui.Controls.Shapes;

namespace MobileApplication;

public partial class RGB_mudel : ContentPage
{
    Border ColorBox;
    Border ColorCodeBox;
    Label ColorCodeLabel;
    Frame TitleBar;
    Label RedLabel;
    Slider RedSlider;
    Label GreenLabel;
    Slider GreenSlider;
    Label BlueLabel;
    Slider BlueSlider;
    Entry ColorCodeEntry;

    AbsoluteLayout MainBody;

    public RGB_mudel(int k)
    {
        Title = "";

        TitleBar = new Frame
        {
            BackgroundColor = Colors.LightGray,
            Content = new Label
            {
                Text = "RGB Model",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            },
            CornerRadius = 0,
            Padding = 0,
        };

        RedLabel = new Label
        {
            BackgroundColor = Color.FromRgb(255, 255, 255),
            Text = "Red = 0.0%",
        };
        RedSlider = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
        };

        GreenLabel = new Label
        {
            BackgroundColor = Color.FromRgb(255, 255, 255),
            Text = "Green = 0.0%",
        };
        GreenSlider = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
        };

        BlueLabel = new Label
        {
            BackgroundColor = Color.FromRgb(255, 255, 255),
            Text = "Blue = 0.0%",
        };
        BlueSlider = new Slider
        {
            Minimum = 0,
            Maximum = 255,
            Value = 0,
        };

        ColorBox = new Border
        {
            BackgroundColor = Color.FromRgb(0, 0, 0),
            Stroke = Color.FromRgb(0, 0, 0),
            StrokeThickness = 4,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(0, 0, 0, 0)
            },
        };

        ColorCodeLabel = new Label
        {
            Text = "#000000",
            TextColor = Colors.Black,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            Padding = 4,
        };

        ColorCodeBox = new Border
        {
            Content = ColorCodeLabel,
            BackgroundColor = Colors.LightGray,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(4, 4, 4, 4)
            },
        };

        ColorCodeEntry = new Entry
        {
            Placeholder = "Enter Hex Code (#RRGGBB)",
            Text = "#000000",
            Keyboard = Keyboard.Default,
            BackgroundColor = Colors.White,
            TextColor = Colors.Black,
            HorizontalOptions = LayoutOptions.Center,
        };

        RedSlider.ValueChanged += Sl_Value_Changed;
        GreenSlider.ValueChanged += Sl_Value_Changed;
        BlueSlider.ValueChanged += Sl_Value_Changed;
        ColorCodeEntry.TextChanged += ColorCodeEntry_TextChanged;

        MainBody = new AbsoluteLayout { Children = { RedLabel, RedSlider, GreenLabel, GreenSlider, BlueLabel, BlueSlider, ColorCodeBox, ColorBox, ColorCodeEntry, TitleBar } };

        int CenterPoint = 40;

        AbsoluteLayout.SetLayoutBounds(TitleBar, new Rect(0, 0, 400, 50));
        AbsoluteLayout.SetLayoutBounds(ColorBox, new Rect(CenterPoint, 100, 300, 300));
        AbsoluteLayout.SetLayoutBounds(ColorCodeBox, new Rect(150, 400, 100, 40));
        AbsoluteLayout.SetLayoutBounds(ColorCodeEntry, new Rect(150, 450, 200, 40));
        AbsoluteLayout.SetLayoutBounds(RedLabel, new Rect(CenterPoint, 500, 300, 60));
        AbsoluteLayout.SetLayoutBounds(RedSlider, new Rect(CenterPoint, 500, 300, 60));
        AbsoluteLayout.SetLayoutBounds(GreenLabel, new Rect(CenterPoint, 550, 300, 60));
        AbsoluteLayout.SetLayoutBounds(GreenSlider, new Rect(CenterPoint, 550, 300, 60));
        AbsoluteLayout.SetLayoutBounds(BlueLabel, new Rect(CenterPoint, 600, 300, 60));
        AbsoluteLayout.SetLayoutBounds(BlueSlider, new Rect(CenterPoint, 600, 300, 60));

        Content = MainBody;
    }

    private void Sl_Value_Changed(object sender, ValueChangedEventArgs e)
    {
        if (sender == RedSlider) { RedLabel.Text = String.Format("Red = {0:F1}%", ((float)e.NewValue / 255.0) * 100); }
        if (sender == GreenSlider) { GreenLabel.Text = String.Format("Green = {0:F1}%", ((float)e.NewValue / 255.0) * 100); }
        if (sender == BlueSlider) { BlueLabel.Text = String.Format("Blue = {0:F1}%", ((float)e.NewValue / 255.0) * 100); }

        UpdateColorBoxAndCode();
    }
    private void ColorCodeEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (IsValidHexColor(e.NewTextValue))
        {
            ColorCodeLabel.Text = e.NewTextValue;
            ColorBox.BackgroundColor = Color.FromHex(e.NewTextValue);
        }
    }

    private bool IsValidHexColor(string hex)
    {
        if (hex.StartsWith("#") && hex.Length == 7)
        {
            try
            {
                var color = Color.FromHex(hex);
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }

    private void UpdateColorBoxAndCode()
    {
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        string hexColor = $"#{red:X2}{green:X2}{blue:X2}";
        ColorCodeLabel.Text = hexColor;
        ColorBox.BackgroundColor = Color.FromRgb(red, green, blue);
    }
}
