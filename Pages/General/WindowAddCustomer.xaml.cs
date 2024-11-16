using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using GTS.AuxClasses;

namespace GTS.Pages.General
{
    /// <summary>
    /// Interaction logic for WindowAddCustomer.xaml
    /// </summary>
    public partial class WindowAddCustomer : Window
    {
        private phone_number_customer pnc;
        private int _phone_id;
        public WindowAddCustomer(int chosen_id)
        {
            _phone_id = chosen_id;
            InitializeComponent();
            dgrCustomer.ItemsSource = AuxClasses.DBClass.entObj.customer.ToList();
        }

        private void dgrCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrCustomer.SelectedItem)["id"].GetValue(dgrCustomer.SelectedItem));
            pnc = new phone_number_customer()
            {
                phone_number_id = _phone_id,
                customer_id = customer_id
            };
            DBClass.entObj.phone_number_customer.Add(pnc);
            DBClass.entObj.SaveChanges();

            Window windowAddCustomer = Window.GetWindow(this);
            windowAddCustomer.Close();
        }
    }
}
