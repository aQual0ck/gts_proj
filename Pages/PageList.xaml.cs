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
    /// Interaction logic for PageList.xaml
    /// </summary>
    public partial class PageList : Page
    {
        private string page_name = "PageList";
        private int _need_id;
        private customer customer;
        public PageList(int chosen_ate_id)
        {
            InitializeComponent();
            dgrCustomer.ItemsSource = AuxClasses.DBClass.entObj.customer.Where(x => x.ate_id == chosen_ate_id).ToList();
            _need_id = chosen_ate_id;

            cmbFilterPT.SelectedValuePath = "phone_type_name";
            cmbFilterPT.DisplayMemberPath = "phone_type_name";
            var pt = AuxClasses.DBClass.entObj.phone_type.ToList();
            pt.Insert(0, new phone_type { id = 0, phone_type_name = "Все типы телефона" });
            cmbFilterPT.ItemsSource = pt;


            cmbFilterCat.SelectedValuePath = "category_name";
            cmbFilterCat.DisplayMemberPath = "category_name";
            var cat = AuxClasses.DBClass.entObj.category.ToList();
            cat.Insert(0, new category { id = 0, category_name = "Все категории" });
            cmbFilterCat.ItemsSource = cat;

            cmbFilterPT.SelectedIndex = 0;
            cmbFilterCat.SelectedIndex = 0;

            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите имя для поиска";
                txbSearch.Foreground = Brushes.Gray;
                txbSearch.GotFocus += RemoveTextSearch;
                txbSearch.LostFocus += AddTextSearch;
            }
        }

        private void menuAdd_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAddCustomer(_need_id, page_name));
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageATS());
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrCustomer.SelectedItem)["id"].GetValue(dgrCustomer.SelectedItem);
            customer = AuxClasses.DBClass.entObj.customer.FirstOrDefault(x => x.id == (int)id);
            FrameClass.frmObj.Navigate(new PageEditCustomer(customer, page_name));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrCustomer.SelectedItem)["id"].GetValue(dgrCustomer.SelectedItem);
            customer = AuxClasses.DBClass.entObj.customer.FirstOrDefault(x => x.id == (int)id);
            if (MessageBox.Show("Вы уверены?", "Удаление абонента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AuxClasses.DBClass.entObj.customer.Remove(customer);
                DBClass.entObj.SaveChanges();
                dgrCustomer.ItemsSource = DBClass.entObj.customer.ToList();
            }
        }

        private void menuPhone_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PagePhone(_need_id));
        }

        private void menuGeneral_Click(object sender, RoutedEventArgs e)
        {
            object item = null;
            General.WindowGeneral windowGeneral = new General.WindowGeneral(item, page_name);
            windowGeneral.Show();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterPT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilterCat.SelectedItem is null)
            {
                cmbFilterCat.SelectedIndex = 0;
            }

            ApplyFilters();
        }

        private void cmbFilterCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilterPT.SelectedItem is null)
            {
                cmbFilterPT.SelectedIndex = 0;
            }

            ApplyFilters();
        }

        private void cbDebt_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbDebt_Checked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbIntercity_Checked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbIntercity_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbDI_Checked(object sender, RoutedEventArgs e)
        {
            cbDebt.IsChecked = false;
            cbIntercity.IsChecked = false;
            cbDebt.IsEnabled = false;
            cbIntercity.IsEnabled = false;
            ApplyFilters();
        }

        private void cbDI_Unchecked(object sender, RoutedEventArgs e)
        {
            cbDebt.IsEnabled = true;
            cbIntercity.IsEnabled = true;
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            // Extract ComboBox selections
            int ptid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbFilterPT.SelectedItem)["id"].GetValue(cmbFilterPT.SelectedItem));
            int catid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbFilterCat.SelectedItem)["id"].GetValue(cmbFilterCat.SelectedItem));
            string searchText = txbSearch.Text.ToLower();

            // Start with the base query
            var query = DBClass.entObj.customer.AsQueryable();

            // Apply filters based on the controls' states
            if (ptid != 0)
                query = query.Where(x => x.phone_type_id == ptid);

            if (catid != 0)
                query = query.Where(x => x.category_id == catid);

            if (cbDebt.IsChecked == true)
                query = query.Where(x => x.has_debt == true);

            if (cbIntercity.IsChecked == true)
                query = query.Where(x => x.has_intercity == true);

            if (cbDI.IsChecked == true)
                query = query.Where(x => x.has_debt == false && x.has_intercity == false);
            if (txbSearch.Text != "Введите имя для поиска" && !string.IsNullOrEmpty(txbSearch.Text))
                query = query.Where(x => x.name.ToLower().Contains(searchText) && x.ate_id == _need_id);

            // Always filter by `ate_id`
            query = query.Where(x => x.ate_id == _need_id);

            // Assign filtered data to the DataGrid
            dgrCustomer.ItemsSource = query.ToList();
        }

        private void RemoveTextSearch(object sender, EventArgs e)
        {
            if (txbSearch.Text == "Введите имя для поиска")
            {
                txbSearch.Text = "";
                txbSearch.Foreground = Brushes.Black;
            }
        }

        private void AddTextSearch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите имя для поиска";
                txbSearch.Foreground = Brushes.Gray;
            }
        }

        private void btnViewNumbers_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrCustomer.SelectedItem)["id"].GetValue(dgrCustomer.SelectedItem);
            customer = AuxClasses.DBClass.entObj.customer.FirstOrDefault(x => x.id == (int)id);
            General.WindowGeneral windowGeneral = new General.WindowGeneral(customer, page_name);
            windowGeneral.Show();
        }
    }
}