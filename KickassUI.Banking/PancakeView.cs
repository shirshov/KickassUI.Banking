using System;
using Laconic;
using xf = Xamarin.Forms;

namespace KickassUI.Banking.Pages.Laconic
{
    public class PancakeView : Layout<Xamarin.Forms.PancakeView.PancakeView>, IContentHost
    {
        public View Content { get; set; }

        // Properties other than CornerRadius are not used in this app
        public xf.CornerRadius CornerRadius
        {
            set => SetValue(Xamarin.Forms.PancakeView.PancakeView.CornerRadiusProperty, value);
        }
    }
}