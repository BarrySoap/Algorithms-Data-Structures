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

        public static bool IsSpaceEmpty(Button cell)
        {
            if (cell.Background == Brushes.Gray)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void IsPieceYours(Button cell, Player player)
        {
            if (cell.Background == Brushes.White && player.GetColour() != "White")
            {
                
            } else if (cell.Background == Brushes.Black && player.GetColour() == "Black")
            {
                
            }
        }

        public static bool IsMoveValid(Button cell, Piece currentPiece, int oldPosition, int newPosition)
        {
            if (currentPiece.GetColour() == "White")
            {
                if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else if (currentPiece.GetColour() == "Black")
            {
                if (oldPosition - newPosition == -7 || oldPosition - newPosition == -9)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                MessageBox.Show("Move is not valid!");
                return false;
            }
        }
    }
}
