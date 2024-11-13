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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace GTS.Pages
{
    /// <summary>
    /// Interaction logic for PageAddATS.xaml
    /// </summary>
    public partial class PageAddATS : Page
    {
        private AuxClasses.ate a;
        public PageAddATS()
        {
            InitializeComponent();

            cmbATSType.SelectedValuePath = "ate_type_name";
            cmbATSType.DisplayMemberPath = "ate_type_name";
            cmbATSType.ItemsSource = AuxClasses.DBClass.entObj.ate_type.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(cmbATSType.SelectedItem)["id"].GetValue(cmbATSType.SelectedItem);
            a = new AuxClasses.ate()
            {
                ate_type_id = (int)id,
                number_of_customers = Convert.ToInt32(txbCustomers.Text),
                phone_number_qty = Convert.ToInt32(txbPhoneNumbers.Text)
            };
            AuxClasses.DBClass.entObj.ate.Add(a);
            AuxClasses.DBClass.entObj.SaveChanges();
            MessageBox.Show("Добавлено!");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAdminATS());
        }
    }
}
