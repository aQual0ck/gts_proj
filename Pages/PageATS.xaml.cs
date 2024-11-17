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
    /// Interaction logic for PageATS.xaml
    /// </summary>
    public partial class PageATS : Page
    {
        public PageATS()
        {
            InitializeComponent();
            DataContext = AuxClasses.DBClass.entObj;
            var converter = new BrushConverter();
            for (int i = 1; i <= AuxClasses.DBClass.entObj.ate.Count(); i++)
            {
                Button newBtn = new Button
                {
                    Content = "АТС" + i.ToString(),
                    Name = "ats_" + i.ToString(),
                    Height = 60,
                    Width = 120,
                    Foreground = Brushes.White,
                    Background = (Brush)converter.ConvertFrom("#66BBFF"),
                };
                newBtn.Click += newBtn_Click;
                buttonWP.Children.Add(newBtn);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AuxClasses.FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            string[] btns = btn.Name.Split('_');
            AuxClasses.FrameClass.frmObj.Navigate(new PageList(Convert.ToInt32(btns[1])));
        }
    }
}
