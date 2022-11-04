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

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
