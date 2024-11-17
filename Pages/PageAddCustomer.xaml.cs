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
    /// Interaction logic for PageAddCustomer.xaml
    /// </summary>
    public partial class PageAddCustomer : Page
    {
        private int _ate_id;
        private string _page_name;
        private AuxClasses.customer customer; 
        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static readonly Regex _regexText = new Regex("[а-яА-ЯёЁ]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private static bool IsNumberAllowed(string text)
        {
            return !_regexText.IsMatch(text);
        }
        public PageAddCustomer(int chosen_ate_id, string page_name)
        {
            InitializeComponent();
            _ate_id = chosen_ate_id;
            _page_name = page_name;

            cmbPhoneType.SelectedValuePath = "phone_type_name";
            cmbPhoneType.DisplayMemberPath = "phone_type_name";
            cmbPhoneType.ItemsSource = AuxClasses.DBClass.entObj.phone_type.ToList();

            cmbCategory.SelectedValuePath = "category_name";
            cmbCategory.DisplayMemberPath = "category_name";
            cmbCategory.ItemsSource = AuxClasses.DBClass.entObj.category.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool debt = (cmbDebt.Text == "Нет") ? false : true;
            bool intercity = (cmbIntercity.Text == "Нет") ? false : true;
            int ptid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbPhoneType.SelectionBoxItem)["id"].GetValue(cmbPhoneType.SelectionBoxItem));
            int catid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbCategory.SelectionBoxItem)["id"].GetValue(cmbCategory.SelectionBoxItem));
            customer = new AuxClasses.customer()
            { 
                name = txbName.Text,
                gender = Convert.ToString(cmbGender.Text[0]),
                age = Convert.ToInt32(txbAge.Text),
                phone_type_id = ptid,
                ate_id = _ate_id,
                category_id = catid,
                has_debt = debt,
                has_intercity = intercity,
            };
            AuxClasses.DBClass.entObj.customer.Add(customer);
            AuxClasses.DBClass.entObj.SaveChanges();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminList")
                AuxClasses.FrameClass.frmObj.Navigate(new PageAdminList(_ate_id));
            else
                AuxClasses.FrameClass.frmObj.Navigate(new PageList(_ate_id));
        }

        private void txbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsNumberAllowed(e.Text);
        }

        private void txbAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
