using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Cables_1
{
    /// <summary>
    /// Interaction logic for Select.xaml
    /// </summary>
    public partial class Select : Page
    {
        CablesEntities _db = new CablesEntities();
        public MainWindow mainWindow;
        List<int?> ids;
        public Select(List<int?> list, MainWindow _mainWindow)
        {
            List<Selection> selections = new List<Selection>();
            ids = list;
            mainWindow = _mainWindow;
            selections.Clear();
            int n = _db.Resistance.Count();
            for (int j = 0; j < ids.Count; j++)
            {

                int? idishnik = ids[j];
                for (int i = 0; i < n; i++)
                {

                    int? cross;
                    int? screen;
                    string mat;
                    double? T1;
                    double? T2;
                    double? T3;
                    double? T4;
                    double? I;
                    var selected = _db.ThermalResistance.OrderBy(sp => sp.cable_id == idishnik).Skip(i).FirstOrDefault<ThermalResistance>();
                    var selected2 = _db.Current.OrderBy(sp => sp.cable_id == idishnik).Skip(i).FirstOrDefault<Current>();
                    if (selected.cable_id == idishnik && selected2.cable_id == idishnik)
                    {
                        cross = selected.cross_area;
                        screen = selected.screen_area;
                        mat = selected.material;
                        T1 = selected.T1;
                        T2 = selected.T2;
                        T3 = selected.T3;
                        T4 = selected.T4;
                        I = selected2.I;
                        selections.Add(new Selection() { Cross_area = cross, Screen_area = screen, Material = mat, T1 = T1, T2 = T2, T3 = T3, T4 = T4, I = I });


                    }


                }

            }

            InitializeComponent();
            selection.ItemsSource = selections;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.Menu);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool failed = false;
            do
            {
                try
                {
                    Excel.Application excel = new Excel.Application();
                    excel.Visible = true;
                    Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < selection.Columns.Count; j++)
                    {
                        Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                        myRange.Value = selection.Columns[j].Header;

                    }

                    for (int i = 0; i < selection.Columns.Count; i++)
                    {
                        for (int j = 0; j < selection.Items.Count; j++)
                        {
                            TextBlock b = selection.Columns[i].GetCellContent(selection.Items[j]) as TextBlock;
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value = b.Text;
                        }
                    }
                    failed = false;
                }
                catch (System.Runtime.InteropServices.COMException ce)
                {
                    failed = true;
                }
                System.Threading.Thread.Sleep(10);
            } while (failed);

        }

    }
}
public class Selection
{
    public int? Cross_area { get; set; }

    public int? Screen_area { get; set; }

    public string Material { get; set; }
    public double? T1 { get; set; }
    public double? T2 { get; set; }
    public double? T3 { get; set; }
    public double? T4 { get; set; }
    public double? I { get; set; }
}