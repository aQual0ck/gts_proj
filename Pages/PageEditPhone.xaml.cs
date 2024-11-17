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
    /// Interaction logic for PageEditPhone.xaml
    /// </summary>
    public partial class PageEditPhone : Page
    {
        private string _page_name;
        private int _ate_id;
        private AuxClasses.phone_number phone;
        private AuxClasses.phone_type pt;
        private static readonly Regex _regex = new Regex("^[0-9+\\-()\\s]+$");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public PageEditPhone(object item, string page_name)
        {
            InitializeComponent();
            DataContext = item;
            _page_name = page_name;
            _ate_id = (int)TypeDescriptor.GetProperties(DataContext)["ate_id"].GetValue(DataContext);

            var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
            phone = AuxClasses.DBClass.entObj.phone_number.FirstOrDefault(x => x.id == (int)id);

            var pt_id = TypeDescriptor.GetProperties(DataContext)["phone_type_id"].GetValue(DataContext);
            pt = AuxClasses.DBClass.entObj.phone_type.FirstOrDefault(x => x.id == (int)pt_id);

            cmbPhoneType.SelectedValuePath = "phone_type_name";
            cmbPhoneType.DisplayMemberPath = "phone_type_name";
            cmbPhoneType.ItemsSource = AuxClasses.DBClass.entObj.phone_type.ToList();
            cmbPhoneType.SelectedValue = pt.phone_type_name;
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

            phone.full_number = txbNumber.Text;
            phone.address = txbAddress.Text;
            phone.phone_type_id = ptid;
            phone.ate_id = _ate_id;

            AuxClasses.DBClass.entObj.SaveChanges();
        }

        private void txbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }
    }
}
