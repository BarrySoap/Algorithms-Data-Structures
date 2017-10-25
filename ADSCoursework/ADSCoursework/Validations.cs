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

        public static bool IsMoveValid(Button cell, Piece currentPiece, Button[] buttonList, int oldPosition, int newPosition, bool pieceTaken)
        {
            if (currentPiece.GetColour() == "White")
            {
                if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 && buttonList[newPosition].Background == Brushes.Gray)
                {
                    return true;
                }
                else if (oldPosition - newPosition == 14 || oldPosition - newPosition == 18)
                {
                    if (buttonList[newPosition + 9].Background == Brushes.Black || buttonList[newPosition + 7].Background == Brushes.Black)
                    {
                        pieceTaken = true;
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            } else if (currentPiece.GetColour() == "Black")
            {
                if (oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && buttonList[newPosition].Background == Brushes.Gray)
                {
                    return true;
                }
                else if (oldPosition - newPosition == -14 || oldPosition - newPosition == -18)
                {
                    if (buttonList[newPosition - 9].Background == Brushes.White || buttonList[newPosition - 7].Background == Brushes.White)
                    {
                        pieceTaken = true;
                        return true;
                    }
                    return false;
                }
                else
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
            if (currentPiece.GetColour() == "White" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background == Brushes.Black
                && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 14].Background == Brushes.Gray)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background = Brushes.Cyan;
            }
            if (currentPiece.GetColour() == "White" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background == Brushes.Black      // CAUSES AN ISSUE ON OTHER SIDE OF BOARD
                && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 18].Background == Brushes.Gray)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background = Brushes.Cyan;
            }

            if (currentPiece.GetColour() == "Black" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background == Brushes.White
                && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 14].Background == Brushes.Gray)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background = Brushes.Cyan;
            }
            if (currentPiece.GetColour() == "Black" && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background == Brushes.White
                && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 18].Background == Brushes.Gray)
            {
                buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background = Brushes.Cyan;
            }
        }
    }
}
