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
using WpfScholApp.Context;
using WpfScholApp.Model;

namespace WpfScholApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<Service> Service { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionPage(new Model.Service()));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Service)ListDataView.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new ActionPage(selectedItem));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Service)ListDataView.SelectedItem;
            if (selectedItem != null)
            {
                DataApp.bd.Service.Remove(selectedItem);
                DataApp.bd.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Data deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListDataView.ItemsSource = DataApp.bd.Service.Where(item => item.Title.ToString().Contains(Search.Text) || item.Time.ToString().Contains(Search.Text) || item.Cost.ToString().Contains(Search.Text) ||
            item.Discount.ToString().Contains(Search.Text)).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Service = DataApp.bd.Service.ToList();
            ListDataView.ItemsSource = Service;
        }

        private void RezBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReservationPage(new ServiceClient()));
        }
    }
}
