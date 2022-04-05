using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            //if (Properties.Settings.Default.Login != null) 
                LoginTb.Text = Properties.Settings.Default.Login;
        }

     
        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow.AuthUser = MainWindow.db.User.ToList().Find(c => c.Login == LoginTb.Text.Trim() && c.Password == PassTb.Text.Trim());
            if (MainWindow.AuthUser == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }
            if (CBRem.IsChecked.GetValueOrDefault())
            {
                Properties.Settings.Default.Login = MainWindow.AuthUser.Login;
                Properties.Settings.Default.Save();              
            }
            else
            {
                Properties.Settings.Default.Login = null;
                Properties.Settings.Default.Save();
            }

            switch (MainWindow.AuthUser.RoleId)
            {
                case 1:
                   
                    NavigationService.Navigate(new ProductListPage());
                    break;
                case 3:
                    NavigationService.Navigate(new ProductListPage());
                    break;
            }

            }
        }
    }


