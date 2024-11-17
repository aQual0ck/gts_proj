using GTS.AuxClasses;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GTS.Pages.General
{
    /// <summary>
    /// Interaction logic for WindowFee.xaml
    /// </summary>
    public partial class WindowFee : Window
    {
        private phone_number_customer _pnc;
        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public WindowFee(phone_number_customer pnc)
        {
            InitializeComponent();
            _pnc = pnc;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _pnc.fee = Convert.ToInt32(txbFee.Text);
            DBClass.entObj.phone_number_customer.Add(_pnc);
            DBClass.entObj.SaveChanges();

            Window windowFee = Window.GetWindow(this);
            windowFee.Close();
        }

        private void txbFee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
