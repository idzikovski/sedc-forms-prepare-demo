using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsSandbox.DataBinding;

namespace XamarinFormsSandbox.WorkingWithData
{
    public class RestClientViewModel : BaseViewModel
    {
        public RestClientViewModel()
        {
            ResultLabel = "ResultLabel";
            _restClientService = new RestClientService();
        }

        private string _resultLabel;
        private readonly RestClientService _restClientService;

        public string ResultLabel
        {
            get => _resultLabel;
            set
            {
                _resultLabel = value;
                OnPropertyChanged(nameof(ResultLabel));
            }
        }

        public ICommand GetCommand => new Command(async () =>
        {
            var list = await _restClientService.GetAsync<List<Posts>>("posts");

            ResultLabel = await _restClientService.GetAsync("posts");
        });

        public ICommand PostCommand => new Command(async () =>
        {
            var post = new Posts
            {
                UserId = 64334,
                Title = "Some title",
                Body = "Some body"
            };

            ResultLabel = await _restClientService.PostAsync("posts", post);
        });

        public ICommand PatchCommand => new Command(async () =>
        {
            var post = new Posts
            {
                Id = 1,
                UserId = 64334,
                Title = "Some title",
                Body = "Some body"
            };

            ResultLabel = await _restClientService.PatchAsync($"posts/{post.Id}", post);
        });

        public ICommand DeleteCommand => new Command(async () =>
        {
            ResultLabel = await _restClientService.GetAsync("posts/1");
        });
    }
}
