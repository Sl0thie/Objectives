namespace AndroidObjectives.Views
{
    using System;
    using System.Diagnostics;

    using AndroidObjectives.Data;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// ObjectivePage class.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectivePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectivePage"/> class.
        /// </summary>
        public ObjectivePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnSaveClicked method.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("On saved");

            CommonObjectives.Serial.Objective todoItem = (CommonObjectives.Serial.Objective)BindingContext;
            LocalDatabase database = await LocalDatabase.Instance;

            _ = await database.SaveObjectiveAsync(todoItem);
            _ = await Navigation.PopAsync();
        }

        /// <summary>
        /// OnDeleteClicked method.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            CommonObjectives.Serial.Objective todoItem = (CommonObjectives.Serial.Objective)BindingContext;
            LocalDatabase database = await LocalDatabase.Instance;
            _ = await database.DeleteObjectiveAsync(todoItem);
            _ = await Navigation.PopAsync();
        }

        /// <summary>
        /// OnCancelClicked method.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }
    }
}