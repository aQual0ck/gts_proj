using GTS.AuxClasses;
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

namespace GTS.Pages.General
{
    /// <summary>
    /// Interaction logic for WindowAddPhone.xaml
    /// </summary>
    public partial class WindowAddPhone : Window
    {
        private phone_number_customer pnc;
        private int _customer_id;
        public WindowAddPhone(int chosen_id)
        {
            InitializeComponent();
            _customer_id = chosen_id;
            dgrPhone.ItemsSource = AuxClasses.DBClass.entObj.phone_number.ToList();
        }

        private void dgrPhone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrPhone.SelectedItem)["id"].GetValue(dgrPhone.SelectedItem));
            pnc = new phone_number_customer()
            {
                phone_number_id = phone_id,
                customer_id = _customer_id
            };
            WindowFee windowFee = new WindowFee(pnc);
            windowFee.ShowDialog();

            Window windowAddPhone = Window.GetWindow(this);
            windowAddPhone.Close();
        }
    }
}
