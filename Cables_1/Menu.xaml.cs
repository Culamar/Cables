using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Cables_1
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {

        CablesEntities _db = new CablesEntities();
        public MainWindow mainWindow;
        public Menu(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            List<int?> list = new List<int?>();
            int? id;
            int n = _db.Resistance.Count();
            int Unom = 6;
            int core = 1;
            string mat = "Алюминий";
            string paving = "В плоскости";
            string env = "Земля";
            string obol = "Полиэтилен";
            string arm = "Алюмининиевая проволочная";
            if (Voltage.Text == "6 кВ")
            {
                Unom = 6;
            }
            if (Voltage.Text == "10 кВ")
            {
                Unom = 10;
            }
            if (Voltage.Text == "20 кВ")
            {
                Unom = 20;
            }
            if (Voltage.Text == "35 кВ")
            {
                Unom = 35;
            }
            if (Voltage.Text == "110 кВ")
            {
                Unom = 110;
            }
            if (Veins.Text == "1")
            {
                core = 1;
            }
            if (Veins.Text == "3")
            {
                core = 3;
            }
            if (Material.Text == "Алюминий")
            {
                mat = "Алюминий";
            }
            if (Material.Text == "Медь")
            {
                mat = "Медь";
            }
            if (PavingType.Text == "В плоскости")
            {
                paving = "В плоскости";
            }
            if (PavingType.Text == "Треугольником")
            {
                paving = "Треугольником";
            }
            if (Environment.Text == "Земля")
            {
                env = "Земля";
            }
            if (Environment.Text == "Воздух")
            {
                env = "Воздух";
            }
            if (obolochka.Text == "Полиэтилен")
            {
                obol = "Полиэтилен";
            }
            if (obolochka.Text == "Поливинилхлорид")
            {
                obol = "Поливинилхлорид";
            }
            if (Armor.Text == "Алюмининиевая проволочная")
            {
                arm = "Алюмининиевая проволочная";
            }
            if (Armor.Text == "Стальная ленточная")
            {
                arm = "Стальная ленточная";
            }
            if (Armor.Text == "Стальная проволочная")
            {
                arm = "Стальная проволочная";
            }
            if (Armor.Text == "Без брони")
            {
                arm = "Без брони";
            }
            for (int i = 0; i < n; i++)
            {

                var cablelistU = _db.ThermalResistance.OrderBy(sp => sp.Voltage == Unom && sp.vein_number == core && sp.material == mat && sp.paving_type == paving && sp.enviroment == env && sp.Shell == obol && sp.Armor == arm).Skip(i).FirstOrDefault<ThermalResistance>();
                if (cablelistU.Voltage == Unom && cablelistU.vein_number == core && cablelistU.material == mat && cablelistU.paving_type == paving && cablelistU.enviroment == env && cablelistU.Shell == obol && cablelistU.Armor == arm)
                {
                    id = cablelistU.cable_id;
                    list.Add(id);
                }


            }
            NavigationService.Navigate(new Select(list, mainWindow));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }
    }
}
