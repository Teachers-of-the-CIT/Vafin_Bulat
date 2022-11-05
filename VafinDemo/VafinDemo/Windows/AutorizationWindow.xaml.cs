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
using VafinDemo.Models;
using VafinDemo.Windows;

namespace VafinDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }
        public void ImportPhotos()
        {
            var images = Directory.GetFiles(@"E:\demo\Vafin_Bulat\4438_ДЭ\Сессия\Товар_import");
            using (PerfumeryEntities db = new PerfumeryEntities())
            {
                foreach (var item in db.Product)
                {
                    try
                    {
                        item.Preview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(item.Code)));
                    }
                    catch
                    {
                        item.Preview = null;
                    }
                }
                db.SaveChanges();
            }
        }
        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new PerfumeryEntities())
            {
                Window form;
                USer loggedUser = null;
                foreach (USer user in db.USer)
                {
                    if (LoginTb.Text == user.Login && PasswordTb.Text == user.Password)
                    {
                        loggedUser = user;
                        break;
                    }
                }
                if (loggedUser == null)
                {
                    MessageBox.Show("Введены неправильные данные!");
                    return;
                }
                switch (loggedUser.Role)
                {
                    case "Клиент":
                        form = new ClientWindow(loggedUser);
                        break;
                    case "Менеджер":
                        form = new ManagerWindow(loggedUser);
                        break;
                    case "Администратор":
                        form = new AdministratorWindow(loggedUser);
                        break;
                    default:
                        MessageBox.Show(string.Format("Ошибка: неизвестная роль пользователя! ({0})", loggedUser.Role));
                        return;
                }
                form.Show();
                this.Close();
                return;
            }
        }
    }
}
