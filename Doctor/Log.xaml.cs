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

namespace Doctor
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        Heal1 db = new Heal1();
        public Log()
        {
            InitializeComponent();            
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Regist Regist = new Regist();
            this.Close();
            Regist.Show();
        }

        private void BtLog_Click(object sender, RoutedEventArgs e)
        {
            // avtoris.Autorisation(TexBxFamil, TexBxSNULS, this);
            if (String.IsNullOrEmpty(PassBx.Password) || String.IsNullOrEmpty(TexBxLog.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (PassBx.Password.Length < 4) //Проверка,пароля на колл символов
                {
                    MessageBox.Show("Пароль должен быть больше 4 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {


                    Autoris emp = db.Autoris.SingleOrDefault(c => c.Login == TexBxLog.Text);
                    if (emp == null)
                    {
                        MessageBox.Show("Такого пользователя не существует");
                       // LbName.Content = emp.Name;
                        return;
                    }
                    Func f = new Func();
                    if (f.CheckPassword(emp.Pass, f.GetHashPassword(PassBx.Password)))
                    {
                        //LbName.Content = emp.Name;//интересно
                        MessageBox.Show($"Здравствуйте, {emp.First_Name} {emp.Name} {emp.Otchestvo}");
                        Menu N4 = new Menu();
                        this.Close();
                        N4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Пароль неверный!");
                    }
                }
            }


        }

        private void TexBxFamil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
           e.Handled = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХФЫВАПРОЛДЖЭЯЧСМИТБЮ".IndexOf(e.Text) < 0; //Только буквы(очень спорно)

        }

        private void TexBxSNULS_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = "0123456789".IndexOf(e.Text) < 0; //Только цифры
        }
    }
}
