
namespace AgeCalculator.Views;


public partial class SecondPage : ContentPage
{
    public SecondPage()
    {
        InitializeComponent();
    }
    private async void OnSliderValueChanged(object? sender, ValueChangedEventArgs e)
    {
        LayoutFields.Children.Clear();
        ResultLabel.Text = string.Empty;


        var ageInTen = (int)AgeSlider.Value + 10;
        ResultLabel.Text = $"In ten years you will be {ageInTen} years old.";
        AgeLabel.Text = $"Age: {(int)AgeSlider.Value}";

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