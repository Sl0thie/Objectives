//using AndroidObjectives.Services;
using AndroidObjectives.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidObjectives
{
    /// <summary>
    /// 
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 
        /// </summary>
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
