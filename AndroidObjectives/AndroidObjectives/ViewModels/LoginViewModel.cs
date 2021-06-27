using AndroidObjectives.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidObjectives.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Command LoginCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
