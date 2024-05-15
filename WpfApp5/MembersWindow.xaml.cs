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
    /// Логика взаимодействия для MembersWindow.xaml
    /// </summary>
    public partial class MembersWindow : Window
    {
        private static int UserId { get; set; }
        private static List<User> Users = new List<User>();
        private static List<Activity> Activities = new List<Activity>();
        public MembersWindow(int id)
        {
            UserId = id;
            using (var db = new ModelEvent())
            {
                Users = db.User.Include("Activity6").Include("Country").ToList();
            }


            this.Resources.Add("k", Users);
            this.Resources.Add("A", Activities);
            InitializeComponent();
        }


        private void listi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listi.SelectedItem != null)
            {
                var user = listi.SelectedItem as User;
                this.Resources["A"]= Users.Find(u => u.Id == user.Id).Activity6;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow authWindow = new UserWindow(UserId);
            authWindow.Show();
            Close();
        }
    }
}
