using Assignment_UWP.Empty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountInformation : Page
    {
        public AccountInformation()
        {
            this.InitializeComponent();
            this.Loaded += AccountInformation_Loaded;
        }

        private void AccountInformation_Loaded(object sender, RoutedEventArgs e)
        {
            Account account = App.currentLoggedIn;
            txtFirstName.Text = account.firstName;
            txtLastName.Text = account.lastName.ToString();
            txtEmail.Text = account.email.ToString();
            txtAddress.Text = account.address.ToString();
            txtPhone.Text = account.phone.ToString();
            //BitmapImage bitmapImageAvatar = new BitmapImage(new Uri(account.avatar.ToString()));
            //txtAvatar.Source = bitmapImageAvatar;
            txtGender.Text = account.gender.ToString();
            txtBirthday.Text = account.birthday.ToString();
            txtStatus.Text = account.status.ToString();
            txtIntroduction.Text = account.intro ?? "dang cap nhat";
        }
    }
}
