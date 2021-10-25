using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace RealEstate.Components
{
    public partial class ChipView : ContentView
    {
        public event EventHandler ChipDeleted;

        //public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
        //                                                                                typeof(string),
        //                                                                                typeof(ChipView),
        //                                                                                default(string));

        //public string Text
        //{
        //    get { return (string)GetValue(TextProperty); }
        //    set { SetValue(TextProperty, value); }
        //}

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                label.Text = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                mainFrame.BackgroundColor = value;
            }
        }

        private Color _deleteButtonColor;
        public Color DeleteButtonColor
        {
            get => _deleteButtonColor;
            set
            {
                _deleteButtonColor = value;
                deleteFrame.BackgroundColor = value;
            }
        }

        public ChipView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            label.Text = Text;
            mainFrame.BackgroundColor = Color;
            deleteFrame.BackgroundColor = DeleteButtonColor;
        }

        void DeleteTapped(object sender, EventArgs e)
        {
            ChipDeleted?.Invoke(this, e);
        }
    }
}