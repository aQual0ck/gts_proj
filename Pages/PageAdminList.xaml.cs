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

namespace GTS.Pages
{
    /// <summary>
    /// Interaction logic for PageAdminList.xaml
    /// </summary>
    public partial class PageAdminList : Page
    {
        private int _need_id;
        private AuxClasses.ate a;
        public PageAdminList(int chosen_ate_id)
        {
            InitializeComponent();
            dgrCustomer.ItemsSource = AuxClasses.DBClass.entObj.customer.Where(x => x.ate_id == chosen_ate_id).ToList();
            _need_id = chosen_ate_id;
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageAdminATS());
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            a = AuxClasses.DBClass.entObj.ate.FirstOrDefault(x => x.id == _need_id);
            MessageBoxResult result = MessageBox.Show("Вы уверены?");
            if (result == MessageBoxResult.OK)
            {
                AuxClasses.DBClass.entObj.ate.Remove(a);
                AuxClasses.DBClass.entObj.SaveChanges();
                AuxClasses.FrameClass.frmObj.Navigate(new PageAdminATS());
            }
        }
    }
}
