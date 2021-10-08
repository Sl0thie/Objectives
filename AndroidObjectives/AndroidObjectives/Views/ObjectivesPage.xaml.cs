namespace AndroidObjectives.Views
{
    using System;

    using AndroidObjectives.Data;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// ObjectivesPageObjectivesPage class.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectivesPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectivesPage"/> class.
        /// </summary>
        public ObjectivesPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnAppearing method.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LocalDatabase database = await LocalDatabase.Instance;
            listView.ItemsSource = await database.GetObjectivesAsync();
        }

        private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ObjectivePage
            {
                BindingContext = new CommonObjectives.Serial.Objective(),
            });
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ObjectivePage
                {
                    BindingContext = e.SelectedItem as CommonObjectives.Serial.Objective,
                });
            }
        }
    }
}