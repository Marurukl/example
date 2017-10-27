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
using System.IO;

namespace CreditBank
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        User user;
        public RegistrationPage()
        {
            InitializeComponent();
            user = new User();
            List<string> styles = new List<string> { "BlueTemp", "GreenTemp", "RedTemp","DarkTemp" };
            styleComboBox.SelectionChanged += ThemeChange;
            styleComboBox.ItemsSource = styles;
            styleComboBox.SelectedItem = "DarkTemp";
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleComboBox.SelectedItem as string;
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private string path = @"C:\Users\закарьянова\Desktop";
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(registerINNTextBox.Text))
            {
                user.GetPassword(registerINNTextBox.Text);
                MessageBox.Show(user.Password);
                using(FileStream fs=new FileStream(path+@"\"+registerINNTextBox.Text+@".txt" , FileMode.Create))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(user.Password);
                    fs.Write(array, 0, array.Length);
                    fs.Close();
                }
                (this.Parent as MainWindow).NavigationService.Navigate(new AuthorizationPage());
            }
            else
            {
                MessageBox.Show("Пустой Иин");
            }
        }
    }
}
