using Newtonsoft.Json;
using shop.Common.Helpers;
using shop.Common.Models;
using shop.UIForms.ViewModels;
using shop.UIForms.Views;
using System;
using Xamarin.Forms;

namespace shop.UIForms
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }


        public App()
        {
            InitializeComponent();
            if (Settings.IsRemember)
            {
                var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                if (token.Expiration > DateTime.Now)
                {
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Token = token;
                    mainViewModel.UserEmail = Settings.UserEmail;
                    mainViewModel.UserPassword = Settings.UserPassword;
                    mainViewModel.Products = new ProductsViewModel();
                    this.MainPage = new MasterPage();
                    return;
                }
            }


            MainViewModel.GetInstance().Login = new LoginViewModel();
            MainPage = new NavigationPage(new  LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
