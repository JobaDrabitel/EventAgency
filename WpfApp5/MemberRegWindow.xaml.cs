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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.Model;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IEnumerable<Gender> Gender = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        public IEnumerable<Role> Role = Enum.GetValues(typeof(Role)).Cast<Role>();
        public MainWindow()
        {
            InitializeComponent();
            SexComboBox.ItemsSource = Gender;
            RoleComboBox.ItemsSource = Role;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Хотите отменить создание?",
                    "Отмена",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) != MessageBoxResult.Yes) return;
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Validator.ValidateName(FullNameTextBlock.Text)&&
                Validator.ValidateEmail(EmailTextBlock.Text)&&
                Validator.ValidateNumber(PhoneTextBlock.Text)&&(PasswordTextBlock.Password != ""||PasswordTextBlock.MaxLength<8)))
            {
                if (PasswordTextBlock.Password == Password2TextBlock.Password)
                {
                    using (ModelEvent db = new ModelEvent())
                    {
                        
                        var user = new User() { UserName = FullNameTextBlock.Text.Trim(), Email = EmailTextBlock.Text.Trim().ToLower(), Password = PasswordTextBlock.Password, Phone = PhoneTextBlock.Text.Trim() };
                        if(!db.User.Any(u => (u.Email.Trim().ToLower() == user.Email)))
                        {
                            db.User.Add(user);
                            db.SaveChanges();
                            MessageBox.Show("Регистрация успешна");
                            AuthWindow authWindow = new AuthWindow();
                            authWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с такой почтой уже существует");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!!!(");
                }

            }
            else
            {
                MessageBox.Show("Введите все необходимые поля");
            }
        }
    }
}
