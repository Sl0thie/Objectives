using AndroidObjectives.Models;
using AndroidObjectives.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidObjectives.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Item> Items { get; }

        /// <summary>
        /// 
        /// </summary>
        public Command LoadItemsCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public Command AddItemCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        public Command<Item> ItemTapped { get; }

        /// <summary>
        /// 
        /// </summary>
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}