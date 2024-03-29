﻿namespace AndroidObjectives
{
    using System;

    using AndroidObjectives.Views;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// App class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        /// <summary>
        /// OnStart method.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// OnSleep method.
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// OnResume method.
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}