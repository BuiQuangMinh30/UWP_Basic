using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace UWP_Sqlite.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataPage : Page
    {
        public List<Person> listPerson;
        public static Person personal;
        //private string checkedStartDate;
        //private string checkedEndDate;

        public DataPage()
        {
            this.InitializeComponent();
            this.Loaded += DataPage_Loaded;
        }

        private void DataPage_Loaded(object sender, RoutedEventArgs e)
        {
            listPerson = DBInitialize.GetList();
            Debug.WriteLine(listPerson);
            ListDataGridTransaction.ItemsSource = listPerson;
            btnTotalMoney.Text = DBInitialize.totalMoney.ToString();
        }
        private void CreateTransactionButton(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.CreatedTransaction));
        }

        private void ListDataGridTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            personal = ListDataGridTransaction.SelectedItem as Person;
            Frame.Navigate(typeof(Pages.DataPageDetail));
        }

        private async void Search_Category(object sender, RoutedEventArgs e)
        {
            int category = Convert.ToInt32(txtSearch.Text);
            try
            {
                List<Person> listTransactionByCategory = DBInitialize.ListTransactionByCategory(category);
                ListDataGridTransaction.ItemsSource = listTransactionByCategory;
                btnTotalMoney.Text = DBInitialize.totalMoney.ToString();
            }
            catch
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Lỗi!";
                contentDialog.Content = "Có lỗi xảy ra!";
                contentDialog.CloseButtonText = "Oke";
                await contentDialog.ShowAsync();
            }
        }
        private void ResetList(object sender, RoutedEventArgs e)
        {
            ListDataGridTransaction.ItemsSource = listPerson;
            btnTotalMoney.Text = DBInitialize.totalMoney.ToString();
        }
    }
}
