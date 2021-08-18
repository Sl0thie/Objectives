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

    /// <summary>
    ///
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectivePage : ContentPage
    {
        /// <summary>
        ///
        /// </summary>
        public ObjectivePage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("On saved");

            var todoItem = (CommonObjectives.Serial.Objective)BindingContext;
            LocalDatabase database = await LocalDatabase.Instance;

            await database.SaveObjectiveAsync(todoItem);
            await Navigation.PopAsync();

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (CommonObjectives.Serial.Objective)BindingContext;
            LocalDatabase database = await LocalDatabase.Instance;
            await database.DeleteObjectiveAsync(todoItem);
            await Navigation.PopAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}