using MobileApplication.Country;
using System.Collections.ObjectModel;

namespace MobileApplication;

public partial class CountryList : ContentPage
{
    public ObservableCollection<Riik> EuroopaRiigid { get; } = new();
    public ObservableCollection<Riik> AmeerikaRiigid { get; } = new();
    private ObservableCollection<Riik> Riigid { get; } = new();

    public CountryList(int v)
    {
        InitializeCountries();
        CategorizeCountries();
        BuildContent();
    }

    private void InitializeCountries()
    {
        Riigid.Add(new Riik { Nimi = "Estonia", Pealinn = "Tallinn", Rahvaarv = "345987", Lipp = "eesti.png", Continent = 1 });
        Riigid.Add(new Riik { Nimi = "Canada", Pealinn = "Ottawa", Rahvaarv = "678098", Lipp = "canada.png", Continent = 0 });
    }

    private void CategorizeCountries()
    {
        foreach (var riik in Riigid)
        {
            AddToContinentCollection(riik);
        }
    }

    private void BuildContent()
    {
        Content = new StackLayout
        {
            Children =
            {
                new Label { Text = "Riigid", FontSize = 24, HorizontalOptions = LayoutOptions.Center },
                CreateListView("Euroopa riigid:", EuroopaRiigid),
                CreateListView("Ameerika riigid:", AmeerikaRiigid),
                new Button { Text = "Lisa", Command = new Command(async () => await AddCountry()) },
                new Button { Text = "Kustuta", Command = new Command(DeleteLastCountry) }
            }
        };
    }

    private ListView CreateListView(string header, ObservableCollection<Riik> items)
    {
        return new ListView
        {
            Header = header,
            ItemsSource = items,
            ItemTemplate = new DataTemplate(() => CreateCountryViewCell())
        };
    }

    private ViewCell CreateCountryViewCell()
    {
        var flagImage = new Image { WidthRequest = 50, HeightRequest = 30 };
        flagImage.SetBinding(Image.SourceProperty, "Lipp");

        var nameLabel = new Label { TextColor = Colors.Red, FontSize = 18 };
        nameLabel.SetBinding(Label.TextProperty, "Nimi");

        var capitalLabel = new Label { TextColor = Colors.Green, FontSize = 14 };
        capitalLabel.SetBinding(Label.TextProperty, new Binding("Pealinn", stringFormat: "Selle riigi pealinn on {0}"));

        var infoStack = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 10 };
        infoStack.Children.Add(flagImage);
        infoStack.Children.Add(new StackLayout { Children = { nameLabel, capitalLabel } });

        var editButton = new Button { Text = "Muuda", BackgroundColor = Colors.LightGray };
        editButton.SetBinding(Button.CommandParameterProperty, new Binding("."));
        editButton.Clicked += async (s, e) => await EditCountry((Riik)((Button)s).CommandParameter);

        var grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

        grid.Children.Add(infoStack);
        grid.Children.Add(editButton);
        Grid.SetColumn(editButton, 1);

        return new ViewCell { View = grid };
    }

    private async Task AddCountry()
    {
        string nimi = await DisplayPromptAsync("Sisesta nimi", "Sisesta nimi", keyboard: Keyboard.Default);
        if (Riigid.Any(r => r.Nimi == nimi))
        {
            await DisplayAlert("Viga", "See riik on juba olemas!", "OK");
            return;
        }

        string pealinn = await DisplayPromptAsync("Sisesta pealinn", "Sisesta pealinn", keyboard: Keyboard.Default);
        string rahvaarv = await DisplayPromptAsync("Sisesta rahvaarv", "Sisesta rahvaarv", keyboard: Keyboard.Numeric);
        string kontinent = await DisplayPromptAsync("Vali kontinent", "Euroopa (1) või Ameerika (0)", keyboard: Keyboard.Numeric);

        var photo = await MediaPicker.PickPhotoAsync();
        string img = photo?.FullPath ?? "defaultimage.png";  

        var newRiik = new Riik { 
            Nimi = nimi, 
            Pealinn = pealinn, 
            Rahvaarv = rahvaarv, 
            Lipp = img, 
            Continent = int.Parse(kontinent) 
        };

        Riigid.Add(newRiik);
        if (newRiik.Continent == 1)
            EuroopaRiigid.Add(newRiik);
        else
            AmeerikaRiigid.Add(newRiik);
    }

    private void AddToContinentCollection(Riik riik)
    {
        if (riik.Continent == 1)
            EuroopaRiigid.Add(riik);
        else
            AmeerikaRiigid.Add(riik);
    }

    private void DeleteLastCountry()
    {
        if (EuroopaRiigid.Any())
            EuroopaRiigid.RemoveAt(EuroopaRiigid.Count - 1);
        else if (AmeerikaRiigid.Any())
            AmeerikaRiigid.RemoveAt(AmeerikaRiigid.Count - 1);
    }

    private async Task EditCountry(Riik riik)
    {
        string uusNimi = await DisplayPromptAsync("Muuda nime", "", initialValue: riik.Nimi);
        string uusPealinn = await DisplayPromptAsync("Muuda pealinna", "", initialValue: riik.Pealinn);
        string uusRahvaarv = await DisplayPromptAsync("Muuda rahvaarvu", "", initialValue: riik.Rahvaarv, keyboard: Keyboard.Numeric);
        string uusKontinentInput = await DisplayPromptAsync("Muuda kontinent", "", initialValue: riik.Continent.ToString(), keyboard: Keyboard.Numeric);

        var photo = await MediaPicker.PickPhotoAsync();
        var uusLipp = photo?.FileName ?? riik.Lipp;

        riik.Nimi = uusNimi;
        riik.Pealinn = uusPealinn;
        riik.Rahvaarv = uusRahvaarv;
        riik.Lipp = uusLipp;
        riik.Continent = int.TryParse(uusKontinentInput, out int uusKont) ? uusKont : riik.Continent;

        EuroopaRiigid.Clear();
        AmeerikaRiigid.Clear();
        CategorizeCountries();
    }
}
