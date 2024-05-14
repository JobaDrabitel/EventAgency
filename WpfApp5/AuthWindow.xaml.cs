using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp5.Model;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private static readonly Regex _regex = new Regex("[0-9]");
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Reg1Button_Click(object sender, RoutedEventArgs e)
        {
            ModeratorRegWindow authWindow = new ModeratorRegWindow();
            authWindow.Show();
            this.Close();
        }
        private void Reg2Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow authWindow = new MainWindow();
            authWindow.Show();
            this.Close();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var regex = new Regex("[0-9]");
            if (Validator.ValidateNumber(IdTextBox.Text))
            {
                try
                {
                    using (ModelEvent db = new ModelEvent())
                    {
                        int.TryParse(IdTextBox.Text, out var key);
                        var user = db.User.Find(key);
                        if (user != null)
                        {
                            if (user.Password == PasswordTBox.Password)
                            {
                                EventsWindow eventsWindow = new EventsWindow(user.Id);
                                eventsWindow.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Неправильный пароль");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден");
                        }
                    }
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Введите Id");
            }
        }

        private void EventsButton_OnClick(object sender, RoutedEventArgs e)
        {
            EventsWindow window = new EventsWindow(null);
            window.Show();
            Close();
        }
    }
}
