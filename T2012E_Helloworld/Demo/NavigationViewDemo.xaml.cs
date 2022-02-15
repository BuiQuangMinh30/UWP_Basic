using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace T2012E_Helloworld.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationViewDemo : Page
    {
        public static Frame NavigationFrame;

        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("listSong", typeof(Pages.ListSong)),
            ("information", typeof(Pages.AccountInformation)),
            ("logout", typeof(Pages.LoginPage)),
            //("register", typeof(Pages.Register)),
            //("login", typeof(Pages.LoginPage))
        };
        public NavigationViewDemo()
        {
            this.InitializeComponent();
            this.Loaded += NavigationViewDemo_Loaded;
        }

        private void NavigationViewDemo_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            MainContent.Navigate(typeof(Pages.ListSong));

        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            /*
            if(args.IsSettingsInvoked == true)
            {
                MainContent.Navigate(typeof(Pages.Setting));
            }
            else
            {
                var selectedItem = sender.SelectedItem as NavigationViewItem;
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(selectedItem.Tag));
                MainContent.Navigate(item.Page);
            }
            */

            // Debug.WriteLine(selectedItem.Tag);
            var selectedItem = sender.SelectedItem as NavigationViewItem;
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(selectedItem.Tag));
            switch (selectedItem.Tag)
                {
                    case "listSong":
                        MainContent.Navigate(typeof(Pages.ListSong));
                        break;
                    case "information":
                        MainContent.Navigate(typeof(Pages.AccountInformation));
                        break;
                    case "logout":
                        Frame rootFrame = Window.Current.Content as Frame;
                        rootFrame.Navigate(typeof(Pages.LoginPage));
                    break;
            }
                
           
        }
    }
}
