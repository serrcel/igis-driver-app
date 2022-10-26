using IGIS_Driver_App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IGIS_Driver_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}