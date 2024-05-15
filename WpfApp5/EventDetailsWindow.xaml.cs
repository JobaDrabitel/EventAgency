using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для EventDetailsWindow.xaml
    /// </summary>
    public partial class EventDetailsWindow : Window
    {
        public IEnumerable<City> Cities = new List<City>();
        public Window Window = new Window();
        public Event Event = new Event();
        public EventDetailsWindow(int id, Window window)
        {

            using (ModelEvent db = new ModelEvent())
            {
                Event = db.Event.Find(id);
                Cities = db.City.ToList();
            }
            InitializeComponent();
            IdTextBox.Text = Event.Id.ToString();

            Window.IsEnabled = false;
            this.Resources.Add("Cities", Cities);
            DatePicker.DisplayDateStart = DateTime.Now;
        }
        public EventDetailsWindow(Window window)
        {

            using (ModelEvent db = new ModelEvent())
            {
                Cities = db.City.ToList();
            }
            InitializeComponent();
            window.IsEnabled = false;
            this.Resources.Add("Cities", Cities);
            DatePicker.DisplayDateStart = DateTime.Now;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отменить?", "Отмена", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Window.IsEnabled = true;
                Window.Activate();
                this.Close();
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(EventNameTextBox.Text)))
            {
                MessageBox.Show("Введите все поля");
            }
            else
            {
                Event.EventName = EventNameTextBox.Text;
                var city = (City)CityComboBox.SelectedItem;
                Event.CityId = city.Id;
                Event.DaysCount = (int)DaysSlider.Value;
                Event.StartDate = DatePicker.SelectedDate;
                using (ModelEvent db = new ModelEvent())
                {
                    db.Event.AddOrUpdate(Event);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                    Window.IsEnabled = true;
                    Window.Activate();
                    this.Close();
                }
                MessageBox.Show("Чет не так(");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window.IsEnabled = true;
            Window.Activate();
            this.Close();
        }
    }
}
