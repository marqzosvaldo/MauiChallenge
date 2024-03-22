using MauiChallenge.ViewModel;

namespace MauiChallenge.Views;

public partial class AddItemPage : ContentPage{
	public AddItemPage() {
		InitializeComponent();
		BindingContext  = new AddItemViewModel();
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e) {

    }
}