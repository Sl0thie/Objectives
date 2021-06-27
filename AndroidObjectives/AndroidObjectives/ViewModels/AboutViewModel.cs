using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AndroidObjectives.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AboutViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}