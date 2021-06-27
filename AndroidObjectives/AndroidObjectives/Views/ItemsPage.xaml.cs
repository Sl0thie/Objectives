﻿using AndroidObjectives.Models;
using AndroidObjectives.ViewModels;
using AndroidObjectives.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidObjectives.Views
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        /// <summary>
        /// 
        /// </summary>
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}