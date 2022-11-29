
using IGIS_Driver_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using IGIS_Driver_App.Data;
using IGIS_Driver_App.Models;

namespace IGIS_Driver_App
{
    public partial class App : Application
    {
        private static IgisDatabase internalDB;

        public static Transport currentTransport;

        public static IgisDatabase InternalDB
        {
            get 
            { 
                if (internalDB == null) 
                {
                    internalDB = new IgisDatabase();
                }
                
                return internalDB;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
