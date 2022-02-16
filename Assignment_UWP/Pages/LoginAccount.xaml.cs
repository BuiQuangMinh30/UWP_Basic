using Assignment_UWP.Empty;
using Assignment_UWP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class LoginAccount : Page
    {
        private AccountService accountService = new AccountService();
        private int count = 0;
        public LoginAccount()
        {
            this.InitializeComponent();
            
        }

        public static bool IsEmail(string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, pattern);
        }


        private void ValidateLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email)){
                msgEmail.Visibility = Visibility.Visible;
            }
            else
            {
                if (!IsEmail(email))
                {
                    msgEmail.Text = "This is not an email";
                    msgEmail.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    msgEmail.Text = "";
                    count++;
                }
            }

            if (string.IsNullOrEmpty(password))
            {
                msgPassword.Visibility = Visibility.Visible;
            }
            else
            {
                msgPassword.Visibility = Visibility.Collapsed;
                count++;
            }
        }
        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidateLogin(txtEmail.Text, txtPassword.Password.ToString());
            if (count < 2)
            {
                return;
            }

            var parameters = new LoginViewModal()
            {
                email = txtEmail.Text,
                password = txtPassword.Password.ToString(),
            };

           
            Credential result = await accountService.Login(parameters);
            ContentDialog contentDialog = new ContentDialog();
            
            if (result != null)
            {
                contentDialog.Title = "Login success";
                Frame.Navigate(typeof(Pages.NavigationView));
            }
            else
            {
                contentDialog.Title = "Login false!";
                contentDialog.Content = "Login false!";
            }
            contentDialog.CloseButtonText = "Oke";
            await contentDialog.ShowAsync();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Pages.RegisterAccount));
        }
    }
}
