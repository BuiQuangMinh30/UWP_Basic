using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2012E_Helloworld.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DemoFilePicker : Windows.UI.Xaml.Controls.Page
    {
        private Account account;
        private Cloudinary cloudinary;
        public DemoFilePicker()
        {
            this.InitializeComponent();
            account = new Account(
            "dftxlzy81",
            "486747722349121",
            "IfXcuExvcJHc5GZxx6vimKee4To");

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        private async void Button_Click()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List; // hien thi view list or thumbnail
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary; //vi tri bat dau mo len.
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".mp4");

            // mo file ra và đợi ng dùng chọn
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                ShowLoading(true);
                //upload full

                RawUploadParams rawUploadParams = new RawUploadParams()
                {
                    File = new FileDescription(file.Name, await file.OpenStreamForReadAsync())
                };
                RawUploadResult result =  await cloudinary.UploadAsync(rawUploadParams);
                Debug.WriteLine(result.Url);
                ShowLoading(false);
                /*
                if(file.ContentType == "text/plain")
                {
                    var stringContent = await FileIO.ReadTextAsync(file);
                    editor.Text = stringContent;
                }
                else
                {
                    //preview image
                    BitmapImage bitmapImage = new BitmapImage();
                    IRandomAccessStream fileStream = await file.OpenReadAsync();
                    await bitmapImage.SetSourceAsync(fileStream);
                    imagePreview.Source = bitmapImage;

                    //upload image
                    ImageUploadParams imageUploadParams = new ImageUploadParams() {
                        File = new FileDescription(file.Name, await file.OpenStreamForReadAsync())
                    };
                    await cloudinary.UploadAsync(imageUploadParams);
                }
                */
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.CloseButtonText = "Oke";
                contentDialog.Title = "Action fail";
                contentDialog.Content = "Please choose a file save";
                await contentDialog.ShowAsync();
            }
            
        }

        private async void Button_Click_1()
        {
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";
            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

            ContentDialog contentDialog = new ContentDialog();
            contentDialog.CloseButtonText = "Oke";
            
            if (file != null)
            {
                await FileIO.WriteTextAsync(file, editor.Text);
                contentDialog.Title = "Action success";
                contentDialog.Content = "Save file success";
                Debug.WriteLine("picker photo" + file.Name);
            }
            else
            {
                contentDialog.Title = "Action fail";
                contentDialog.Content = "Please choose a file save";
                Debug.WriteLine("No");
            }
            await contentDialog.ShowAsync();
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuFlyoutItem;
            switch (menuItem.Tag)
            {
                case "open":
                    Button_Click();
                    break;

                case "save":
                    Button_Click_1();
                    break;
                default:
                    break;
            }
        }

        private void ShowLoading(bool load)
        {
           
                if (load)
                {
                    progress1.IsActive = true;
                    progress1.Visibility = Visibility.Visible;
                }
                else
                {
                    progress1.IsActive = false;
                    progress1.Visibility = Visibility.Collapsed;
                }
            
        }
    }
}
