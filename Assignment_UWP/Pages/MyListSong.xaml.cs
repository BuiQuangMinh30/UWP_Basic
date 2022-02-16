﻿using Assignment_UWP.Empty;
using Assignment_UWP.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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
        int indexSong;
        private MediaPlaybackList _mediaPlaybackList;

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
            _mediaPlaybackList = new MediaPlaybackList();
            for (int i = 0; i < listSong.Count; i++)
            {
                try
                {
                    var mediaPlaybackItem = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri(listSong[i].link)));
                    _mediaPlaybackList.Items.Add(mediaPlaybackItem);
                }
                catch (Exception ex)
                {
                    var mediaPlaybackItemNull = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri("about:blank")));
                    _mediaPlaybackList.Items.Add(mediaPlaybackItemNull);
                }
            }

            ObservableCollection<Song> observableSongs = new ObservableCollection<Song>(listSong);
            ListMySong.ItemsSource = observableSongs;


            _mediaPlaybackList.CurrentItemChanged += MediaPlaybackList_CurrentItemChanged;

            var _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Source = _mediaPlaybackList; // MediaPlayerElement < MediaPlayer < MediaPlaybackList < MediaPlaybackItem
            MyMediaPlayer.SetMediaPlayer(_mediaPlayer);
        }

        private async void MediaPlaybackList_CurrentItemChanged(MediaPlaybackList sender, CurrentMediaPlaybackItemChangedEventArgs args)
        {
            indexSong = (int)sender.CurrentItemIndex; // Lấy vị trí
            Debug.WriteLine("Vị trí nhạc khi thay đổi: " + indexSong);
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ListMySong.SelectedIndex = indexSong; // Mục đích cần có Dispatcher là vì vấn đề luồng, sử dụng chung tài nguyên
            });
        }

        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexSong = ListMySong.SelectedIndex; // vị trí chọn
            //Song currentSong = MyListSong.SelectedItem as Song;
            Debug.WriteLine("Nhạc chọn: " + ListMySong.SelectedIndex);
            if (indexSong != -1)
            {
                _mediaPlaybackList.MoveTo(Convert.ToUInt32(indexSong)); // Chạy đến vị trí list cần tìm trong MediaPlayback
                MyMediaPlayer.MediaPlayer.Play();
            }
        }
    }
}
