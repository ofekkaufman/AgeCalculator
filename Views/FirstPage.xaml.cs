using System;
using Microsoft.Maui.Controls;

namespace AgeCalculator.Views
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object? sender, EventArgs e)
        {
            LayoutFields.Children.Clear();
            ResultLabel.Text = string.Empty;

            // Validate and parse the age input
            if (!int.TryParse(AgeEntry.Text, out var age) || age < 0)
            {
                await DisplayAlertAsync("Invalid age", "Please enter a valid non-negative number for age.", "OK");
                return;
            }

            var ageInTen = age + 10;
            ResultLabel.Text = $"In ten years you will be {ageInTen} years old.";

            var candleCount = ageInTen;

            // Arrange candles into rows of up to 10
            var perRow = 10;
            HorizontalStackLayout? currentRow = null;
            for (int i = 0; i < candleCount; i++)
            {
                if (i % perRow == 0)
                {
                    currentRow = new HorizontalStackLayout { Spacing = 4, HorizontalOptions = LayoutOptions.FillAndExpand };
                    LayoutFields.Children.Add(currentRow);
                }

                currentRow?.Children.Add(new Image
                {
                    Source = "candle.png",
                    HeightRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Aspect = Aspect.AspectFill
                });
            }
        }
    }
}
