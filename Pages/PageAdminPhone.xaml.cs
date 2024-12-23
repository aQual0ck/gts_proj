﻿using GTS.AuxClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for PageAdminPhone.xaml
    /// </summary>
    public partial class PageAdminPhone : Page
    {
        private string page_name = "PageAdminPhone";
        private int _need_id;
        private AuxClasses.ate _a;
        private phone_number phone;
        public PageAdminPhone(int chosen_ate_id)
        {
            InitializeComponent();
            dgrPhone.ItemsSource = AuxClasses.DBClass.entObj.phone_number.Where(x => x.ate_id == chosen_ate_id).ToList();
            _need_id = chosen_ate_id;

            cmbFilterPT.SelectedValuePath = "phone_type_name";
            cmbFilterPT.DisplayMemberPath = "phone_type_name";
            var pt = AuxClasses.DBClass.entObj.phone_type.ToList();
            pt.Insert(0, new phone_type { id = 0, phone_type_name = "Все типы телефона" });
            cmbFilterPT.ItemsSource = pt;
            cmbFilterPT.SelectedIndex = 0;

            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите телефон для поиска";
                txbSearch.Foreground = Brushes.Gray;
                txbSearch.GotFocus += RemoveTextSearch;
                txbSearch.LostFocus += AddTextSearch;
            }
        }

        private void menuAdd_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAddPhone(_need_id, page_name));
        }

        private void menuCustomer_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAdminList(_need_id));
        }

        private void menuGeneral_Click(object sender, RoutedEventArgs e)
        {
            object item = null;
            General.WindowGeneral windowGeneral = new General.WindowGeneral(item, page_name);
            windowGeneral.Show();
        }

        private void menuChange_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageChangeATS(_need_id));
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            _a = AuxClasses.DBClass.entObj.ate.FirstOrDefault(x => x.id == _need_id);
            if (MessageBox.Show("Вы уверены?", "Удаление АТС", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AuxClasses.DBClass.entObj.ate.Remove(_a);
                AuxClasses.DBClass.entObj.SaveChanges();
                AuxClasses.FrameClass.frmObj.Navigate(new PageAdminATS());
            }
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAdminATS());
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrPhone.SelectedItem)["id"].GetValue(dgrPhone.SelectedItem);
            phone = AuxClasses.DBClass.entObj.phone_number.FirstOrDefault(x => x.id == (int)id);
            AuxClasses.FrameClass.frmObj.Navigate(new PageEditPhone(phone, page_name));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrPhone.SelectedItem)["id"].GetValue(dgrPhone.SelectedItem);
            phone = AuxClasses.DBClass.entObj.phone_number.FirstOrDefault(x => x.id == (int)id);
            if (MessageBox.Show("Вы уверены?", "Удаление телефона", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AuxClasses.DBClass.entObj.phone_number.Remove(phone);
                DBClass.entObj.SaveChanges();
                ApplyFilters();
            }
        }

        private void btnViewNumbers_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrPhone.SelectedItem)["id"].GetValue(dgrPhone.SelectedItem);
            phone = AuxClasses.DBClass.entObj.phone_number.FirstOrDefault(x => x.id == (int)id);
            General.WindowGeneral windowGeneral = new General.WindowGeneral(phone, page_name);
            windowGeneral.Show();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterPT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            int ptid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbFilterPT.SelectedItem)["id"].GetValue(cmbFilterPT.SelectedItem));
            string searchText = txbSearch.Text.ToLower();

            var query = DBClass.entObj.phone_number.AsQueryable();

            if (ptid != 0)
                query = query.Where(x => x.phone_type_id == ptid);

            if (txbSearch.Text != "Введите телефон для поиска" && !string.IsNullOrEmpty(txbSearch.Text))
                query = query.Where(x => x.full_number.ToLower().Contains(searchText));

            query = query.Where(x => x.ate_id == _need_id);

            dgrPhone.ItemsSource = query.ToList();
        }

        private void RemoveTextSearch(object sender, EventArgs e)
        {
            if (txbSearch.Text == "Введите телефон для поиска")
            {
                txbSearch.Text = "";
                txbSearch.Foreground = Brushes.Black;
            }
        }

        private void AddTextSearch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите телефон для поиска";
                txbSearch.Foreground = Brushes.Gray;
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            int current_customers = DBClass.entObj.customer.Where(x => x.ate_id == _need_id).Count();
            int current_phones = DBClass.entObj.phone_number.Where(x => x.ate_id == _need_id).Count();
            MessageBox.Show($"Кол-во абонентов: {current_customers}\nКол-во телефонов: {current_phones}");
        }
    }
}
