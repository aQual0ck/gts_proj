using GTS.AuxClasses;
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
using System.Windows.Shapes;

namespace GTS.Pages.General
{
    /// <summary>
    /// Interaction logic for WindowGeneral.xaml
    /// </summary>
    public partial class WindowGeneral : Window
    {
        private string _page_name;
        private phone_number_customer pnc;
        public WindowGeneral(object item, string page_name)
        {
            InitializeComponent();
            _page_name = page_name;
            DataContext = item;
            if (item is null)
            {
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.ToList();
            }
            if (item != null)
            {
                MenuItem menuAdd = new MenuItem();
                menuAdd.Header = "Добавить";
                menuAdd.Click += menuAdd_Click;
                this.menuGeneral.Items.Add(menuAdd);

                if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
                {
                    var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)id).ToList();
                }

                if (_page_name == "PageAdminList" || _page_name == "PageList")
                {
                    var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)id).ToList();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window windowGeneral = Window.GetWindow(this);
            windowGeneral.Close();
        }
        private void menuAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
            {
                int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext));
                WindowAddCustomer windowAddCustomer = new WindowAddCustomer(phone_id);
                windowAddCustomer.ShowDialog();
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)phone_id).ToList();
            }

            if (_page_name == "PageAdminList" || _page_name == "PageList")
            {
                int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext));
                WindowAddPhone windowAddPhone = new WindowAddPhone(customer_id);
                windowAddPhone.ShowDialog();
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)customer_id).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
            {
                var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["customer_id"].GetValue(dgrGeneral.SelectedItem));
                pnc = DBClass.entObj.phone_number_customer.FirstOrDefault(x => x.customer_id == customer_id);
                if (MessageBox.Show("Вы уверены?", "Отвязка абонента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.phone_number_customer.Remove(pnc);
                    DBClass.entObj.SaveChanges();
                }
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)id).ToList();
            }

            if (_page_name == "PageAdminList" || _page_name == "PageList")
            {
                var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["phone_number_id"].GetValue(dgrGeneral.SelectedItem));
                pnc = DBClass.entObj.phone_number_customer.FirstOrDefault(x => x.phone_number_id == phone_id);
                if (MessageBox.Show("Вы уверены?", "Отвязка телефона", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.phone_number_customer.Remove(pnc);
                    DBClass.entObj.SaveChanges();
                }
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)id).ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["customer_id"].GetValue(dgrGeneral.SelectedItem));
            int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["phone_number_id"].GetValue(dgrGeneral.SelectedItem));
            pnc = DBClass.entObj.phone_number_customer.FirstOrDefault(x => x.customer_id == customer_id && x.phone_number_id == phone_id);
            WindowEditFee windowEditFee = new WindowEditFee(pnc);
            windowEditFee.ShowDialog();
            if (DataContext != null)
            {
                var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
                {
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)id).ToList();
                }

                if (_page_name == "PageAdminList" || _page_name == "PageList")
                {
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)id).ToList();
                }
            }
            else
            {
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.ToList();
            }
        }
    }
}