using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Cables_1
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        CablesEntities _db = new CablesEntities();
        public MainWindow mainWindow;
        public static DataGrid resistGrid;
        public static DataGrid XresistGrid;
        public static DataGrid Losesgrid;
        public static DataGrid Thermalgrid;
        public static DataGrid Igrid;
        public AdminMenu(MainWindow _mainWindow)
        {
            InitializeComponent();
            Load();
            mainWindow = _mainWindow;
        }
        private void Load()
        {
            resistance.ItemsSource = _db.Resistance.ToList();
            Xresistance.ItemsSource = _db.XResistanceScreen.ToList();
            loses.ItemsSource = _db.Loses.ToList();
            Tresistance.ItemsSource = _db.ThermalResistance.ToList();
            current.ItemsSource = _db.Current.ToList();
            resistGrid = resistance;
            XresistGrid = Xresistance;
            Losesgrid = loses;
            Thermalgrid = Tresistance;
            Igrid = current;
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.InsertPage);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (resistGrid.SelectedItem as Resistance).cable_id;
                var deleteResistance = _db.Resistance.Where(m => m.cable_id == Id).Single();
                var deleteX = _db.XResistanceScreen.Where(m => m.cable_id == Id).Single();
                var deleteLoses = _db.Loses.Where(m => m.cable_id == Id).Single();
                var deleteThermRes = _db.ThermalResistance.Where(m => m.cable_id == Id).Single();
                var deleteCurrent = _db.Current.Where(m => m.cable_id == Id).Single();
                _db.Resistance.Remove(deleteResistance);
                _db.XResistanceScreen.Remove(deleteX);
                _db.Loses.Remove(deleteLoses);
                _db.ThermalResistance.Remove(deleteThermRes);
                _db.Current.Remove(deleteCurrent);
                _db.SaveChanges();
                resistGrid.ItemsSource = _db.Resistance.ToList();
                XresistGrid.ItemsSource = _db.XResistanceScreen.ToList();
                Losesgrid.ItemsSource = _db.Loses.ToList();
                Thermalgrid.ItemsSource = _db.ThermalResistance.ToList();
                Igrid.ItemsSource = _db.Current.ToList();
            }
            catch
            {
                MessageBox.Show("Кабель не добавлен.");
            }

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (resistGrid.SelectedItem as Resistance).cable_id;
                NavigationService.Navigate(new Update(Id, mainWindow));
            }
            catch
            {
                MessageBox.Show("Кабель не добавлен.");
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }
    }
}
