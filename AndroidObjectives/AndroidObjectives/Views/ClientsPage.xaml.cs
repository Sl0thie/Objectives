namespace AndroidObjectives.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AndroidObjectives.Data;
    using AndroidObjectives.Models;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        public ClientsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LocalDatabase database = await LocalDatabase.Instance;
            listView.ItemsSource = await database.GetClientsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ObjectivePage
            //{
            //    BindingContext = new Objective()
            //});
        }



    }
}