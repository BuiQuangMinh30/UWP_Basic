using Assignment_UWP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Assignment_UWP.Empty;
using Assignment_UWP.Service;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Diagnostics;
using AngleSharp.Dom;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterAccount : Windows.UI.Xaml.Controls.Page
    {
        private static string publicIDAvatarCloudinary;
        private CloudinaryDotNet.Account accountCloudinary;
        private Cloudinary cloudinary;
        private int subCheckGender;
        private string dateChanged;
        private int countValid = 0;

        //private int check = 0;
        private AccountService accountService = new AccountService();
        public RegisterAccount()
        {
            this.InitializeComponent();
            this.Loaded += RegisterPage_Loaded;
        
        }
        private void RegisterPage_Loaded(object sender, RoutedEventArgs e)
        {
            accountCloudinary = new CloudinaryDotNet.Account(
            "dftxlzy81",
            "486747722349121",
            "IfXcuExvcJHc5GZxx6vimKee4To"
            );
            cloudinary = new Cloudinary(accountCloudinary);
            cloudinary.Api.Secure = true;
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(84|0[3|5|7|8|9])+([0-9]{8})$").Success;
        }
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            var check = sender as RadioButton;
            switch (check.Content)
            {
                case "Male":
                    subCheckGender = 1;
                    break;
                case "Female":
                    subCheckGender = 2;
                    break;
                case "Other":
                    subCheckGender = 3;
                    break;
            }
        }
        private void dtmBirthday_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var date = sender;
            dateChanged = date.Date.Value.ToString("yyyy-MM-dd");
        }
        private void checkValidate(string FirstName, string LastName, string Email, string Password, string Phone, string Address, int CheckGenderInt, string Avatar, string dateChanged, string Introduction)
        {
            countValid = 0;
            if (string.IsNullOrEmpty(FirstName))
            {
                lblCheckFirstName.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckFirstName.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                lblCheckLastName.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckLastName.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (string.IsNullOrEmpty(Email))
            {
                lblCheckEmail.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                if (!IsEmail(Email))
                {
                    lblCheckEmail.Text = "Đây không phải là email";
                    lblCheckEmail.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    lblCheckEmail.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    countValid++;
                }
            }
            if (string.IsNullOrEmpty(Password))
            {
                lblCheckPassword.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckPassword.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (string.IsNullOrEmpty(Phone))
            {
                lblCheckPhone.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                if (!IsPhoneNumber(Phone))
                {
                    lblCheckPhone.Text = "Đây không phải là số điện thoại";
                    lblCheckPhone.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    lblCheckPhone.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    countValid++;
                }
            }
            if (string.IsNullOrEmpty(Avatar))
            {
                lblCheckAvatar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckAvatar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (CheckGenderInt == 0 || CheckGenderInt == null)
            {
                checkGender.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                checkGender.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (string.IsNullOrEmpty(Address))
            {
                lblCheckAddress.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckAddress.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (string.IsNullOrEmpty(dateChanged))
            {
                lblCheckBirthday.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckBirthday.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
            if (string.IsNullOrEmpty(Introduction))
            {
                lblCheckIntroduction.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                lblCheckIntroduction.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                countValid++;
            }
        }

        public static bool IsEmail(string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, pattern);
        }

        private async void btnCreateAvatar_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jfif");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                BitmapImage bitmapImageAvatar = new BitmapImage();
                IRandomAccessStream fileStream = await file.OpenReadAsync();
                await bitmapImageAvatar.SetSourceAsync(fileStream);
                imgAvatar.Source = bitmapImageAvatar;
                RawUploadParams imageUploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.Name, await file.OpenStreamForReadAsync())
                };
                lblCheckAvatar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                lblCheckAvatar.Text = "Xin hãy chờ để cập nhật ảnh";
                RawUploadResult result = await cloudinary.UploadAsync(imageUploadParams);
                lblCheckAvatar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                lblCheckAvatar.Text = "Hãy chọn ảnh hoặc gán link ảnh";
                publicIDAvatarCloudinary = result.PublicId;
                txtAvatar.Text = result.Url.ToString();
                btnCreateAvatar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                //btnDeleteAvatar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                Debug.WriteLine("Create Avatar Fails!");
            }
        }

        private async void RegisterAccount_Click(object sender, RoutedEventArgs e)
        {
            checkValidate(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPassword.Password.ToString(), txtPhone.Text, txtAddress.Text, subCheckGender, txtAvatar.Text, dateChanged, txtIntroduction.Text);
            if (countValid < 10)
            {
                return;
            }
            waitingRespone.Visibility = Windows.UI.Xaml.Visibility.Visible;
            var account = new Empty.Account()
            {
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                email = txtEmail.Text,
                phone = txtPhone.Text,
                password = txtPassword.Password.ToString(),
                address = txtAddress.Text,
                gender = subCheckGender,
                avatar = txtAvatar.Text,
                birthday = dateChanged,
                intro = txtIntroduction.Text,
            };
            var result = await accountService.RegisterAsync(account);
            //waitingRespone.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ContentDialog contentDialog = new ContentDialog();
            if (result)
            {
                contentDialog.Title = "Acction success!";
                contentDialog.Content = "Create Account Success!";
            }
            else
            {
                contentDialog.Title = "Acction false!";
                contentDialog.Content = "Create Account Fails!";
            }
            contentDialog.CloseButtonText = "Oke";
            await contentDialog.ShowAsync();
        }

        private void ReturnLogin_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.LoginAccount));
        }
    }
}
