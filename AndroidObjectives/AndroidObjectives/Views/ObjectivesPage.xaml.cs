namespace AndroidObjectives.Views
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AndroidObjectives.Data;
    using AndroidObjectives.Models;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using SQLite;
    using CommonObjectives;

    /// <summary>
    /// 
    /// </summary>
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
            listView.ItemsSource = await database.GetObjectivesAsync();


            
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ObjectivePage
            {
                BindingContext = new CommonObjectives.Serial.Objective()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ObjectivePage
                {
                    BindingContext = e.SelectedItem as CommonObjectives.Serial.Objective
                });
            }
        }
    }
}