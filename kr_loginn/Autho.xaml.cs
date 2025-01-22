using kr_loginn.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kr_loginn
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Password.Trim();
            loginEntities db = new loginEntities();

            var user = db.Login.FirstOrDefault(x => x.login1 == login && x.password == password);

            if (user != null)
            {
                var roles = db.roles.Find(user.id);
                if (roles != null)
                {
                    Page newPage = null;
                    switch (roles.id)
                    {
                        case 1:
                            MessageBox.Show("Привет, админ");
                            break;
                        case 2:
                            MessageBox.Show("Привет, бухгалтер");
                            break;
                        default:
                            MessageBox.Show("Должность не определена.");
                            return;
                    }
                    if (newPage != null)
                    {
                        MainFrame.Navigate(newPage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверно введён логин или пароль");
            }
        }
    }
}

