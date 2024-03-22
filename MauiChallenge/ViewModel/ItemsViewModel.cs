using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiChallenge.Models;
using MauiChallenge.Services;
using MauiChallenge.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChallenge.ViewModel {
    public partial class ItemsViewModel : ObservableObject{

        [ObservableProperty]
        ObservableCollection<Item> _items;

        [ObservableProperty]
        bool _isRefreshing;


        public async Task GetItems() {

            var services = new MauiChallengeService();

            try {

                var resp = await services.GetItems();
             
                if(resp != null) {
                    Items = new ObservableCollection<Item>(resp);
                }

            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }
            IsRefreshing = false;

        }

        [RelayCommand]
        async Task Refresh() {
            await GetItems();
        }

        [RelayCommand]
        async Task ItemSelected(Item item) {
            Debug.WriteLine($"Item Selected {item.name}");

            await Shell.Current.Navigation.PushAsync(new ItemDetailsPage() {item = item });

        }

        [RelayCommand]
        async Task AddNewItem() {
            Debug.WriteLine("AddNewItem");

            await Shell.Current.Navigation.PushModalAsync(new AddItemPage());
        }

        [RelayCommand]
        async Task DeleteItem(Item item) {
            Debug.WriteLine("DeleteItem");
            var services = new MauiChallengeService();

            try {
                var resp = await services.DeleteItem(item.id);
                if (resp) {
                    Items.Remove(item);
                    await Shell.Current.DisplayAlert("Eliminado", "Item Eliminado Correctamente", "Ok");

                    return;
                }

                await Shell.Current.DisplayAlert("Error", "Error al eliminar el item.", "Ok");

            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }
        }

    }
}
