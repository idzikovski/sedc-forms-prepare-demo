using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinFormsSandbox.MVVMandDataBinding
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _labelText;
        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                OnPropertyChanged(nameof(LabelText));
            }
        }

        private string _buttonControlledText;
        public string ButtonControlledText
        {
            get => _buttonControlledText;
            set
            {
                _buttonControlledText = value;
                OnPropertyChanged(nameof(ButtonControlledText));
            }
        }

        private string _entryText;
        public string EntryText
        {
            get => _entryText;
            set
            {
                _entryText = value;
                OnPropertyChanged(nameof(EntryText));
            }
        }

        public ICommand TextButtonClickedCommand => new Command(() =>
        {
            ButtonControlledText = EntryText;
        });

        public MyViewModel()
        {
            LabelText = "Random label";
            Task.Run(CountDownLabel);
        }

        private async Task CountDownLabel()
        {
            for (int i = 5; i > 0; i--)
            {
                await Task.Delay(1000);
                LabelText = i.ToString();
            }

            LabelText = "Timer finished";
        }
    }
}
