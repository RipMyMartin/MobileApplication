using Microsoft.Maui.ApplicationModel;

namespace MobileApplication;

public partial class TripsTrapsTrull : ContentPage
{
    Image img;
    Grid field;
    Button turnbtn, clearbtn;
    Label CrossOrZero;
    static int player;
    int[,] WinOrLose = new int[3, 3];
    static int victor = 0;
    public TripsTrapsTrull(int k)
    {
        Playfield();
        BackgroundColor = Color.FromRgb(241, 140, 78);

        turnbtn = new Button()
        {
            Text = "Turn Decider",
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.EndAndExpand,
        };
        turnbtn.Clicked += turnbtnOnClicked;

        clearbtn = new Button()
        {
            Text = "Restart",
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.EndAndExpand,
        };
        clearbtn.Clicked += clearbtnOnClicked;


        StackLayout BtnLayout = new StackLayout()
        {
            Orientation = StackOrientation.Horizontal,
            Children = { clearbtn, turnbtn }
        };

        CrossOrZero = new Label()
        {
            TextColor = Color.FromRgb(255,255, 255),
        };

        StackLayout MainLayout = new StackLayout()
        {
            Children = { field, BtnLayout, CrossOrZero }
        };

        Content = MainLayout;
    }
    private void Playfield()
    {
        field = new Grid()
        {
            HeightRequest = 400
        };
        for (int i = 0; i < 3; i++)
        {
            field.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            field.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                img = new Image
                {

                    HeightRequest = 125,
                    Source = "blank.png"
                };
                WinOrLose[i, j] = 0;
                var tap = new TapGestureRecognizer();
                tap.Tapped += TapOnTapped;
                field.Children.Add(img, i, j);
                img.GestureRecognizers.Add(tap);
            }
        }
    }

    private void clearbtnOnClicked(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                img = new Image
                {
                    HeightRequest = 125,
                    Source = "blank.png"
                };
                var tap = new TapGestureRecognizer();
                tap.Tapped += TapOnTapped;
                field.Children.Add(img, i, j);
                img.GestureRecognizers.Add(tap);
            }
        }
        turnbtn.Opacity = 1;
        player = 0;
        victor = 0;

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                WinOrLose[y, x] = 0;
            }
        }
    }

    private void turnbtnOnClicked(object sender, EventArgs e)
    {
        Random rnd = new Random();
        player = rnd.Next(1, 3);
        if (player == 1)
        {
            DisplayAlert("Who's first?", "X Begins", "ОK");
        }
        else
        {
            DisplayAlert("Who's first?", "O Begins", "ОK");
        }
        turnbtn.Opacity = 0;

    }

    private void TapOnTapped(object sender, EventArgs e)
    {
        Image img = sender as Image;
        var imageSource = (Image)sender;
        var selectedImage = imageSource.Source as FileImageSource;

        if (selectedImage == "blank.png")
        {
            if (player == 1)
            {
                img.Source = ImageSource.FromFile("x.png");
                WinOrLose[Grid.GetRow(img), Grid.GetColumn(img)] = 1;
                player = 2;
                VictoryCheck();
                Winner();
            }
            else if (player == 2)
            {
                img.Source = ImageSource.FromFile("o.png");
                WinOrLose[Grid.GetRow(img), Grid.GetColumn(img)] = 2;
                player = 1;
                VictoryCheck();
                Winner();
            }
        }
        else
        {
            DisplayAlert("Error", "Occupied", "Ок");
        }
    }
    public int VictoryCheck()
    {
        if (WinOrLose[0, 0] == 1 && WinOrLose[0, 1] == 1 && WinOrLose[0, 2] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[1, 0] == 1 && WinOrLose[1, 1] == 1 && WinOrLose[1, 2] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[2, 0] == 1 && WinOrLose[2, 1] == 1 && WinOrLose[2, 2] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[0, 0] == 1 && WinOrLose[1, 1] == 1 && WinOrLose[2, 2] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[0, 2] == 1 && WinOrLose[1, 1] == 1 && WinOrLose[2, 0] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[0, 0] == 1 && WinOrLose[1, 0] == 1 && WinOrLose[2, 0] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[0, 1] == 1 && WinOrLose[1, 1] == 1 && WinOrLose[2, 1] == 1)
        {
            victor = 1;
        }
        else if (WinOrLose[0, 2] == 1 && WinOrLose[1, 2] == 1 && WinOrLose[2, 2] == 1)
        {
            victor = 1;
        }

        else if (WinOrLose[0, 0] == 2 && WinOrLose[0, 1] == 2 && WinOrLose[0, 2] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[1, 0] == 2 && WinOrLose[1, 1] == 2 && WinOrLose[1, 2] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[2, 0] == 2 && WinOrLose[2, 1] == 2 && WinOrLose[2, 2] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[0, 0] == 2 && WinOrLose[1, 1] == 2 && WinOrLose[2, 2] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[0, 2] == 2 && WinOrLose[1, 1] == 2 && WinOrLose[2, 0] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[0, 0] == 2 && WinOrLose[1, 0] == 2 && WinOrLose[2, 0] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[0, 1] == 2 && WinOrLose[1, 1] == 2 && WinOrLose[2, 1] == 2)
        {
            victor = 2;
        }
        else if (WinOrLose[0, 2] == 2 && WinOrLose[1, 2] == 1 && WinOrLose[2, 2] == 2)
        {
            victor = 2;
        }

        return victor;
    }
    public void Winner()
    {
        victor = VictoryCheck();

        if (victor == 1)
        {
            DisplayAlert("Victory!", "X Won", "ОK");
        }
        else if (victor == 2)
        {
            DisplayAlert("Victory!", "O Won", "ОK");
        }
    }
}