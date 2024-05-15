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
        public User User { get; set; }
        public readonly List<string> Sorts = new List<string>() { "Id", "Название", "Дата начала", "Дни", "Город" };
        private static List<Event> Events = new List<Event>();
        public EventsWindow(int? id)
        {
            using (var db = new ModelEvent())
            {
                Events = db.Event.Include("City").ToList();
            }
            if (id != null)
            {
                using (var db = new ModelEvent())
                {
                    User = db.User.Find(id);
                }
            }
            this.Resources.Add("k", Events);
            this.Resources.Add("Sorts", Sorts);
            InitializeComponent();
            LoginButton.Visibility = Visibility.Collapsed;
            if (User.Role == ((int)Role.Organizer)||true)
            {
                ModerStackPanel.Visibility = Visibility.Visible;
            }
        }

        public EventsWindow()
        {
            using (var db = new ModelEvent())
            {
                Events = db.Event.Include("City").ToList();
            }


            this.Resources.Add("k", Events);
            this.Resources.Add("Sorts", Sorts);
            InitializeComponent();
            ProfileButton.Visibility = Visibility.Collapsed;
        }

        private void FilterButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                using (var db = new ModelEvent())
                {
                    Events = db.Event.Include("City").ToList();
                }
            }
            else
            {
                using (var db = new ModelEvent())
                {
                    Events = db.Event.Include("City").Where(o => o.EventName.Contains(SearchTextBox.Text)).ToList();
                }
                SortComboBox.SelectedIndex = 0;
                this.Resources["k"]= Events;
            }

        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }

        private void DatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new ModelEvent())
            {
                Events = db.Event.Include("City").Where(o => o.StartDate == DatePicker.SelectedDate).ToList();
            }
            this.Resources["k"]= Events;
            SortComboBox.SelectedIndex = 0;

        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SortComboBox.SelectedIndex)
            {
                case 0:
                    this.Resources["k"]=Events.OrderBy(o => o.Id);
                    break;
                case 1:
                    this.Resources["k"]=Events.OrderBy(o => o.EventName);
                    break;
                case 2:
                    this.Resources["k"]= Events.OrderBy(o => o.StartDate);
                    break;
                case 3:
                    this.Resources["k"] = Events.OrderBy(o => o.DaysCount);
                    break;
                case 4:
                    this.Resources["k"]=Events.OrderBy(o => o.City.CityName);
                    break;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (listi.SelectedItem != null)
            {
                try
                {
                    var selected = (Event)listi.SelectedItem;
                    if (MessageBox.Show("Удалить?", "Удалить запись", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        using (var db = new ModelEvent())
                        {
                            var found = db.Event.Find(selected.Id);
                            db.Event.Remove(found);
                            db.SaveChanges();
                            EventsWindow eventsWindow = new EventsWindow(User.Id);
                            eventsWindow.Show();
                            this.Close();
                        }
                    }
                }
                catch { }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EventDetailsWindow eventDetailsWindow = new EventDetailsWindow(this);
            eventDetailsWindow.Show();
            EventsWindow eventsWindow = new EventsWindow(User.Id);
            eventsWindow.Show();
            this.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (listi.SelectedItem != null)
            {
                var selected = (Event)listi.SelectedItem;
                EventDetailsWindow eventDetailsWindow = new EventDetailsWindow(selected.Id, this);
                eventDetailsWindow.Show();
                EventsWindow eventsWindow = new EventsWindow(User.Id);
                eventsWindow.Show();
                this.Close();
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(User.Id);
            userWindow.Show();
            this.Close();
        }
    }
}

