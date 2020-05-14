using Laconic;
using xf = Xamarin.Forms;

namespace KickassUI.Banking.Pages
{
    public static class Login 
    {
        static View DigitButton(string digit, string letters) => new StackLayout
        {
            Padding = new xf.Thickness(0, 8),
            BackgroundColor = xf.Color.FromHex("#f3f3f3"),
            ["digit"] = new Label
            {
                Text = digit,
                HorizontalTextAlignment = xf.TextAlignment.Center,
                TextColor = xf.Color.FromHex("5d5d5d"),
                FontSize = 20,
                FontFamily = Fonts.PoppinsBold
            },
            ["letters"] = new Label
            {
                Text = letters,
                HorizontalTextAlignment = xf.TextAlignment.Center,
                TextColor = xf.Color.FromHex("bdbdbd"),
                FontSize = 14,
                FontFamily = Fonts.PoppinsRegular
            },
            GestureRecognizers = { new TapGestureRecognizer { Tapped = () => Signal.Send("showOverview") }}
        };

        static View SymbolButton(string text) => new StackLayout
        {
            Spacing = 0,
            Padding = new xf.Thickness(0, 8),
            BackgroundColor = xf.Color.FromHex("f3f3f3"),
            ["lbl"] = new Label
            {
                Text = text,
                HorizontalTextAlignment = xf.TextAlignment.Center,
                VerticalTextAlignment = xf.TextAlignment.Center,
                VerticalOptions = xf.LayoutOptions.CenterAndExpand,
                TextColor = xf.Color.FromHex("5d5d5d"),
                FontSize = 28,
                FontFamily = Fonts.FontAwesomeSolid
            }
        };

        static View Numpad() => new Grid
        {
            RowSpacing = 2,
            ColumnSpacing = 2,
            BackgroundColor = xf.Color.White,
            Margin = new xf.Thickness(24, 0),
            ["1"] = DigitButton("1", ""),
            ["2", column: 1] = DigitButton("2", "ABC"),
            ["3", column: 2] = DigitButton("3", "DEF"),
            ["4", 1] = DigitButton("4", "GHI"),
            ["5", 1, 1] = DigitButton("5", "JKL"),
            ["6", 1, 2] = DigitButton("6", "MNO"),
            ["7", 2] = DigitButton("7", "PQRS"),
            ["8", 2, 1] = DigitButton("8", "TUV"),
            ["9", 2, 2] = DigitButton("9", "WXYZ"),
            ["happyface", 3] = SymbolButton(""),
            ["0", 3, 1] = DigitButton("0", ""),
            ["back", 3, 2] = SymbolButton("\uf55a")
        };

        static Label Text(string text, double fontSize, xf.Thickness margin, double opacity = 1) => new Label
        {
            Text = text,
            HorizontalTextAlignment = xf.TextAlignment.Center,
            TextColor = xf.Color.White,
            Opacity = opacity,
            FontSize = fontSize,
            FontFamily = Fonts.PoppinsRegular,
            Margin = margin
        };

        public static Grid Body() => new Grid
        {
            RowDefinitions = "*, Auto",
            ["bg", rowSpan: 2] = new Image {Source = "background.jpg", Aspect = xf.Aspect.AspectFill},
            ["content"] = new Grid
            {
                RowSpacing = 0,
                ["header"] = new StackLayout
                {
                    VerticalOptions = xf.LayoutOptions.Center,
                    Spacing = 0,
                    ["name"] = Text("J. Doe", 28, new xf.Thickness(0, 24, 0, 0)),
                    ["accNo"] = Text("NL ABNA 55 *** ** *3 293", 14, 0),
                },
                ["PIN", row: 1] = new StackLayout
                {
                    VerticalOptions = xf.LayoutOptions.Start,
                    Spacing = 0,
                    ["prompt"] = Text("Inloggen met je identificatiecode", 16, 0, 0.7),
                    ["dots"] = new Label
                    {
                        Text = "     ",
                        HorizontalTextAlignment = xf.TextAlignment.Center,
                        Margin = new xf.Thickness(0, 8, 0, 0),
                        TextColor = xf.Color.White,
                        FontSize = 32,
                        FontFamily = Fonts.FontAwesomeRegular,
                    }
                }
            },
            ["numpad", row: 1] = Numpad()
        };

        public static Button LeftTitleBarButton() => new Button
        {
            Text = "",
            Margin = new xf.Thickness(8, 0, 0, 0),
            FontFamily = Fonts.FontAwesomeSolid,
            VerticalOptions = xf.LayoutOptions.Center,
            TextColor = xf.Color.White,
            BackgroundColor = xf.Color.FromHex("099494"),
            Padding = 0,
            WidthRequest = 28,
            HeightRequest = 28,
            CornerRadius = 14,
            FontSize = 14
        };

        public static Button RightTitleBarButton() => new Button
        {
            Text = "Scan en betaal",
            VerticalOptions = xf.LayoutOptions.Center,
            Padding = new xf.Thickness(16, 0),
            TextColor = xf.Color.FromHex("5d5d5d"),
            BackgroundColor = xf.Color.FromHex("f8f8f8"),
            HeightRequest = 36,
            CornerRadius = 4,
            FontSize = 11,
            FontFamily = Fonts.PoppinsRegular
        };
    }
}