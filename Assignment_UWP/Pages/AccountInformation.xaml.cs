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
            txtFirstName.Text = account.firstName.ToString() ?? "Minh";
            txtLastName.Text = account.lastName.ToString();
            txtEmail.Text = account.email.ToString();
            txtAddress.Text = account.address.ToString();
            txtPhone.Text = account.phone.ToString();
            BitmapImage bitmapImageAvatar = new BitmapImage(new Uri(account.avatar.ToString()));
            txtAvatar.Source = bitmapImageAvatar;
            int genderText = Convert.ToInt32(account.gender.ToString());
            if(genderText == 1)
            {
                txtGender.Text = "Nam";

            }else if (genderText == 2)
            {
                txtGender.Text = "Nữ";
            }
            else
            {
                txtGender.Text = "Khác";
            }
            txtBirthday.Text = account.birthday.ToString();
            int statusSuggest = Convert.ToInt32(account.status.ToString());
            if (statusSuggest == 1)
            {
                txtStatus.Text = "Online";
            }
            else
            {
                txtStatus.Text = "Offline";
            }
            txtIntroduction.Text = account.intro ?? "test";
        }
    }
}
