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
using System.Text.RegularExpressions;
using System.Diagnostics;
using Newtonsoft.Json;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2012E_Helloworld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        private Model.AccountModel accountModel;
        private int checkedGender;
        
        public BlankPage1()
        {
            this.InitializeComponent();
            accountModel = new Model.AccountModel();
        }

        public static bool IsValidCurrency(string currencyValue)
        {
            string pattern = @"\p{Sc}+\s*\d+";
            Regex currencyRegex = new Regex(pattern);
            return currencyRegex.IsMatch(currencyValue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(checkedGender);
            
            var lastname = txtLastname.Text;
            var firstname = txtFirstname.Text;
            var password = txtPassword.Password.ToString();
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string intro = txtIntroduction.Text;
            string gender = Name.ToString();
            
            //regex password
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
            
            if (isValidated)
            {
                msgPassword.Text = "";
            }
            else
            {
                msgPassword.Text = "Phai > 8 ky tu, co it nhat chu in hoa, co it nhat 1 so";
            }

            //email
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                msgEmail.Text = "";
            else
                msgEmail.Text = "Chua dung email";

            //phone
            string pattern = @"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}";
            Regex regex1 = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match1 = regex1.Match(phone);

            if (match1.Success)
            {
                msgPhone.Text = "";
            }
            else
            {
                msgPhone.Text = "Nhap so";
            }
            //lastname
            if (string.IsNullOrEmpty(lastname))
            {
                msgLastname.Text = "Chua nhap lastname";
            }
            else
            {
                msgLastname.Text = "";
            }
            //firstname
            if (string.IsNullOrEmpty(firstname))
            {
                msgFirstname.Text = "Chua nhap firstname";
            }
            else
            {
                msgFirstname.Text = "";
            }
            //address
            if (string.IsNullOrEmpty(address))
            {
                msgAddress.Text = "Nhap dia chi";
            }
            else
            {
                msgAddress.Text = "";
            }

            //intro
            if (string.IsNullOrEmpty(intro))
            {
                msgIntro.Text = "Nhap thong tin";
            }
            else
            {
                msgIntro.Text = "";
            }

            //gender 
            if (string.IsNullOrEmpty(gender))
                msgGender.Text = "Chua chon ";
            else
                msgGender.Text = "";

            //conver json

            var account = new Model.AccountModel()
            {
                Firstname = firstname,
                Lastname = lastname,
                Password = password,
                Phone = phone,
                Address = address,
                Intro = intro,
                Gender = gender,
            };

            var jsonString = JsonConvert.SerializeObject(account);
            Console.WriteLine("Deserialize Object: {0}", jsonString);
            // json string chuyen lai thanh object
            Model.AccountModel obj = JsonConvert.DeserializeObject<Model.AccountModel>(jsonString);
            Console.WriteLine(obj.Firstname);
            Console.WriteLine(obj.Lastname);
            Console.ReadLine();


        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            switch (rb.Tag)
            {
                case "Male":
                    checkedGender = 1;
                    break;
                case "Female":
                    checkedGender = 0;
                    break;
                case "Other":
                    checkedGender = 2;
                    break;
            }
            choiceTextBlock.Text = "You chose: " + rb.GroupName + ": " + rb.Name;
        }

        
    }
}
