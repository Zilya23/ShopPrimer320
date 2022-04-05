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
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        Product contProduct;
        public TestPage (Product postProduct)
        {
            InitializeComponent();
          
            contProduct = postProduct;
            this.DataContext = contProduct;
            var lis = contProduct.ProductCountry.ToList();
            MessageBox.Show(lis.ToString());
            List1.ItemsSource = MainWindow.db.Country.ToList();



        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
          


        }
        private void List2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
