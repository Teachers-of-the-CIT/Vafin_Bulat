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
using VafinDemo.Windows;
using VafinDemo.Models;

namespace VafinDemo.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        USer loggedUser = new USer();
        List<Order> ordersToList = new List<Order> { };
        public ManagerWindow()
        {
            InitializeComponent();

        }
        public ManagerWindow(USer uSer)
        {
            InitializeComponent();
            this.loggedUser = uSer;

            var productsToList = PerfumeryEntities.GetContext().Product.ToList();
            ProductsLv.ItemsSource = productsToList;

            ordersToList = PerfumeryEntities.GetContext().Order.ToList();
            OrdersDataGrid.ItemsSource = ordersToList;
        }
        public void UpdateDataGrid(Order order)
        {
            ordersToList.Add(order);
            OrdersDataGrid.ItemsSource = ordersToList;
        }
        public void UpdateChangedDataGrid(Order changedOrder)
        {
            var allOrders = PerfumeryEntities.GetContext().Order.ToList();
            foreach (var currentOrder in allOrders)
            {
                if (changedOrder.Id == currentOrder.Id)
                {
                    currentOrder.Creation_date = changedOrder.Creation_date;
                    currentOrder.Order_date = changedOrder.Order_date;
                    currentOrder.Surname = changedOrder.Surname;
                    currentOrder.Name = changedOrder.Name;
                    currentOrder.Patronymic = changedOrder.Patronymic;
                    currentOrder.Receive_code = changedOrder.Receive_code;
                    currentOrder.Status = changedOrder.Status;
                }
            }
            OrdersDataGrid.ItemsSource = allOrders;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            this.Close();
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.Visibility = Visibility.Hidden;
            AddOrderBtn.Visibility = Visibility.Hidden;
            ProductsLv.Visibility = Visibility.Visible;
        }

        private void EditOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentOrder = (sender as Button).DataContext as Order;
            OrderEditWindow orderEditWindow = new OrderEditWindow(this, loggedUser, currentOrder);
            orderEditWindow.Show();
            this.Close();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderEditWindow orderEditWindow = new OrderEditWindow(this, loggedUser);
            orderEditWindow.Show();
            this.Close();
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.Visibility = Visibility.Visible;
            AddOrderBtn.Visibility = Visibility.Visible;
            ProductsLv.Visibility = Visibility.Hidden;
        }
    }
}
