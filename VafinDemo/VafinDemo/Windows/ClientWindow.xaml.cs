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
using System.Windows.Shapes;
using VafinDemo.Models;

namespace VafinDemo.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        USer loggedUser = new USer();
        public ClientWindow()
        {
            InitializeComponent();
        }
        public ClientWindow(USer user)
        {
            InitializeComponent();
            this.loggedUser = user;

            var productsToList = PerfumeryEntities.GetContext().Product.ToList();
            ProductsLv.ItemsSource = productsToList;
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsLv.Visibility = Visibility.Visible;

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            this.Close();
        }
    }
}
