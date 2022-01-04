namespace AndroidObjectives
{
    using System;

    using AndroidObjectives.Views;

    using Xamarin.Forms;

    /// <summary>
    /// AppShell class.
    /// </summary>
    public partial class AppShell : Xamarin.Forms.Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();
            Routing.RegisterRoute(nameof(ObjectivePage), typeof(ObjectivePage));
            Routing.RegisterRoute(nameof(ObjectivesPage), typeof(ObjectivesPage));
        }

        /// <summary>
        /// OnMenuItemClicked method.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Also unused.</param>
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}