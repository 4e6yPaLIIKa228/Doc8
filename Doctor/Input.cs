using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    class input
    {
        static Heal1 db = new Heal1();
        static public void Autorisation(ComboBox CB1, ComboBox CB2, ComboBox CB3, Window Menu)
        {
           // OutputInfo doc = db.OutputInfo.Where(c => c.Doctor == CB1.Text && c.Time == CB2.Text && c.Kabunet == CB2.Text).SingleOrDefault();
        }
    }
}