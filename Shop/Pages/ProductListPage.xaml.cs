using Shop.DataBasee;
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

namespace Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            ProductList.ItemsSource = MainWindow.db.Product.ToList();
        }

        private void AddBtnt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(new Product()));

        }
        private void EditBtnt_Click(object sender, RoutedEventArgs e)
        {
            var isSelProduct = ProductList.SelectedItem as Product;
            if (isSelProduct != null)
                NavigationService.Navigate(new AddEditPage(isSelProduct));
            else
                MessageBox.Show("Ничего не выбрано!");
        }
        private void DelBtnt_Click(object sender, RoutedEventArgs e)
        {
            var isSelProduct = ProductList.SelectedItem as Product;
            if (isSelProduct != null)
            {
                var result = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                if( result == MessageBoxResult.OK)
                {
                    MainWindow.db.Product.Remove(isSelProduct);
                    MainWindow.db.SaveChanges();

                }

            }                   
            else
                MessageBox.Show("Ничего не выбрано!");

        }

        private void TestBtnt_Click(object sender, RoutedEventArgs e)
        {
            var sel = ProductList.SelectedItem as Product;
            NavigationService.Navigate(new TestPage(sel));
        }
    }
}
