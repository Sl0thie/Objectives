﻿namespace AndroidObjectives
{
    using System;

    using AndroidObjectives.Views;

    using Xamarin.Forms;

    /// <summary>
    /// AppShell class.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
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
            await Current.GoToAsync("//LoginPage");
        }
    }
}