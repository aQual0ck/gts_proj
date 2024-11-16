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

namespace GTS.Pages.General
{
    /// <summary>
    /// Interaction logic for WindowEditFee.xaml
    /// </summary>
    public partial class WindowEditFee : Window
    {
        private phone_number_customer pnc;
        public WindowEditFee(object item)
        {
            InitializeComponent();
            DataContext = item;
            pnc = item as phone_number_customer;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            pnc.fee = Convert.ToInt32(txbFee.Text);

            AuxClasses.DBClass.entObj.SaveChanges();

            Window windowFee = Window.GetWindow(this);
            windowFee.Close();
        }
    }
}
