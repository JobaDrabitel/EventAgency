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
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для ModeratorRegWindow.xaml
    /// </summary>
    public partial class ModeratorRegWindow : Window
    {
        public IEnumerable<Gender> Gender = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        public IEnumerable<Role> Role = Enum.GetValues(typeof(Role)).Cast<Role>();
        public ModeratorRegWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Хотите отменить создание?",
                    "Отмена",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Close();
            }
            
        }
    }
}
