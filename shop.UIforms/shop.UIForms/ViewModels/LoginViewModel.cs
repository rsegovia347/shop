

namespace shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using shop.UIForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(this.Login);

        public LoginViewModel()
        {
            this.Email = "jzuluaga55@gmail.com";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Your must enter an email",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Your must enter a Password",
                    "Accept");
                return;
            }
            if (!this.Email.Equals("jzuluaga55@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Incorrect user or password", "Accept");
                return;
            }

            // await Application.Current.MainPage.DisplayAlert(
            //      "Ok",
            //    "Fuck Yeah",
            //  "Accept");
            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());
        }
    }
}
