using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
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

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        string picPath = "";
        public MainWindow() {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            Customer customer = new Customer();

            customer.Name = NameTextBox.Text;
            customer.Phone = PhoneTextBox.Text;
            customer.Address = AddressTextBox.Text;
            customer.Picture = null;

            if (picPath != "") {
                Bitmap bmp = new Bitmap(picPath);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                customer.Picture = ms.ToArray();
                picPath = "";
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase(); //ListView表示
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {



        }
        //ListView表示
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

                CustomerListView.ItemsSource = _customers;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase(); //ListView表示
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase(); //ListView表示
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CustomerListView.SelectedIndex != -1) {
                NameTextBox.Text = _customers[CustomerListView.SelectedIndex].Name;
                PhoneTextBox.Text = _customers[CustomerListView.SelectedIndex].Phone;
                AddressTextBox.Text = _customers[CustomerListView.SelectedIndex].Address;
                PictureImageBox.Source = Create(_customers[CustomerListView.SelectedIndex].Picture);
            }
        }
        public static BitmapImage Create(byte[] bytes) {
            var result = new BitmapImage();

            using (var stream = new MemoryStream(bytes)) {
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.CreateOptions = BitmapCreateOptions.None;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();    // 非UIスレッドから作成する場合、Freezeしないとメモリリークするため注意
            }
            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != null) {
                picPath = ofd.FileName;
                PictureImageBox.Source = new BitmapImage(new Uri(picPath, UriKind.Absolute));
            }
        }
    }
}
