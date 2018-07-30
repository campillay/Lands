namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

     public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnable;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }
        #endregion

        #region Contructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;

            this.Email = "jonathan.campillay@hotmail.com";
                this.Password = "1234";
        }
        #endregion


        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Email",
                    "Acceptar");
                
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar la clave",
                    "Acceptar");
                return;
            }
            this.IsRunning = true;
            this.IsEnable = false;

            if (this.Email != "jonathan.campillay@hotmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnable = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email o Clave son incorrectos",
                    "Aceptar");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnable = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion

    }
}
