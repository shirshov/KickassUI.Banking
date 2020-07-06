using System;
using KickassUI.Banking.Effects;
using KickassUI.Banking.Pages;
using Laconic;
using xf = Xamarin.Forms;
using ContentPage = Xamarin.Forms.ContentPage;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace KickassUI.Banking
{
    public class App : Xamarin.Forms.Application
    {
        static View LeftContentContainer(View leftContent) => new StackLayout
        {
            Orientation = xf.StackOrientation.Horizontal,
            ["button"] = new Button
            {
                Text = "",
                HorizontalOptions = xf.LayoutOptions.Center,
                VerticalOptions = xf.LayoutOptions.Center,
                FontFamily = Fonts.FontAwesomeSolid,
                TextColor = xf.Color.FromHex("5d5d5d"),
                BackgroundColor = xf.Color.FromHex("f8f8f8"),
                HeightRequest = 36,
                CornerRadius = 4,
                Padding = 0,
                WidthRequest = 36,
                FontSize = 18,
                Clicked = () => Signal.Send("showLogin")
            },
            ["container"] = new StackLayout
            {
                Orientation = xf.StackOrientation.Horizontal,
                ["leftView"] = leftContent
            }
        };

        static View TitleBar(View leftContent, View rightContent) => new Grid
        {
            ColumnDefinitions = "Auto, *, Auto",
            HeightRequest = 90,
            Padding = new xf.Thickness(12, 0),
            VerticalOptions = xf.LayoutOptions.EndAndExpand,
            BackgroundColor = xf.Color.White,
            ["leftContent"] = LeftContentContainer(leftContent),
            ["rightContent", column: 2] = new StackLayout
            {
                Orientation = xf.StackOrientation.Horizontal,
                HorizontalOptions = xf.LayoutOptions.EndAndExpand,
                ["content"] = rightContent
            }
        };

        static Grid MasterLayout(string title, View leftTitleBarContent, View mainContent, View rightTitleBarContent) => new Grid
        {
            RowSpacing = 0,
            ColumnSpacing = 0,
            VerticalOptions = xf.LayoutOptions.FillAndExpand,
            HorizontalOptions = xf.LayoutOptions.FillAndExpand,
            RowDefinitions = "56, Auto, *",
            ["titlebar"] = TitleBar(leftTitleBarContent, rightTitleBarContent),
            ["title"] = new Label
            {
                Text = title,
                FontFamily = Fonts.PoppinsBold,
                HorizontalOptions = xf.LayoutOptions.Center,
                VerticalTextAlignment = xf.TextAlignment.Center,
                HorizontalTextAlignment = xf.TextAlignment.Center
            },
            ["mainContentContainer", row: 2] = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 0,
                VerticalOptions = xf.LayoutOptions.FillAndExpand,
                HorizontalOptions = xf.LayoutOptions.FillAndExpand,
                ["mainContent"] = mainContent
            },
            ["logo", rowSpan: 2] = new Image
            {
                IsVisible = String.IsNullOrEmpty(title),
                Source = "abn_logo.png",
                HorizontalOptions = xf.LayoutOptions.CenterAndExpand,
                Scale = 1.5,
                VerticalOptions = xf.LayoutOptions.EndAndExpand,
                Margin = new xf.Thickness(0, 0, 0, -24)
            }
        };
        
        Binder<string> _binder;
        
        public App()
        {
            var page = new ContentPage();
            page.On<iOS>().SetUseSafeArea(true);
            page.Effects.Add(new SafeAreaPaddingEffect());
            page.BackgroundColor = xf.Color.White; 
            
            _binder = Binder.Create("showLogin", (s, g) => g.Payload switch
            {
                "showLogin" => "showLogin",
                "showOverview" => "showOverview"
            });
            
            var contentView = _binder.CreateView(s => s switch
            {
                "showLogin" => MasterLayout( "", 
                    Login.LeftTitleBarButton(), 
                    Login.Body(),
                    Login.RightTitleBarButton()),
                "showOverview" => MasterLayout("Rekeningen", null, Overview.Body(), null)
            });

            page.Content = contentView;
            MainPage = page;
        }
    }
}