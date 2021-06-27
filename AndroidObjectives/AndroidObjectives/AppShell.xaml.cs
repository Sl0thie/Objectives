using AndroidObjectives.ViewModels;
using AndroidObjectives.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AndroidObjectives
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AppShell : Xamarin.Forms.Shell
    {
        /// <summary>
        /// 
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
