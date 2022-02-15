using Assignment_UWP.Empty;
using Assignment_UWP.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
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
    public sealed partial class MyListSong : Page
    {
        private SongService songService;
        public MyListSong()
        {
            this.InitializeComponent();
            songService = new SongService();
            this.Loaded += MyListSong_Loaded;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            MyMediaPlayer.MediaPlayer.Pause();
            base.OnNavigatingFrom(e);
        }

        private async void MyListSong_Loaded(object sender, RoutedEventArgs e)
        {
            List<Song> listSong = await songService.GetListSongMineAsync();
            ObservableCollection<Song> observableSongs = new ObservableCollection<Song>(listSong);
            ListMySong.ItemsSource = observableSongs;
        }
        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Song currentSong = ListMySong.SelectedItem as Song;
            MyMediaPlayer.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MyMediaPlayer.MediaPlayer.Play();
        }
    }
}
