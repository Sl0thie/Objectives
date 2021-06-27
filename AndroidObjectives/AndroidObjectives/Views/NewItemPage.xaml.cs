using AndroidObjectives.Models;
using AndroidObjectives.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidObjectives.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NewItemPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}