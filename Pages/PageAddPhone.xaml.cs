﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GTS.Pages
{
    /// <summary>
    /// Interaction logic for PageAddPhone.xaml
    /// </summary>
    public partial class PageAddPhone : Page
    {
        private int _ate_id;
        private string _page_name;
        private AuxClasses.phone_number phone;
        private static readonly Regex _regex = new Regex("^[0-9+\\-()\\s]+$");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public PageAddPhone(int chosen_ate_id, string page_name)
        {
            InitializeComponent();
            _ate_id = chosen_ate_id;
            _page_name = page_name;

            cmbPhoneType.SelectedValuePath = "phone_type_name";
            cmbPhoneType.DisplayMemberPath = "phone_type_name";
            cmbPhoneType.ItemsSource = AuxClasses.DBClass.entObj.phone_type.ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminPhone")
                AuxClasses.FrameClass.frmObj.Navigate(new PageAdminPhone(_ate_id));
            else
                AuxClasses.FrameClass.frmObj.Navigate(new PagePhone(_ate_id));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int ptid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbPhoneType.SelectionBoxItem)["id"].GetValue(cmbPhoneType.SelectionBoxItem));
            phone = new AuxClasses.phone_number()
            {
                full_number = txbNumber.Text,
                address = txbAddress.Text,
                phone_type_id = ptid,
                ate_id = _ate_id
            };
            AuxClasses.DBClass.entObj.phone_number.Add(phone);
            AuxClasses.DBClass.entObj.SaveChanges();
        }

        private void txbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }
    }
}