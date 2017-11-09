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
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void CheckColouring(List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList)
        {
            for (int i = 0; i < whitePieces.Count; i++)
            {
                if (whitePieces[i].GetNewPosition() == buttonList[Convert.ToInt32(whitePieces[i].GetNewPosition())].Name.Substring(7) && whitePieces[i].IsPieceKing() == true)
                {
                    buttonList[Convert.ToInt32(whitePieces[i].GetNewPosition())].Content = "K";
                    buttonList[Convert.ToInt32(whitePieces[i].GetNewPosition())].Foreground = Brushes.Black;
                }
            }
            for (int j = 0; j < blackPieces.Count; j++)
            {
                if (blackPieces[j].GetNewPosition() == buttonList[Convert.ToInt32(blackPieces[j].GetNewPosition())].Name.Substring(7) && blackPieces[j].IsPieceKing() == true)
                {
                    buttonList[Convert.ToInt32(blackPieces[j].GetNewPosition())].Content = "K";
                    buttonList[Convert.ToInt32(blackPieces[j].GetNewPosition())].Foreground = Brushes.White;
                }
            }
            for (int k = 0; k < buttonList.Length; k++)
            {
                if (buttonList[k].Content == "K" && buttonList[k].Background == Brushes.Gray)
                {
                    buttonList[k].Content = buttonList[k].Name.Substring(7);
                    buttonList[k].Foreground = Brushes.Black;
                }
            }
        }

        public static void CheckDiagonal(Piece currentPiece, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList)
        {
            if (currentPiece.GetColour() == "White")
            {
                if (Convert.ToInt32(currentPiece.GetPosition()) - 7 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background == Brushes.Black &&
                    Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) - 7) == false)
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 14 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 14].Background == Brushes.Gray)
                    {
                        buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background = Brushes.Cyan;
                    }
                }
                if (Convert.ToInt32(currentPiece.GetPosition()) - 9 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background == Brushes.Black &&
                     Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) - 9) == false)
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 18 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 18].Background == Brushes.Gray)
                    {
                        buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background = Brushes.Cyan;  // ?
                    }
                }
            }

            if (currentPiece.GetColour() == "Black")
            {
                if (Convert.ToInt32(currentPiece.GetPosition()) + 7 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background == Brushes.White &&
                     Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) + 7) == false)
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) + 14 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 14].Background == Brushes.Gray)
                    {
                        buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background = Brushes.Cyan;
                    }
                }
                if (Convert.ToInt32(currentPiece.GetPosition()) + 9 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background == Brushes.White &&
                     Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) + 9) == false)
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) + 18 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 18].Background == Brushes.Gray)
                    {
                        buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background = Brushes.Cyan;
                    }
                }
            }
        }

        public static void CheckKingDiagonal(Piece currentPiece, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList)
        {
            if (Operations.ComparePieces(currentPiece, whitePieces, blackPieces).IsPieceKing() == true)
            {
                if (currentPiece.GetColour() == "White")
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 7 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background == Brushes.Black &&
                    Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) - 7) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) - 14 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 14].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background = Brushes.Cyan;
                        }
                    }
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 9 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background == Brushes.Black &&
                         Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) - 9) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) - 18 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 18].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background = Brushes.Cyan;  // ?
                        }
                    }
                    if (Convert.ToInt32(currentPiece.GetPosition()) + 7 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background == Brushes.Black &&
                     Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) + 7) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) + 14 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 14].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background = Brushes.Cyan;
                        }
                    }
                    if (Convert.ToInt32(currentPiece.GetPosition()) + 9 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background == Brushes.Black &&
                         Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) + 9) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) + 18 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 18].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background = Brushes.Cyan;
                        }
                    }
                }

                if (currentPiece.GetColour() == "Black")
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 7 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background == Brushes.White &&
                    Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) - 7) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) - 14 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 14].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 7].Background = Brushes.Cyan;
                        }
                    }
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 9 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background == Brushes.White &&
                         Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) - 9) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) - 18 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 18].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background = Brushes.Cyan;  // ?
                        }
                    }
                    if (Convert.ToInt32(currentPiece.GetPosition()) + 7 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background == Brushes.White &&
                     Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) + 7) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) + 14 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 14].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 7].Background = Brushes.Cyan;
                        }
                    }
                    if (Convert.ToInt32(currentPiece.GetPosition()) + 9 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background == Brushes.White &&
                         Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) + 9) == false)
                    {
                        if (Convert.ToInt32(currentPiece.GetPosition()) + 18 < 63 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 18].Background == Brushes.Gray)
                        {
                            buttonList[Convert.ToInt32(currentPiece.GetPosition()) + 9].Background = Brushes.Cyan;
                        }
                    }
                }
            }
        }
    }
}
