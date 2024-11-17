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
    /// Interaction logic for PageEditCustomer.xaml
    /// </summary>
    public partial class PageEditCustomer : Page
    {
        private AuxClasses.customer customer;
        private AuxClasses.phone_type pt;
        private AuxClasses.category cat;
        private string _page_name;
        private int _ate_id;
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
        public PageEditCustomer(object item, string page_name)
        {
            InitializeComponent();
            DataContext = item;
            _page_name = page_name;
            _ate_id = (int)TypeDescriptor.GetProperties(DataContext)["ate_id"].GetValue(DataContext);

            var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
            customer = AuxClasses.DBClass.entObj.customer.FirstOrDefault(x => x.id == (int)id);

            var pt_id = TypeDescriptor.GetProperties(DataContext)["phone_type_id"].GetValue(DataContext);
            var cat_id = TypeDescriptor.GetProperties(DataContext)["category_id"].GetValue(DataContext);
            pt = AuxClasses.DBClass.entObj.phone_type.FirstOrDefault(x => x.id == (int)pt_id);
            cat = AuxClasses.DBClass.entObj.category.FirstOrDefault(x => x.id == (int)cat_id);

            var gender_name = TypeDescriptor.GetProperties(DataContext)["gender"].GetValue(DataContext);
            if ((string)gender_name == "М")
                cmbGender.SelectedIndex = 0;
            else
                cmbGender.SelectedIndex = 1;

            var debt_bool = TypeDescriptor.GetProperties(DataContext)["has_debt"].GetValue(DataContext);
            if ((bool)debt_bool == true)
                cmbDebt.SelectedIndex = 0;
            else
                cmbDebt.SelectedIndex = 1;

            var intercity_bool = TypeDescriptor.GetProperties(DataContext)["has_intercity"].GetValue(DataContext);
            if ((bool)intercity_bool == true)
                cmbIntercity.SelectedIndex = 0;
            else
                cmbIntercity.SelectedIndex = 1;

            cmbPhoneType.SelectedValuePath = "phone_type_name";
            cmbPhoneType.DisplayMemberPath = "phone_type_name";
            cmbPhoneType.ItemsSource = AuxClasses.DBClass.entObj.phone_type.ToList();
            cmbPhoneType.SelectedValue = pt.phone_type_name;

            cmbCategory.SelectedValuePath = "category_name";
            cmbCategory.DisplayMemberPath = "category_name";
            cmbCategory.ItemsSource = AuxClasses.DBClass.entObj.category.ToList();
            cmbCategory.SelectedValue = cat.category_name;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminList")
                AuxClasses.FrameClass.frmObj.Navigate(new PageAdminList(_ate_id));
            else
                AuxClasses.FrameClass.frmObj.Navigate(new PageList(_ate_id));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int ptid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbPhoneType.SelectionBoxItem)["id"].GetValue(cmbPhoneType.SelectionBoxItem));
            int catid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbCategory.SelectionBoxItem)["id"].GetValue(cmbCategory.SelectionBoxItem));
            bool debt = (cmbDebt.Text == "Нет") ? false : true;
            bool intercity = (cmbIntercity.Text == "Нет") ? false : true;

            customer.name = txbName.Text;
            customer.gender = Convert.ToString(cmbGender.Text[0]);
            customer.age = Convert.ToInt32(txbAge.Text);
            customer.phone_type_id = ptid;
            customer.ate_id = _ate_id;
            customer.category_id = catid;
            customer.has_debt = debt;
            customer.has_intercity = intercity;

            AuxClasses.DBClass.entObj.SaveChanges();
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
