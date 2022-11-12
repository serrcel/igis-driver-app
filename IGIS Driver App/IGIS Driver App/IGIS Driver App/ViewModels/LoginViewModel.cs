using IGIS_Driver_App.Models;
using IGIS_Driver_App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;

namespace IGIS_Driver_App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Transport Ts;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            string userGosnumber = obj.ToString().ToUpper();
            Ts = await App.InternalDB.GetTransportAsync(userGosnumber);
            if (Ts != null)
            {
                if (userGosnumber == Ts.gosnumber)
                {
                    App.currentTransport = Ts;
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                }
                    
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка авторизации", "Вы ввели неверный номер!", "Ок");
                }
            }
            else
                await Shell.Current.DisplayAlert("Ошибка авторизации", "Вы ввели неверный номер!", "Ок");

        }
    }
}
