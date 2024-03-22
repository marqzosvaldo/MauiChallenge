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
    public partial class ItemDetailsViewModel : ObservableObject{

        [ObservableProperty]
        Item _item;
        [ObservableProperty]
        bool _isButtonEnable;


        partial void OnItemChanged(Item value) {
            Debug.WriteLine($"Item Changed {Item.name}");


        }

        [RelayCommand]
        async Task SaveItem() {
            IsButtonEnable = false;
            var services = new MauiChallengeService();

            try {

                var resp = await services.UpdateItem(Item);
                if (resp) {
                    await Shell.Current.Navigation.PopAsync();
                    await Shell.Current.DisplayAlert("Actualizado", "Registro Actualizado Correctamente", "Ok");
                    return;
                }

                await Shell.Current.DisplayAlert("Error", "Error al actualizar registro", "Ok");


            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
            }
            Debug.WriteLine("Save Item Command");
        }
    }
}
