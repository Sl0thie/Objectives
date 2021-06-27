using AndroidObjectives.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidObjectives.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        /// <summary>
        /// 
        /// </summary>
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public Command SaveCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public Command CancelCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// 
        /// </summary>
        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
