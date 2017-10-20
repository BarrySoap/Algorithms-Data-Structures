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

        public static bool IsPieceYours(Button cell, Player player)
        {
            if (cell.Background == Brushes.White && player.GetColour() == "White")
            {
                return true;
            } else if (cell.Background == Brushes.Black && player.GetColour() == "Black")
            {
                return true;
            } else
            {
                MessageBox.Show("Piece is not yours!");
                return false;
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

        public static void CanPieceBeTaken(Button cell, ref Piece currentPiece, Button[] buttonList, int oldPosition)
        {
            if (currentPiece.GetColour() == "White" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background == Brushes.Black)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background = Brushes.Cyan;
            }
            if (currentPiece.GetColour() == "White" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background == Brushes.Black)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background = Brushes.Cyan;
            }
            if (currentPiece.GetColour() == "Black" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background == Brushes.White)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background = Brushes.Cyan;
            }
            if (currentPiece.GetColour() == "Black" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background == Brushes.White)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background = Brushes.Cyan;
            }
        }
    }
}
