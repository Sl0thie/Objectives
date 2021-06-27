using AndroidObjectives.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AndroidObjectives.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ItemDetailPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}