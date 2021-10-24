using System;
using Xamarin.Forms;

namespace RealEstate.Controls
{
    public class CustomFrame : Frame
    {
        public CustomFrame()
        {
            base.CornerRadius = 0;
        }

        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CustomFrame),
                                                                                                    typeof(CornerRadius),
                                                                                                    typeof(CustomFrame));

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
