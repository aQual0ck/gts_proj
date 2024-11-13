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
using System.Windows.Threading;

namespace GTS.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();

            txbLogin.Focus();
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbLogin.Text != "" && txbPassword.Text != "")
                {
                    var userObj = AuxClasses.DBClass.entObj.users.FirstOrDefault(x => x.username == txbLogin.Text && x.password == txbPassword.Text);
                    if (userObj == null)
                    {
                        tbWarning.Visibility = Visibility.Visible;
                    }
                    else if (userObj.role_id == 1)
                    {
                        AuxClasses.FrameClass.frmObj.Navigate(new PageAdminATS());
                    }
                    else
                    {
                        AuxClasses.FrameClass.frmObj.Navigate(new PageATS());
                    }
                }
                else
                {
                    tbNoText.Visibility = Visibility.Visible;
                    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                    timer.Start();
                    timer.Tick += (sender1, args) =>
                    {
                        timer.Stop();
                        tbNoText.Visibility = Visibility.Visible;
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
