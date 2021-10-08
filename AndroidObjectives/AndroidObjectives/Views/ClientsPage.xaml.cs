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
    /// ClientsPage class.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsPage"/> class.
        /// </summary>
        public ClientsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnAppearing override.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LocalDatabase database = await LocalDatabase.Instance;
            listView.ItemsSource = await database.GetClientsAsync();
        }

        /// <summary>
        /// OnItemAdded method.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private void OnItemAdded(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new ObjectivePage
            // {
            //     BindingContext = new Objective()
            // });
        }
    }
}