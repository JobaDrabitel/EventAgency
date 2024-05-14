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
    /// Логика взаимодействия для EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        private static List<Event> Events = new List<Event>();
        public EventsWindow()
        {
            using (var db = new ModelEvent())
            {
                Events = db.Event.Include("City").ToList();
            }
            this.Resources.Add("k", Events);
            InitializeComponent();
        }
    }
}
