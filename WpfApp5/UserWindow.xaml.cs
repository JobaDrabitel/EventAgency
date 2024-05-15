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
    /// Логика взаимодействия для UserRegWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public User User { get; set; }
        public UserWindow(int id)
        {

            try
            {
                using (ModelEvent db = new ModelEvent())
                {
                    User = db.User.Find(id);
                }
            }
            catch
            {
                this.Close();
            }
            
            InitializeComponent();
GreetText.Text = Text(User);
        }

        public UserWindow()
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            EventsWindow eventsWindow = new EventsWindow(User.Id);
            eventsWindow.Show();
            this.Close();
        }

        private void MembersButton_Click(object sender, RoutedEventArgs e)
        {
            MembersWindow membersWindow = new MembersWindow(User.Id);
            membersWindow.Show();
            this.Close();
        }

        private void JudgesButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private string Text(User user)
        {
            var s = "Утро";
            if (DateTime.Now.Hour >= 11)
            {
                s = "День";
            }
            if (DateTime.Now.Hour >= 18)
            {
                s = "Вечер";
            }
            s += "\n";
            switch (User.Gender)
            {
                case "м":
                    s += "Дядя ";
                    break;
                case "ж":
                    s += "Тетя ";
                    break;
            }
            s += user.UserName;
            return s;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
