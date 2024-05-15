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
using WpfApp5.Model;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для ModeratorRegWindow.xaml
    /// </summary>
    public partial class ModeratorRegWindow : Window
    {
        public IEnumerable<Gender> Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        public IEnumerable<Role> Roles = new List<Role>() { Role.Moderator, Role.Judge };
        public IEnumerable<Activity> Events = new List<Activity>();
        public ModeratorRegWindow()
        {
            InitializeComponent();
            using (ModelEvent db = new ModelEvent())
            {
                Events = db.Activity.ToList();
            }
            this.Resources.Add("Genders", Genders);
            this.Resources.Add("Roles", Roles);
            this.Resources.Add("Events", Events);

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Validator.ValidateName(FullNameTextBlock.Text)&&
    Validator.ValidateEmail(EmailTextBlock.Text)&&
    Validator.ValidateNumber(PhoneTextBlock.Text)&&(PasswordTextBlock.Password != ""||PasswordTextBlock.Password.Length<8)))
            {
                if (PasswordTextBlock.Password == Password2TextBlock.Password)
                {
                    User user = new User();
                    user.UserName = FullNameTextBlock.Text;
                    user.Password = Password2TextBlock.Password;
                    user.Email = EmailTextBlock.Text.Trim().ToLower();
                    user.Phone = PhoneTextBlock.Text;
                    user.Gender = SexComboBox.SelectedItem.ToString();
                    if (RoleComboBox.SelectedIndex == 0)
                    {
                        user.Role = 2;
                        user.Specialization = SpecTextBlock.Text.Trim();

                    }
                    else
                    {
                        user.Role = 3;
                    }
                    using (ModelEvent db = new ModelEvent())
                    {

                        var mode = new User() { UserName = FullNameTextBlock.Text.Trim(), Email = EmailTextBlock.Text.Trim().ToLower(), Password = PasswordTextBlock.Password, Phone = PhoneTextBlock.Text.Trim() };
                        if (!db.User.Any(u => (u.Email.Trim().ToLower() == user.Email)))
                        {
                            db.User.Add(user);

                            var activity = (Activity)EventComboBox.SelectedItem;
                            if ((bool)AddToEventCheckBox.IsChecked)
                            {
                                var found = db.Activity.Find(activity.Id);
                                found.User = user;
                            }
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

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleComboBox.SelectedIndex == 1)
            {
                ModerStackPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                ModerStackPanel.Visibility = Visibility.Visible;
            }
        }
    }
}
