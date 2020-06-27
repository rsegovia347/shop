﻿namespace shop.UIForms.ViewModels
{
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;

    public class ProductItemViewModel : Product
    {
        public ICommand SelectProductCommand => new RelayCommand(this.SelectProduct);

        private async void SelectProduct()
        {
            MainViewModel.GetInstance().EditProduct = new EditProductViewModel(this);
            await App.Navigator.PushAsync(new EditProductPage());
        }
    }

}
