using MauiChallenge.Models;
using MauiChallenge.ViewModel;

namespace MauiChallenge.Views;

public partial class ItemDetailsPage : ContentPage
{
    public Item item;
    ItemDetailsViewModel VM { get => BindingContext as ItemDetailsViewModel; }
    public ItemDetailsPage() {
        InitializeComponent();
        BindingContext = new ItemDetailsViewModel();
      
    }

    protected override void OnAppearing() {
        base.OnAppearing();

        VM.Item = this.item;
        VM.IsButtonEnable = false;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e) {
        VM.IsButtonEnable = true;
    }
}