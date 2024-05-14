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
    public partial class UserRegWindow : Window
    {
        public User User { get; set; }
        public UserRegWindow(int id)
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
        }

        public UserRegWindow()
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
