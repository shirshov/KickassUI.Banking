namespace KickassUI.Banking.Pages
{
    public static class Fonts
    {
        public static string FontAwesomeRegular => Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS
            ? "FontAwesome5Free-Regular"
            : "fontawesome_regular.otf#Regular";

        public static string FontAwesomeSolid => Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS
            ? "FontAwesome5Free-Solid"
            : "fontawesome_solid.otf#Solid";

        public static string PoppinsRegular => Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS
            ? "Poppins-Regular"
            : "PoppinsRegular.ttf#Regular";

        public static string PoppinsBold => Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS
            ? "Poppins-Bold"
            : "PoppinsBold.ttf#Bold";
    }
}