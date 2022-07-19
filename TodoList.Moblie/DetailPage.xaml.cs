using TodoList.Moblie.ViewModel;

namespace TodoList.Moblie;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}