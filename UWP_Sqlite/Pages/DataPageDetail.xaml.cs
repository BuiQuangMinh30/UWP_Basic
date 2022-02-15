using System;
using System.Collections.Generic;
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
    public sealed partial class DataPageDetail : Page
    {
        public Person personalDetail;
        public DataPageDetail()
        {
            this.InitializeComponent();
            this.Loaded += DataPageDetail_Loaded;
        }

        private void DataPageDetail_Loaded(object sender, RoutedEventArgs e)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            if (DataPage.personal != null)
            {
                personalDetail = DataPage.personal;
                btnName.Text = personalDetail.Name.ToString();
                btnDescription.Text = personalDetail.Description.ToString();
                btnDetail.Text = personalDetail.Detail.ToString();
                btnMoney.Text = Convert.ToDouble(personalDetail.Money).ToString("#,###", cul.NumberFormat) + " Đồng";
                btnCreatedDate.Text = personalDetail.CreatedDate.ToString("dd-MM-yyyy");
                btnCategory.Text = personalDetail.Category.ToString();
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.DataPage));
        }
    }
}
