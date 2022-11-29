using IGIS_Driver_App.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IGIS_Driver_App.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            string type = App.currentTransport.type;
            switch (type)
            {
                case "bus":
                    {
                        ImageTS.Source = "bus.png";
                        ImageTS2.Source = "bus.png";
                        break;
                    }
                    

                case "trolleybus":
                    {
                        ImageTS.Source = "trolleybus.png";
                        ImageTS2.Source = "trolleybus.png";
                        break;
                    }
                    
            }
        }
    }
}