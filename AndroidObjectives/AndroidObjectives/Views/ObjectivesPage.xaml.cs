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

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectivesPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectivesPage()
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
            listView.ItemsSource = await database.GetItemsAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ObjectivePage
            {
                BindingContext = new Objective()
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ObjectivePage
                {
                    BindingContext = e.SelectedItem as Objective
                });
            }
        }
    }
}