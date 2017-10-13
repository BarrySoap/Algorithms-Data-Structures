using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ADSCoursework
{
    class ButtonCleaning
    {
        List<Button> buttonList = new List<Button>();

        //public void ButtonsToList(Button button)
        //{
        //    for (int i = 0; i < 64; i++)
        //    {
        //        string temp = "btnCell" + i;

        //        if (temp == button.Name)
        //        {
        //            buttonList.Add(button);
        //        }
        //    }
        //}

        public ButtonCleaning(MainWindow main)
        {
            buttonList.Add(main.btnCell1);
        }
    }

    public class Facade
    {
        ButtonCleaning cleaner;

        public Facade(MainWindow main)
        {
            cleaner = new ButtonCleaning(main);
        }
    }
}
