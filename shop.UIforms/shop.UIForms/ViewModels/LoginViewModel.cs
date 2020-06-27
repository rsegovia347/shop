﻿

namespace shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using shop.Common.Helpers;
    using shop.Common.Models;
    using shop.Common.Services;
    using shop.UIForms.Helpers;
    using shop.UIForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel: BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;
        public bool IsRemember { get; set; }

        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(this.Login);

        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;

            this.IsRemember = true;
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.EmailError,
                   Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.PasswordError,
                   Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var request = new TokenRequest
            {
                Password = this.Password,
                Username = this.Email
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetTokenAsync(
                url,
                "/Account",
                "/CreateToken",
                request);

            this.IsRunning = true; // verificar ....
            this.IsEnabled = true;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                   Languages.LoginError,
                   Languages.Accept);
                return;
            }

            var token = (TokenResponse)response.Result;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.UserEmail = this.Email;
            mainViewModel.UserPassword = this.Password;
            mainViewModel.Token = token;
            mainViewModel.Products = new ProductsViewModel();

            Settings.IsRemember = this.IsRemember;
            Settings.UserEmail = this.Email;
            Settings.UserPassword = this.Password;
            Settings.Token = JsonConvert.SerializeObject(token);

            Application.Current.MainPage = new MasterPage();


        }
    }
}

