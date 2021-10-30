using System;
using Xamarin.Forms;

namespace RealEstate.Components
{
    public partial class ChipView : ContentView
    {
        public event EventHandler ChipDeleted;

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                                                        typeof(string),
                                                                                        typeof(ChipView),
                                                                                        default(string));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        

        public static readonly BindableProperty ChipColorProperty = BindableProperty.Create(nameof(ChipColor),
                                                                                        typeof(Color),
                                                                                        typeof(ChipView),
                                                                                        default(Color));

        public Color ChipColor
        {
            get { return (Color)GetValue(ChipColorProperty); }
            set { SetValue(ChipColorProperty, value); }
        }

        public static readonly BindableProperty DeleteColorProperty = BindableProperty.Create(nameof(DeleteColor),
                                                                                        typeof(Color),
                                                                                        typeof(ChipView),
                                                                                        default(Color));

        public Color DeleteColor
        {
            get { return (Color)GetValue(DeleteColorProperty); }
            set { SetValue(DeleteColorProperty, value); }
        }

        public ChipView()
        {
            InitializeComponent();
            label.SetBinding(Label.TextProperty, new Binding(nameof(Text), source: this));
            chipFrame.SetBinding(BackgroundColorProperty, new Binding(nameof(ChipColor), source: this));
            deleteFrame.SetBinding(BackgroundColorProperty, new Binding(nameof(DeleteColor), source: this));
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ChipDeleted?.Invoke(this, e);
        }
    }
}
