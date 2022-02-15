using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2012E_Helloworld.Empty;
using T2012E_Helloworld.Service;
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

namespace T2012E_Helloworld.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSong : Page
    {
        private SongService songService;
        public ListSong()
        {
            this.InitializeComponent();
            this.songService = new SongService();
            Loaded += ListSong_Loaded;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MyMediaPlayer.MediaPlayer.Pause();
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private async void ListSong_Loaded(object sender, RoutedEventArgs e)
        {
            List<Song> lists =  await this.songService.GetList(); //lấy ra danh sách admin tạo
           // List<Song> lists = await this.songService.GetMyList(); // lấy ra danh sách mình tạo
            //danh sach nhưng chuyên dùng để by vào list view, khi thay đổi sẽ lắng nghe sự thay đô và update
            ObservableCollection<Song> observableSongs = new ObservableCollection<Song>(lists); 
            Debug.WriteLine(lists.Count);
            MyListSong.ItemsSource = observableSongs;
           
        }

       
        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSong = MyListSong.SelectedItem as Song;
            Debug.WriteLine("SelectionChanged" +currentSong.name);
            Debug.WriteLine(currentSong.link);
            MyMediaPlayer.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MyMediaPlayer.MediaPlayer.Play();
        }

        
    }
}
