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
            var LvUnit = MainWindow.db.Unit.ToList();
            LvUnit.Insert(0, new Unit() { Id = -1, Name = "Все" });
            UnitCb.ItemsSource = LvUnit;
            UnitCb.DisplayMemberPath = "Name";

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
                if (result == MessageBoxResult.OK)
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
       
        private void Refresh()
        {
          var FilterProduct = (IEnumerable<Product>)MainWindow.db.Product.ToList();

            if (!string.IsNullOrWhiteSpace(SearchNameDescTb.Text))
                FilterProduct = FilterProduct.Where(c => c.Name.StartsWith(SearchNameDescTb.Text) || c.Description.StartsWith(SearchNameDescTb.Text));

            if (UnitCb.SelectedIndex > 0)
                FilterProduct = FilterProduct.Where(c => c.UnitId == (UnitCb.SelectedItem as Unit).Id || c.UnitId == -1);

            //if (DateMounthBtn.IsPressed)
            //{
            //    var date = DateTime.Now.Month;
            //    ProductList.ItemsSource = FilterProduct.Where(c => c.AddDate.Month == date);
            //}
            
            if (DateCb.SelectedIndex == 1) 
                FilterProduct = FilterProduct.OrderBy(c => c.AddDate);
            else 
                FilterProduct = FilterProduct.OrderByDescending(c => c.AddDate);

            if (AlfCb.SelectedIndex == 1)
                FilterProduct = FilterProduct.OrderBy(c => c.Name);
            else
                FilterProduct = FilterProduct.OrderByDescending(c => c.Name);

            ProductList.ItemsSource = FilterProduct;
        }


    
        private void UnitCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchNameDescTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }      

        private void DateMounthBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void DateCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AlfCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
            
    
