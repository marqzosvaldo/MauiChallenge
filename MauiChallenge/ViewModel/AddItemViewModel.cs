using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiChallenge.Models;
using MauiChallenge.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChallenge.ViewModel{
    public partial class AddItemViewModel : ObservableObject{

        [ObservableProperty]
        string _name;



        [RelayCommand]
        async Task AddItem() {
            Debug.WriteLine("addItem");

            if (string.IsNullOrEmpty(Name)) {

                await Shell.Current.DisplayAlert("Error", "Agregue un nombre por favor.", "Ok");
                return;
            }

            var services = new MauiChallengeService();

            try {
                var item = new Item {
                    name = Name,
                };
                var resp = await services.AddItem(item);

                if(resp != null) {
                    await Shell.Current.DisplayAlert("Agregado", "Item agregado correctamente.", "ok");
                    await Shell.Current.Navigation.PopAsync();
                    return;
                }

                await Shell.Current.DisplayAlert("Error", "el item no se agrego.", "ok");



            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }
        }
    }
}
