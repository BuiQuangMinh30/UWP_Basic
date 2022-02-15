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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2012E_Helloworld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountInformation : Page
    {
        public AccountInformation()
        {
            this.InitializeComponent();
            Loaded += AccountInformation_Loaded;
        }

        private void AccountInformation_Loaded(object sender, RoutedEventArgs e)
        {
            // laasy gia tri tra ve 
            FirstName.Text = App.currentLoggedIn.firstName;
        }
    }
}
