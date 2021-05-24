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
    /// Логика взаимодействия для Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
       Heal1 db = new Heal1();
        public Regist()
        {
            InitializeComponent();
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            this.Close();
            MainWindow.Show();
        }

        private void BtLog_Click(object sender, RoutedEventArgs e)
        {
            Log Log = new Log();
            this.Close();
            Log.Show();
        }

        private void TexBxSNULS_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           // e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void TexBxFamil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           e.Handled = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХФЫВАПРОЛДЖЭЯЧСМИТБЮ".IndexOf(e.Text) < 0; //Только буквы(очень спорно)
        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            Func f = new Func();
             Autoris emp = new Autoris
            {
                First_Name = TexBxFamil.Text,
                Pass = f.GetHashPassword(PassBx.Password),
                Login = TexBxLog.Text,
                Name = TexBxName.Text,
                Otchestvo = TexBxOtchestv.Text,
             };
            if (String.IsNullOrEmpty(TexBxFamil.Text) || String.IsNullOrEmpty(PassBx.Password) || String.IsNullOrEmpty(TexBxLog.Text) || String.IsNullOrEmpty(TexBxName.Text) || String.IsNullOrEmpty(TexBxOtchestv.Text)) //Проверка,если ничего не ввели
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
                    try //Проверка на повторяющейся логин
                    {
                        db.Autoris.Add(emp);
                        db.SaveChanges();

                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        db.Autoris.Remove(emp);
                        db.SaveChanges();
                        TexBxFamil.Clear();
                        PassBx.Clear();
                        TexBxLog.Clear();
                        MessageBox.Show("Логин существует");
                        return;
                    }
                    MessageBoxResult res = MessageBox.Show("Человек зарегестрирован! Повторить?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Question); //Проверка на повторную регистрацию
                    if (res == MessageBoxResult.No)
                    {
                  
                        Log Log = new Log();
                        this.Close();
                        Log.Show();
                    }
                    else
                    {
                        TexBxFamil.Clear();
                        PassBx.Clear();
                        TexBxLog.Clear();
                    }

                }
            }
        }
    }
}
