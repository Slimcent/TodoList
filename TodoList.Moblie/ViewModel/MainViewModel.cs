using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TodoList.Moblie.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        private string text;

        [ObservableProperty]
        ObservableCollection<string> items;

        [ICommand]
        void Add()
        {
            if(string.IsNullOrWhiteSpace(Text))
                return;

            if(Items.Any(x => x.Contains(Text)))
            {
                IToast toast = Toast.Make($"{Text} already exists", ToastDuration.Short, 12
                );
                toast.Show();

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
    }
}
