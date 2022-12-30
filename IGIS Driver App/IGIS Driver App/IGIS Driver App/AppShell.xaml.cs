using IGIS_Driver_App.ViewModels;
using IGIS_Driver_App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IGIS_Driver_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void LogOut(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
