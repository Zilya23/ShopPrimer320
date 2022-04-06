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
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.Navigate(new AuthPage());
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
