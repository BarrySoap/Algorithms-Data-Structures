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
    class Validations
    {
        public Validations(Piece piece, Button cell, Player currentPlayer)
        {
            
        }

        public static void IsSpaceEmpty(Button cell)
        {
            if (cell.Background == Brushes.Gray)
            {
                MessageBox.Show("ohey");
            }
        }
    }
}
