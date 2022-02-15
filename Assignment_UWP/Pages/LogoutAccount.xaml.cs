using Assignment_UWP.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class LogoutAccount : Page
    {
        public LogoutAccount()
        {
            this.InitializeComponent();
            this.Loaded += Button_LogOut;
        }

        private async void Button_LogOut(object sender, RoutedEventArgs e)
        {

            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Logout?",
                Content = "Do you want to logout it?",
                PrimaryButtonText = "Logout",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                // Delete the file.
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile manifestFile = await storageFolder.GetFileAsync(AccountService.TokenFileName);
                await manifestFile.DeleteAsync();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Pages.LoginAccount));
            }
            else
            {
                // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
                Debug.WriteLine("logout fails" );
            }
           
        }
    }
}
