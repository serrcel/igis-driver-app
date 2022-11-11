
using IGIS_Driver_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace IGIS_Driver_App
{
    public partial class App : Application
    {
        private static InternalDB internalDB;

        public static InternalDB InternalDB
        {
            get 
            { 
                if (internalDB == null) 
                {
                    internalDB = new InternalDB(Path.Combine(Environment
                        .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "idb.db3"));
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
