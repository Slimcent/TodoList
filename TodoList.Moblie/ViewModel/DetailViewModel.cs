﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoList.Moblie.ViewModel
{
    [QueryProperty("Text", "Text")]
    public partial class DetailViewModel: ObservableObject
    {
        [ObservableProperty]
        string text;

        [ICommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
