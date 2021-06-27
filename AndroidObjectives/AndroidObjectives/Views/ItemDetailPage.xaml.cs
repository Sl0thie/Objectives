using AndroidObjectives.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AndroidObjectives.Views
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