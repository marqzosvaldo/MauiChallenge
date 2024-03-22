using MauiChallenge.ViewModel;

namespace MauiChallenge.Views;

public partial class ItemsPage : ContentPage{
	ItemsViewModel VM { get => BindingContext as ItemsViewModel; }
	public ItemsPage(ItemsViewModel vm) {
		InitializeComponent();

		BindingContext = vm;


	}

    protected async override void OnAppearing() {
        base.OnAppearing();
		VM.IsRefreshing = true;
	
		await VM.GetItems();

    }

}