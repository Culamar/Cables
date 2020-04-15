using System.Windows;

namespace Cables_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CablesEntities _db = new CablesEntities();
        int id;
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.login);
        }
        public enum pages
        {
            login,
            regin,
            Menu,
            AdminMenu,
            InsertPage,
            Update,
            Select
        }
        public void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
                frame.Navigate(new login(this));
            }
            else if (pages == pages.regin)
            {
                frame.Navigate(new regin(this));
            }
            else if (pages == pages.Menu)
            {
                frame.Navigate(new Menu(this));
            }
            else if (pages == pages.AdminMenu)
            {
                frame.Navigate(new AdminMenu(this));
            }
            else if (pages == pages.InsertPage)
            {
                frame.Navigate(new InsertPage(this));
            }
        }



    }
}
