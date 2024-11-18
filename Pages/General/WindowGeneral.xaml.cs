using GTS.AuxClasses;
using iText.Layout;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GTS.Pages.General
{
    /// <summary>
    /// Interaction logic for WindowGeneral.xaml
    /// </summary>
    public partial class WindowGeneral : Window
    {
        private string _page_name;
        private string _filepath;
        private phone_number_customer pnc;
        public WindowGeneral(object item, string page_name)
        {
            InitializeComponent();
            _page_name = page_name;
            DataContext = item;
            if (item is null)
            {
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.ToList();
            }
            if (item != null)
            {
                MenuItem menuAdd = new MenuItem();
                menuAdd.Header = "Добавить";
                menuAdd.Click += menuAdd_Click;
                this.menuGeneral.Items.Add(menuAdd);

                if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
                {
                    var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)id).ToList();
                }

                if (_page_name == "PageAdminList" || _page_name == "PageList")
                {
                    var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)id).ToList();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window windowGeneral = Window.GetWindow(this);
            windowGeneral.Close();
        }
        private void menuAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
            {
                int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext));
                WindowAddCustomer windowAddCustomer = new WindowAddCustomer(phone_id);
                windowAddCustomer.ShowDialog();
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)phone_id).ToList();
            }

            if (_page_name == "PageAdminList" || _page_name == "PageList")
            {
                int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext));
                WindowAddPhone windowAddPhone = new WindowAddPhone(customer_id);
                windowAddPhone.ShowDialog();
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)customer_id).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
            {
                var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["customer_id"].GetValue(dgrGeneral.SelectedItem));
                pnc = DBClass.entObj.phone_number_customer.FirstOrDefault(x => x.customer_id == customer_id);
                if (MessageBox.Show("Вы уверены?", "Отвязка абонента", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.phone_number_customer.Remove(pnc);
                    DBClass.entObj.SaveChanges();
                }
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)id).ToList();
            }

            if (_page_name == "PageAdminList" || _page_name == "PageList")
            {
                var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["phone_number_id"].GetValue(dgrGeneral.SelectedItem));
                pnc = DBClass.entObj.phone_number_customer.FirstOrDefault(x => x.phone_number_id == phone_id);
                if (MessageBox.Show("Вы уверены?", "Отвязка телефона", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBClass.entObj.phone_number_customer.Remove(pnc);
                    DBClass.entObj.SaveChanges();
                }
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)id).ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int customer_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["customer_id"].GetValue(dgrGeneral.SelectedItem));
            int phone_id = Convert.ToInt32(TypeDescriptor.GetProperties(dgrGeneral.SelectedItem)["phone_number_id"].GetValue(dgrGeneral.SelectedItem));
            pnc = DBClass.entObj.phone_number_customer.FirstOrDefault(x => x.customer_id == customer_id && x.phone_number_id == phone_id);
            WindowEditFee windowEditFee = new WindowEditFee(pnc);
            windowEditFee.ShowDialog();
            if (DataContext != null)
            {
                var id = TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext);
                if (_page_name == "PageAdminPhone" || _page_name == "PagePhone")
                {
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.phone_number_id == (int)id).ToList();
                }

                if (_page_name == "PageAdminList" || _page_name == "PageList")
                {
                    dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.Where(x => x.customer_id == (int)id).ToList();
                }
            }
            else
            {
                dgrGeneral.ItemsSource = AuxClasses.DBClass.entObj.phone_number_customer.ToList();
            }
        }

        private void menuReport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Отчет";
            sfd.DefaultExt = ".pdf";

            PdfFont font = PdfFontFactory.CreateFont($"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\Assets\\arial.ttf", "Identity-H");

            bool? result = sfd.ShowDialog();

            if (result == true)
            {
                _filepath = sfd.FileName;

                using (PdfWriter writer = new PdfWriter(_filepath))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document doc = new Document(pdf, PageSize.A4);
                        doc.SetFont(font);
                        Table table = new Table(dgrGeneral.Columns.Count - 1);

                        foreach (var column in dgrGeneral.Columns)
                        {
                            if (column.Header.ToString() != "Опции")
                                table.AddHeaderCell(new Cell().Add(new Paragraph(column.Header.ToString())));
                        }

                        foreach (var item in dgrGeneral.Items)
                        {
                            foreach (var column in dgrGeneral.Columns)
                            {
                                if (column.Header.ToString() != "Опции" && column.Header.ToString() == "Номер телефона")
                                {
                                    object cell = TypeDescriptor.GetProperties(item)["phone_number"].GetValue(item);
                                    string cellValue = TypeDescriptor.GetProperties(cell)["full_number"].GetValue(cell).ToString();
                                    table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                                }
                                if (column.Header.ToString() != "Опции" && column.Header.ToString() == "Абонент")
                                {
                                    object cell = TypeDescriptor.GetProperties(item)["customer"].GetValue(item);
                                    string cellValue = TypeDescriptor.GetProperties(cell)["name"].GetValue(cell).ToString();
                                    table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                                }
                                if (column.Header.ToString() != "Опции" && column.Header.ToString() != "Абонент" && column.Header.ToString() != "Номер телефона")
                                {
                                    var cellContent = TypeDescriptor.GetProperties(item)[$"{column.SortMemberPath}"].GetValue(item);
                                    string cellValue = cellContent != null ? cellContent.ToString() : string.Empty;
                                    table.AddCell(new Cell().Add(new Paragraph(cellValue)));
                                }
                            }
                        }

                        doc.Add(table);
                        doc.Close();
                    }
                }
                MessageBox.Show($"Отчет сохранен по данному пути: {_filepath}");
            }
        }
    }
}