﻿#pragma checksum "D:\CSharp\FPT\Uwp_newbie\T2012E_Helloworld\T2012E_Helloworld\Pages\Register.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C8D5E95A64D39CCBB5ED202A4EDEA7AB83BCF9878591C71350DE3D4FB4E0F98B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace T2012E_Helloworld.Pages
{
    partial class Register : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\Register.xaml line 12
                {
                    this.firstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Pages\Register.xaml line 13
                {
                    this.lastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Pages\Register.xaml line 16
                {
                    this.email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Pages\Register.xaml line 19
                {
                    this.password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6: // Pages\Register.xaml line 20
                {
                    this.address = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Pages\Register.xaml line 22
                {
                    this.avatar = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Pages\Register.xaml line 23
                {
                    this.phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\Register.xaml line 26
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element9 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element9).Checked += this.HandleCheck;
                }
                break;
            case 10: // Pages\Register.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element10 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element10).Checked += this.HandleCheck;
                }
                break;
            case 11: // Pages\Register.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element11 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element11).Checked += this.HandleCheck;
                }
                break;
            case 12: // Pages\Register.xaml line 29
                {
                    global::Windows.UI.Xaml.Controls.Button element12 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element12).Click += this.Button_Click;
                }
                break;
            case 13: // Pages\Register.xaml line 31
                {
                    this.content = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // Pages\Register.xaml line 32
                {
                    this.birthday = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)this.birthday).DateChanged += this.Birthday_DateChanged;
                }
                break;
            case 15: // Pages\Register.xaml line 33
                {
                    this.checkFirstName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Pages\Register.xaml line 34
                {
                    this.checkLastName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Pages\Register.xaml line 35
                {
                    this.checkEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Pages\Register.xaml line 36
                {
                    this.checkPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // Pages\Register.xaml line 37
                {
                    this.checkAddress = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // Pages\Register.xaml line 38
                {
                    this.checkPhone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

