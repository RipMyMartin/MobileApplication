using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace MobileApplication;
public partial class TripsTrapsTrull : ContentPage
{
    private string _xSymbol = "X";
    private string _oSymbol = "O";
    private int _boardSize = 3;
    private Button[,] _buttons;
    private bool _isXTurn = true;
    private Color _defaultButtonColor = Colors.LightGray;


    public TripsTrapsTrull(int k)
    {
        InitializeComponent();
        CreateBoard();
    }

    private void CreateBoard()
    {
        BoardGrid.Children.Clear();
        BoardGrid.RowDefinitions.Clear();
        BoardGrid.ColumnDefinitions.Clear();

        _buttons = new Button[_boardSize, _boardSize];

        for (int i = 0; i < _boardSize; i++)
        {
            BoardGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            BoardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        for (int row = 0; row < _boardSize; row++)
        {
            for (int col = 0; col < _boardSize; col++)
            {
                var cellButton = new Button
                {
                    FontSize = 48,
                    TextColor = Colors.Black,
                    BackgroundColor = _defaultButtonColor,
                    BorderColor = Colors.Black,
                    BorderWidth = 2,
                    Text = ""
                };

                Grid.SetRow(cellButton, row);
                Grid.SetColumn(cellButton, col);

                cellButton.Clicked += CellButton_Clicked;
                BoardGrid.Children.Add(cellButton);
                _buttons[row, col] = cellButton;
            }
        }
    }

    private void CellButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && string.IsNullOrEmpty(button.Text))
        {
            button.Text = _isXTurn ? _xSymbol : _oSymbol;
            _isXTurn = !_isXTurn;
            CheckWin();
        }
    }

    private void CheckWin()
    {
        for (int i = 0; i < _boardSize; i++)
        {
            if (Enumerable.Range(0, _boardSize).All(j => _buttons[i, j].Text == _xSymbol))
            {
                DisplayWin(_xSymbol);
                return;
            }
            if (Enumerable.Range(0, _boardSize).All(j => _buttons[i, j].Text == _oSymbol))
            {
                DisplayWin(_oSymbol);
                return;
            }
        }

        for (int j = 0; j < _boardSize; j++)
        {
            if (Enumerable.Range(0, _boardSize).All(i => _buttons[i, j].Text == _xSymbol))
            {
                DisplayWin(_xSymbol);
                return;
            }
            if (Enumerable.Range(0, _boardSize).All(i => _buttons[i, j].Text == _oSymbol))
            {
                DisplayWin(_oSymbol);
                return;
            }
        }

        if (Enumerable.Range(0, _boardSize).All(i => _buttons[i, i].Text == _xSymbol) ||
            Enumerable.Range(0, _boardSize).All(i => _buttons[i, _boardSize - 1 - i].Text == _xSymbol))
        {
            DisplayWin(_xSymbol);
            return;
        }
        if (Enumerable.Range(0, _boardSize).All(i => _buttons[i, i].Text == _oSymbol) ||
            Enumerable.Range(0, _boardSize).All(i => _buttons[i, _boardSize - 1 - i].Text == _oSymbol))
        {
            DisplayWin(_oSymbol);
            return;
        }
    }

    private async void DisplayWin(string winner)
    {
        await DisplayAlert("Palju onne", $"Voitnud {winner}!", "OK");
        NewGameClicked(null, null);
    }

    private async void OnChangeBoardSizeClicked(object sender, EventArgs e)
    {
        string result = await DisplayActionSheet("Valige valja suurust ", "tuhista", null, "3", "4", "5", "6", "7", "8", "9");
        if (int.TryParse(result, out int size))
        {
            _boardSize = size;
            CreateBoard();
        }
    }

    private async void OnChangeSymbolsClicked(object sender, EventArgs e)
    {
        string newX = await DisplayActionSheet("Vali sumbol X:", "Tuhista", null, "X", "A", "1", "*", "#");
        string newO = await DisplayActionSheet("Vali sumbol O:", "Tuhista", null, "O", "B", "2", "@", "$");

        if (!string.IsNullOrWhiteSpace(newX)) _xSymbol = newX;
        if (!string.IsNullOrWhiteSpace(newO)) _oSymbol = newO;
    }

        private async void OnChangeColorClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Valige teema",
                "Tuhista", null,
                "Default",
                "Dark"
                );

        switch (action)
            {
            case "Defauld":
                Application.Current.UserAppTheme = AppTheme.Light;
                _defaultButtonColor = Colors.LightGray;
                break;
            case "Dark":
                Application.Current.UserAppTheme = AppTheme.Dark;
                _defaultButtonColor = Colors.DarkGray;
                break;

        }
    }

    private void NewGameClicked(object sender, EventArgs e)
    {
        CreateBoard();
        _isXTurn = true;
    }
}