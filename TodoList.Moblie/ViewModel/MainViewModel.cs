using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TodoList.Moblie.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;

        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        private string text;

        [ObservableProperty]
        ObservableCollection<string> items;

        [ICommand]
        async void Add()
        {
            if(string.IsNullOrWhiteSpace(Text))
                return;

            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
               await Shell.Current.DisplayAlert("internet Error", "No internet", "Ok");

                return;
            }

            if(Items.Any(x => x.Contains(Text)))
            {
                IToast toast = Toast.Make($"{Text} already exists", ToastDuration.Short, 12
                );
                await toast.Show();

                Text = string.Empty;
                return;
            }

            items.Add(Text);
            Text = string.Empty;
        }

        [ICommand]
        void Delete(string s)
        {
            if(Items.Contains(s))
                Items.Remove(s);
        }

        [ICommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }
    }
}
