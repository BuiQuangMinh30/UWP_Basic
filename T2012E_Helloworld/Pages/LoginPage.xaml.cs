using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using T2012E_Helloworld.Config;
using T2012E_Helloworld.Empty;
using T2012E_Helloworld.Service;
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

namespace T2012E_Helloworld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private AccountService accountService = new AccountService();
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                msgUsername.Text = "Please add email";
            }
            else
            {
                msgUsername.Text = "";
            }

            var parameters = new LoginViewModel()
            {
                email = txtEmail.Text,
                password = txtPassword.Password.ToString(),

        };
            Credential credential = await accountService.Login(parameters);
            Account account = await accountService.GetAccountInfomation(credential.access_token);
            if(account != null)
            {
                App.currentLoggedIn = account;
                App.currentCredential = credential;
                this.Frame.Navigate(typeof(Demo.NavigationViewDemo));
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails";
                contentDialog.Content = "Please try again";
                contentDialog.CloseButtonText = "ok";
                await contentDialog.ShowAsync();
            }
           
            /*
            var result = await accountService.Login(parameters);
            ContentDialog contentDialog = new ContentDialog();
            if (result)
            {
                contentDialog.Title = "Action success";
                contentDialog.Content = "Create account success";
            }
            else
            {
                contentDialog.Title = "Action fails";
                contentDialog.Content = "Please try again";
            }
            contentDialog.CloseButtonText = "ok";
            await contentDialog.ShowAsync();
            */

            /*
             * code chạy dc
            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpClient httpClient = new HttpClient();
            var result = await httpClient.PostAsync($"{ ApiConfig.ApiDomain }{ApiConfig.AccountLoginPath}", encodedContent);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // good case
                var content = await result.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<LoginPage>(content);
                //return obj;
                Debug.WriteLine(content);
            }
            else
            {
                Debug.WriteLine("Loi 1");
                // bad case
            }
            */


            /*
            var username = txtUsername.Text;
            var password = txtPassword.Password.ToString();
            ContentDialog dialog = new ContentDialog();
          
            dialog.Title = "Save your work?";
            dialog.PrimaryButtonText = "Save";
            dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            

            var result = await dialog.ShowAsync();

            if (string.IsNullOrEmpty(username)){
                msgUsername.Text = "Please add username";
            }
            else
            {
                msgUsername.Text = "";
            }
            Debug.WriteLine($"Hello word:  {username}, { password}");
            */
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Pages.Register));
        }
    }
}
