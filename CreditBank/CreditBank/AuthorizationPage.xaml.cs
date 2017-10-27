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

namespace CreditBank
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        User user;
        public AuthorizationPage()
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
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as MainWindow).NavigationService.Navigate(new RegistrationPage());
        }

    }
}
