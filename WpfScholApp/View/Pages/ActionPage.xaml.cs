using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfScholApp.Context;
using WpfScholApp.Model;

namespace WpfScholApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ActionPage.xaml
    /// </summary>
    public partial class ActionPage : Page
    {

        public Service Service { get; set; }
        public ActionPage(Service service)
        {
            InitializeComponent();
            Service = service;
            this.DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Service.ID == 0)
            {
                DataApp.bd.Service.Add(Service);
            }
            File.Copy(file.FileName, $"photos\\{System.IO.Path.GetFileName(file.FileName).Trim()}", true);
            Service.GetPhoto = "\\photos\\" + System.IO.Path.GetFileName(file.FileName);
            DataApp.bd.SaveChanges();
            MessageBox.Show("Data add", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }
        OpenFileDialog file = new OpenFileDialog();
        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            file.Filter = "Image (*.jpg;*.jpeg;*.png;) |  *.jpg; *.jpeg; *.png";
            if (file.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(file.FileName));
                Img.Source = image;
            }
        }
    }
}
