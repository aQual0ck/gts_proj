using System;
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
    /// Interaction logic for PageChangeATS.xaml
    /// </summary>
    public partial class PageChangeATS : Page
    {
        private int _need_id;
        private AuxClasses.ate ate;
        private AuxClasses.ate_type at;
        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public PageChangeATS(int chosen_ate_id)
        {
            InitializeComponent();
            ate = AuxClasses.DBClass.entObj.ate.FirstOrDefault(x => x.id == chosen_ate_id);
            DataContext = ate;
            _need_id = chosen_ate_id;

            var at_id = TypeDescriptor.GetProperties(ate)["ate_type_id"].GetValue(ate);
            at = AuxClasses.DBClass.entObj.ate_type.FirstOrDefault(x => x.id == (int)at_id);

            cmbATSType.SelectedValuePath = "ate_type_name";
            cmbATSType.DisplayMemberPath = "ate_type_name";
            cmbATSType.ItemsSource = AuxClasses.DBClass.entObj.ate_type.ToList();
            cmbATSType.SelectedValue = at.ate_type_name;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAdminList(_need_id));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int at_id = Convert.ToInt32(TypeDescriptor.GetProperties(cmbATSType.SelectionBoxItem)["id"].GetValue(cmbATSType.SelectionBoxItem));

            ate.ate_type_id = at_id;
            ate.number_of_customers = Convert.ToInt32(txbCustomers.Text);
            ate.phone_number_qty = Convert.ToInt32(txbPhoneNumbers.Text);
            AuxClasses.DBClass.entObj.SaveChanges();

            MessageBox.Show("Сохранено");
        }

        private void txbCustomers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void txbPhoneNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
