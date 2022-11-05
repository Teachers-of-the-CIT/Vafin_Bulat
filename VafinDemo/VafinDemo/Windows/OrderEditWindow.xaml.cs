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
using System.Runtime.ConstrainedExecution;

namespace VafinDemo.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderEditWindow.xaml
    /// </summary>
    public partial class OrderEditWindow : Window
    {
        private readonly AdministratorWindow window;
        private readonly ManagerWindow manager_window;
        USer loggedUser = new USer();
        Order currentOrder = new Order();
        int actionStatus = 0;
        public OrderEditWindow()
        {
            InitializeComponent();
        }
        public OrderEditWindow(AdministratorWindow administratorWindow, USer user, Order currentOrder)
        {
            InitializeComponent();
            this.window = administratorWindow;
            this.loggedUser = user;
            this.currentOrder = currentOrder;
            actionStatus = 2;
        }
        public OrderEditWindow(ManagerWindow managerWindow, USer user, Order currentOrder)
        {
            InitializeComponent();
            this.manager_window = managerWindow;
            this.loggedUser = user;
            this.currentOrder = currentOrder;
            actionStatus = 2;
        }
        public OrderEditWindow(AdministratorWindow administratorWindow, USer user)
        {
            InitializeComponent();
            this.window = administratorWindow;
            this.loggedUser = user;
            actionStatus = 1;
        }
        public OrderEditWindow(ManagerWindow managerWindow, USer user)
        {
            InitializeComponent();
            this.manager_window = managerWindow;
            this.loggedUser = user;
            actionStatus = 1;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Window form = new Window();
            if (actionStatus == 1)
            {
                using (var db = new PerfumeryEntities())
                {
                    foreach (Order ordr in db.Order)
                    {
                        if (SurnameTb.Text == ordr.Surname || NameTb.Text == ordr.Name)
                        {
                            MessageBox.Show("Такой заказ уже существует!");
                            return;
                        }
                    }
                    if (SurnameTb.Text == "" || NameTb.Text == "" || PatronymicTb.Text == "" || CreationDateTb.Text == "" || OrderDateTb.Text == "" || ReceiveCodeTb.Text == "" || StatusTb.Text == "")
                    {
                        MessageBox.Show("Пожалуйста заполните все поля!");
                        return;
                    }
                    Order order = new Order();
                    string date = CreationDateTb.Text;
                    string[] dates = date.Split('.');
                    string yearString = dates[0].Substring(0, 4);
                    int year = Int32.Parse(yearString);
                    int month = int.Parse(dates[1]);
                    int days = int.Parse(dates[2]);
                    DateTime dateTime = new DateTime(year, month, days);
                    order.Creation_date = dateTime;
                    string date2 = OrderDateTb.Text;
                    string[] date2s = date.Split('.');
                    string yearString2 = dates[0].Substring(0, 4);
                    int year2 = Int32.Parse(yearString);
                    int month2 = int.Parse(dates[1]);
                    int days2 = int.Parse(dates[2]);
                    DateTime dateTime2 = new DateTime(year2, month2, days2);
                    order.Order_date = dateTime2;
                    order.Surname = SurnameTb.Text;
                    order.Name = NameTb.Text;
                    order.Patronymic = PatronymicTb.Text;
                    order.Receive_code = Int32.Parse(ReceiveCodeTb.Text);
                    order.Status = StatusTb.Text;
                    db.Order.Add(order);
                    db.SaveChanges();

                    MessageBox.Show("Заказ успешно добавлен!");
                    form = new AdministratorWindow(loggedUser);
                    window.UpdateDataGrid(order);
                    manager_window.UpdateDataGrid(order);
                }
            }
            if (actionStatus == 2)
            {
                using (var db = new PerfumeryEntities())
                {
                    foreach (var order in db.Order)
                    {
                        if (currentOrder.Id == order.Id)
                            currentOrder = order;
                    }
                    currentOrder = db.Order.Find(currentOrder.Id);
                    string date = CreationDateTb.Text;
                    string[] dates = date.Split('.');
                    string yearString = dates[0].Substring(0, 4);
                    int year = Int32.Parse(yearString);
                    int month = int.Parse(dates[1]);
                    int days = int.Parse(dates[2]);
                    DateTime dateTime = new DateTime(year, month, days);
                    currentOrder.Creation_date = dateTime;
                    string date2 = OrderDateTb.Text;
                    string[] date2s = date.Split('.');
                    string yearString2 = dates[0].Substring(0, 4);
                    int year2 = Int32.Parse(yearString);
                    int month2 = int.Parse(dates[1]);
                    int days2 = int.Parse(dates[2]);
                    DateTime dateTime2 = new DateTime(year2, month2, days2);
                    currentOrder.Order_date = dateTime2;
                    currentOrder.Surname = SurnameTb.Text;
                    currentOrder.Name = NameTb.Text;
                    currentOrder.Patronymic = PatronymicTb.Text;
                    currentOrder.Receive_code = Int32.Parse(ReceiveCodeTb.Text);
                    currentOrder.Status = StatusTb.Text;
                    db.SaveChanges();
                    MessageBox.Show(String.Format("Заказ №{0} успешно изменен!", currentOrder.Id));
                    form = new AdministratorWindow(loggedUser);
                    window.UpdateChangedDataGrid(currentOrder);
                    manager_window.UpdateChangedDataGrid(currentOrder);
                }
            }
            form.Show();
            this.Hide();
        }
    }
}
