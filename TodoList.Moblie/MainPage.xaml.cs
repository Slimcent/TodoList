using TodoList.Moblie.ViewModel;

namespace TodoList.Moblie
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}