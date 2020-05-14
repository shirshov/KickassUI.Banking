using System;
using Laconic;
using xf = Xamarin.Forms;
using iOSPage = Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page;

namespace KickassUI.Banking.Pages
{
    public static class Overview 
    {
        static View Action(string icon, string caption, bool isActive = false) => new Laconic.PancakeView
        {
            HeightRequest = 76,
            WidthRequest = 84,
            CornerRadius = 4,
            Padding = 12,
            HorizontalOptions = xf.LayoutOptions.Start,
            Margin = new xf.Thickness(8, 0),
            VerticalOptions = xf.LayoutOptions.Center,
            BackgroundColor = isActive ? xf.Color.FromHex("005e5c") : xf.Color.FromHex("e0e0e0"),
            Content = new StackLayout
            {
                VerticalOptions = xf.LayoutOptions.Center,
                ["icon"] = new Label
                {
                    FontSize = 24,
                    HorizontalTextAlignment = xf.TextAlignment.Center,
                    Text = icon,
                    FontFamily = Fonts.FontAwesomeSolid,
                    TextColor = isActive ? xf.Color.White : xf.Color.FromHex("5d5d5d"),
                },
                ["caption"] = new Label
                {
                    Text = caption,
                    FontSize = 13,
                    HorizontalTextAlignment = xf.TextAlignment.Center,
                    TextColor = isActive ? xf.Color.White : xf.Color.FromHex("5d5d5d"),
                    FontFamily = Fonts.PoppinsRegular
                }
            }
        };

        static View Actions() => new ScrollView
        {
            Orientation = xf.ScrollOrientation.Horizontal,
            BackgroundColor = xf.Color.FromHex("f4f4f4"),
            VerticalOptions = xf.LayoutOptions.Fill,
            Padding = new xf.Thickness(8, 16),
            HorizontalScrollBarVisibility = xf.ScrollBarVisibility.Never,
            VerticalScrollBarVisibility = xf.ScrollBarVisibility.Never,
            Content = new StackLayout
            {
                Orientation = xf.StackOrientation.Horizontal,
                VerticalOptions = xf.LayoutOptions.FillAndExpand,
                ["tab1"] = Action("", "Rekeningen", isActive: true),
                ["tab2"] = Action("\uf303", "Zelf regelen"),
                ["tab3"] = Action("", "Bankmail"),
                ["tab4"] = Action("", "Instellingen")
            }
        };

        static Label Text(string text, string textColor = "5d5d5d") => new Label
        {
            Text = text,
            HorizontalTextAlignment = xf.TextAlignment.Start,
            TextColor = xf.Color.FromHex(textColor),
            FontSize = 13,
            FontFamily = Fonts.PoppinsRegular
        };

        static View AccountRow(string icon, string name, string type, string number, string balance)
        {
            return new Grid
            {
                ColumnDefinitions = "64, *, Auto",
                RowSpacing = 0,
                BackgroundColor = xf.Color.White,

                Padding = 20,
                ["icon", rowSpan: 3] = new Label
                {
                    Text = icon,
                    FontSize = 36,
                    TextColor = xf.Color.FromHex("019287"),
                    VerticalOptions = xf.LayoutOptions.Center,
                    HorizontalTextAlignment = xf.TextAlignment.Start,
                    FontFamily = Fonts.FontAwesomeSolid,
                },
                ["name", column: 1] = Text(name, "019287"),
                ["type", 1, 1] = Text(type),
                ["accNo", 2, 1] = Text(number),
                ["amount", column: 2, rowSpan: 3] = new Label
                {
                    Text = balance,
                    TextColor = xf.Color.Black,
                    FontSize = 16,
                    HorizontalTextAlignment = xf.TextAlignment.Start,
                    FontFamily = Fonts.PoppinsBold,
                }
            };
        }

        public static View Body() => new Grid
        {
            RowDefinitions = "108, *, Auto",
            RowSpacing = 0,
            ["actions"] = Actions(),
            ["accounts", row: 1] = new ScrollView
            {
                HorizontalScrollBarVisibility = xf.ScrollBarVisibility.Never,
                VerticalScrollBarVisibility = xf.ScrollBarVisibility.Never,
                Content = new StackLayout
                {
                    Spacing = 1,
                    Padding = new xf.Thickness(20, 0),
                    BackgroundColor = xf.Color.FromHex("f4f4f4"),
                    ["account1"] = AccountRow("", "J. Doe", "Priverekening", "NL35 ABNA 0123 4567 89", "€ 1.039,25"),
                    ["account2"] = AccountRow("\uf4d3", "J. Doe", "Direct Sparen", "NL35 ABNA 0123 4567 89", "€ 8.215,75"),
                    ["account3"] = AccountRow("\uf201", "J. Doe", "Direct Sparen", "NL35 ABNA 0123 4567 89", "€ 12.653,50")
                }
            },
            ["buttonContainer", row: 2] = new Grid
            {
                Padding = 16,
                BackgroundColor = xf.Color.White,
                ["bottomButton"] = new Button
                {
                    Text = "Overboeken",
                    Padding = 8,
                    TextColor = xf.Color.FromHex("242839"),
                    BackgroundColor = xf.Color.FromHex("f2c002"),
                    HeightRequest = 44,
                    CornerRadius = 4,
                    FontSize = 13,
                    FontFamily = Fonts.PoppinsRegular
                }
            }
        };
    }
}