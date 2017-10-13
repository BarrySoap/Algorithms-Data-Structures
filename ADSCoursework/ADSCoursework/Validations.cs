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
                MessageBox.Show("Space is Empty");
            }
        }

        public static void IsPieceYours(Button cell, Player player)
        {
            if (cell.Background == Brushes.White && player.GetColour() == "White")
            {
                MessageBox.Show("Piece is White");
            } else if (cell.Background == Brushes.Black && player.GetColour() == "Black")
            {
                MessageBox.Show("Piece is Black");
            }
        }
    }
}
