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
    class Operations
    {
        public static bool EdgeOperation(Piece currentPiece, List<Piece> pieces, int position)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (Convert.ToInt32(pieces[i].GetNewPosition()) == position)
                {
                    if (pieces[i].GetEdge() == true)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static bool FactionCheck(Button[] buttonList, int oldPosition, int newPosition)
        {
            if (oldPosition - newPosition == 14)
            {
                if (buttonList[newPosition + 7].Background == Brushes.Black)
                {
                    return true;
                }
            }
            if (oldPosition - newPosition == 18)
            {
                if (buttonList[newPosition + 9].Background == Brushes.Black)
                {
                    return true;
                }
            }
            if (oldPosition - newPosition == -14)
            {
                if (buttonList[newPosition - 7].Background == Brushes.White)
                {
                    return true;
                }
            }
            if (oldPosition - newPosition == -18)
            {
                if (buttonList[newPosition - 9].Background == Brushes.White)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool KingFactionCheck(Button[] buttonList, Piece currentPiece, int oldPosition, int newPosition)
        {
            if (currentPiece.GetColour() == "White")
            {
                if (oldPosition - newPosition == 14)
                {
                    if (buttonList[newPosition + 7].Background == Brushes.Black)
                    {
                        return true;
                    }
                }
                if (oldPosition - newPosition == 18)
                {
                    if (buttonList[newPosition + 9].Background == Brushes.Black)
                    {
                        return true;
                    }
                }
                if (oldPosition - newPosition == -14)
                {
                    if (buttonList[newPosition - 7].Background == Brushes.Black)
                    {
                        return true;
                    }
                }
                if (oldPosition - newPosition == -18)
                {
                    if (buttonList[newPosition - 9].Background == Brushes.Black)
                    {
                        return true;
                    }
                }
            }
            
            if (currentPiece.GetColour() == "Black")
            {
                if (oldPosition - newPosition == 14)
                {
                    if (buttonList[newPosition + 7].Background == Brushes.White)
                    {
                        return true;
                    }
                }
                if (oldPosition - newPosition == 18)
                {
                    if (buttonList[newPosition + 9].Background == Brushes.White)
                    {
                        return true;
                    }
                }
                if (oldPosition - newPosition == -14)
                {
                    if (buttonList[newPosition - 7].Background == Brushes.White)
                    {
                        return true;
                    }
                }
                if (oldPosition - newPosition == -18)
                {
                    if (buttonList[newPosition - 9].Background == Brushes.White)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Piece ComparePieces(Piece currentPiece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            for (int i = 0; i < whitePieces.Count; i++)
            {
                if (currentPiece.GetNewPosition() == whitePieces[i].GetNewPosition())
                {
                    return whitePieces[i];
                }
            }
            for (int i = 0; i < blackPieces.Count; i++)
            {
                if (currentPiece.GetNewPosition() == blackPieces[i].GetNewPosition())
                {
                    return blackPieces[i];
                }
            }
            return currentPiece;
        }

        public static bool EdgeToEdge(int oldPosition, int newPosition)
        {
            if (oldPosition % 8 == 0 || oldPosition % 8 == 7)
            {
                if (newPosition % 8 == 0 || newPosition % 8 == 7)
                {
                    return true;
                } else
                {
                    return false;
                }
            } else
            {
                return false;
            }
        }
    }
}
