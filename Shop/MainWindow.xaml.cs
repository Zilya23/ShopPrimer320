using Shop.DataBasee;
using Shop.Pages;
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

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Ent db = new Ent();
        public static User AuthUser;
        public static MainWindow main;
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Navigated += MyFrame_Navigated;
            MyFrame.Navigate(new AuthPage());
        }

        private void MyFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MyFrame.Content is Pages.AuthPage)
            {
                ForwardBtn.Visibility = Visibility.Hidden;
                BackBtn.Visibility = Visibility.Hidden;
                
            }
            else
            {
                ForwardBtn.Visibility = Visibility.Visible;
                BackBtn.Visibility = Visibility.Visible;
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack) MyFrame.GoBack();
        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoForward) MyFrame.GoForward();
        }
    }
}
