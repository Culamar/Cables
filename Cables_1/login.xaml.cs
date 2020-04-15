using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cables_1
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        CablesEntities _db = new CablesEntities();
        public MainWindow mainWindow;
        public login(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (log_in.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными 
                    int flag = 0;
                    int n = _db.users.Count();
                    for (int i = 0; i < n; i++)
                    {
                        var log = _db.users.OrderBy(p => p.login == log_in.Text).Skip(i).FirstOrDefault<users>();

                        if (log.login == log_in.Text && log.password == password.Password)
                        {
                            flag = 1;
                        }
                        if (log_in.Text == "admin" && log.password == password.Password)
                        {
                            flag = 2;
                        }
                    }



                    if (flag == 1) // если такая запись существует       
                    {
                        mainWindow.OpenPage(MainWindow.pages.Menu);
                        MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался        
                    }
                    else if (flag == 2)
                    {
                        mainWindow.OpenPage(MainWindow.pages.AdminMenu);
                        MessageBox.Show("Администратор авторизовался"); // говорим, что авторизовался   
                    }
                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку  
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку 
        }

        private void regin_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.regin);
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (log_in.Text.Length > 0) // проверяем введён ли логин     
                {
                    if (password.Password.Length > 0) // проверяем введён ли пароль         
                    {             // ищем в базе данных пользователя с такими данными 
                        int flag = 0;
                        int n = _db.users.Count();
                        for (int i = 0; i < n; i++)
                        {
                            var log = _db.users.OrderBy(p => p.login == log_in.Text).Skip(i).FirstOrDefault<users>();

                            if (log.login == log_in.Text && log.password == password.Password)
                            {
                                flag = 1;
                            }
                            if (log_in.Text == "admin" && log.password == password.Password)
                            {
                                flag = 2;
                            }
                        }



                        if (flag == 1) // если такая запись существует       
                        {
                            mainWindow.OpenPage(MainWindow.pages.Menu);
                            MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался        
                        }
                        else if (flag == 2)
                        {
                            mainWindow.OpenPage(MainWindow.pages.AdminMenu);
                            MessageBox.Show("Администратор авторизовался"); // говорим, что авторизовался   
                        }
                        else MessageBox.Show("Пользователь не найден"); // выводим ошибку  
                    }
                    else MessageBox.Show("Введите пароль"); // выводим ошибку    
                }
                else MessageBox.Show("Введите логин"); // выводим ошибку 
            }

        }
    }
}
