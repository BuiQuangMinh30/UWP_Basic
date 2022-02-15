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

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationView : Page
    {
        public static Frame NavigationFrame;

        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("listSongAll", typeof(ListSongAll)),
            ("listSongMine", typeof(MyListSong)),
            ("createSongAll", typeof(CreateSongAll)),
            ("createtSongMine", typeof(CreateMySong)),
            ("information", typeof(AccountInformation)),
            ("logout", typeof(LoginAccount)),
            
        };
        public NavigationView()
        {
            this.InitializeComponent();
            this.Loaded += NavigationView_Loaded;
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(typeof(Pages.ListSongAll));
        }

        private void NavView_ItemInvoked(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var selectedItem = sender.SelectedItem as NavigationViewItem;
            Debug.WriteLine(selectedItem);
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(selectedItem.Tag));
            switch (selectedItem.Tag)
            {
                case "listSongAll":
                    MainContent.Navigate(typeof(ListSongAll));
                    break;
                case "listSongMine":
                    MainContent.Navigate(typeof(MyListSong));
                    break;
                case "createSongAll":
                    MainContent.Navigate(typeof(CreateSongAll));
                    break;
                case "createtSongMine":
                    MainContent.Navigate(typeof(CreateMySong));
                    break;
                case "information":
                    MainContent.Navigate(typeof(AccountInformation));
                    break;
                case "logout":
                    MainContent.Navigate(typeof(LogoutAccount));
                    break;
            }
        }
        //public object SelectedItem { get; set; }

    }
}
