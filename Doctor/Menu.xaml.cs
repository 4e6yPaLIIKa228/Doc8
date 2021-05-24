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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        static Heal1 db = new Heal1();
        Autoris emp = new Autoris();
         Func f = new Func();
        public Menu()
        {
            InitializeComponent();
            Reload();
        }
         
        public void Reload()
        {
            dgInfo.ItemsSource = db.OutputInfo.ToList();
            LbName.Content = emp.Name;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgInfo.ItemsSource = db.OutputInfo.Where(c => c.Doctor.Contains(tbSearchDock.Text)).ToList();
        }

        private void tbSearchPositil_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgInfo.ItemsSource = db.OutputInfo.Where(c => c.Positutel.Contains(tbSearchPositil.Text)).ToList();

        }

        private void tbSearchSpeciality_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgInfo.ItemsSource = db.OutputInfo.Where(c => c.Speciality.Contains(tbSearchSpeciality.Text)).ToList();
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            Log Menu = new Log();
            this.Close();
            Menu.Show();


        }

        private void BtPoisk_Click(object sender, RoutedEventArgs e)
        {
            Output Output = new Output();
            this.Close();
            Output.Show();
        }
    }

}
