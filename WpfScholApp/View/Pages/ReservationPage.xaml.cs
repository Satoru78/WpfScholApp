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
    /// Логика взаимодействия для ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public Service Service { get; set; }
        public ServiceClient ServiceClient { get; set; }
        public List<Client> Clients { get; set; }
        public List<Service> Services { get; set; }
        public ReservationPage(ServiceClient serviceClient)
        {
            InitializeComponent();
            Services = DataApp.bd.Service.ToList();
            Clients = DataApp.bd.Client.ToList();
            ServiceClient = serviceClient;
            this.DataContext = this;
        }

        private void SaveBtn2_Click(object sender, RoutedEventArgs e)
        {

            if (ServiceClient.ID == 0)
            {
                DataApp.bd.ServiceClient.Add(ServiceClient);
                DataApp.bd.SaveChanges();
                MessageBox.Show("Service registered", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
        }
    }
}
