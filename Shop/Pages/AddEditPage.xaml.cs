using Microsoft.Win32;
using Shop.DataBasee;
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

namespace Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Product contProduct;
        public AddEditPage( Product postProduct)
        {
            InitializeComponent();
        
            CountryCb.ItemsSource = MainWindow.db.Country.ToList();
            CountryCb.DisplayMemberPath = "Name";

            UnitCb.ItemsSource = MainWindow.db.Unit.ToList();
      
            contProduct = postProduct;
            this.DataContext = contProduct;
            if (contProduct.Id !=0)
            {
                AddCountryBtn.Visibility = Visibility.Visible;
                DelCountryBtn.Visibility = Visibility.Visible;

            }
            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        { 
            contProduct.UnitId= (UnitCb.SelectedItem as Unit).Id;
            contProduct.AddDate = DateTime.Now;
            if (contProduct.Id == 0) MainWindow.db.Product.Add(contProduct);

            MainWindow.db.SaveChanges();

            AddCountryBtn.Visibility = Visibility.Visible;
            DelCountryBtn.Visibility = Visibility.Visible;
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                contProduct.Photo = File.ReadAllBytes(openFile.FileName);
                PhotoProductImg.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void AddCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            
           

        }
        private void UpdateCountryList()
        {
            CountryLv.ItemsSource = MainWindow.db.ProductCountry.Where(e=> e.ProductId == contProduct.Id).ToList();
        }

        private void DelCountryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
