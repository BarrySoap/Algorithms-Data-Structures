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

        public static bool IsMoveValid(Button cell, Piece currentPiece, Button[] buttonList, int oldPosition, int newPosition, ref bool pieceTaken,
            List<Piece> whitePieces, List<Piece> blackPieces)
        {
            int temp = 0;
            int temp2 = 0;

            if (currentPiece.IsPieceKing() == true)
            {
                if (currentPiece.GetColour() == "White")
                {
                    if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 ||
                        oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && buttonList[newPosition].Background == Brushes.Gray)
                    {
                        return true;
                    }
                    else if (oldPosition - newPosition == 14 || oldPosition - newPosition == 18 ||
                             oldPosition - newPosition == -14 || oldPosition - newPosition == -18)
                    {
                        if (buttonList[newPosition + 9].Background == Brushes.Black || buttonList[newPosition + 7].Background == Brushes.Black ||
                            buttonList[newPosition - 9].Background == Brushes.Black || buttonList[newPosition - 7].Background == Brushes.Black)
                        {
                            pieceTaken = true;
                            temp = Convert.ToInt32(currentPiece.GetPosition());
                            temp2 = temp + Convert.ToInt32(currentPiece.GetNewPosition());
                            temp2 /= 2;

                            for (int i = 0; i < blackPieces.Count; i++)
                            {
                                if (Convert.ToInt32(blackPieces[i].GetNewPosition()) == temp2 ||
                                    Convert.ToInt32(blackPieces[i].GetPosition()) == temp2)
                                {
                                    blackPieces[i].SetTaken(true);
                                }
                            }
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (currentPiece.GetColour() == "Black")
                {
                    if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 ||
                        oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && buttonList[newPosition].Background == Brushes.Gray)
                    {
                        return true;
                    }
                    else if (oldPosition - newPosition == 14 || oldPosition - newPosition == 18 ||
                             oldPosition - newPosition == -14 || oldPosition - newPosition == -18)
                    {
                        if (buttonList[newPosition + 9].Background == Brushes.White || buttonList[newPosition + 7].Background == Brushes.White ||
                            buttonList[newPosition - 9].Background == Brushes.White || buttonList[newPosition - 7].Background == Brushes.White)
                        {
                            pieceTaken = true;
                            temp = Convert.ToInt32(currentPiece.GetPosition());
                            temp2 = temp + Convert.ToInt32(currentPiece.GetNewPosition());
                            temp2 /= 2;

                            for (int i = 0; i < whitePieces.Count; i++)
                            {
                                if (Convert.ToInt32(whitePieces[i].GetNewPosition()) == temp2 ||
                                    Convert.ToInt32(whitePieces[i].GetPosition()) == temp2)
                                {
                                    whitePieces[i].SetTaken(true);
                                }
                            }
                            return true;
                        }
                        return false;
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
            } else
            {
                if (currentPiece.GetColour() == "White")
                {
                    if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 && Validations.IsSpaceEmpty(buttonList[newPosition]) == true)
                    {
                        return true;
                    }
                    else if (Operations.FactionCheck(buttonList, oldPosition, newPosition))
                    {
                        if (Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) - 9) == true ||
                            Operations.EdgeOperation(currentPiece, blackPieces, Convert.ToInt32(currentPiece.GetPosition()) - 7) == true)
                        {
                            return false;
                        }
                        else
                        {
                            pieceTaken = true;
                            temp = Convert.ToInt32(currentPiece.GetPosition());
                            temp2 = temp + Convert.ToInt32(currentPiece.GetNewPosition());
                            temp2 /= 2;

                            for (int i = 0; i < blackPieces.Count; i++)
                            {
                                if (Convert.ToInt32(blackPieces[i].GetNewPosition()) == temp2 ||
                                    Convert.ToInt32(blackPieces[i].GetPosition()) == temp2)
                                {
                                    blackPieces[i].SetTaken(true);
                                }
                            }
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (currentPiece.GetColour() == "Black")
                {
                    if (oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && buttonList[newPosition].Background == Brushes.Gray)
                    {
                        return true;
                    }
                    else if (Operations.FactionCheck(buttonList, oldPosition, newPosition))
                    {
                        if (Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) + 9) == true ||
                            Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) + 7) == true)
                        {
                            return false;
                        }
                        else
                        {
                            pieceTaken = true;
                            temp = Convert.ToInt32(currentPiece.GetPosition());
                            temp2 = temp + Convert.ToInt32(currentPiece.GetNewPosition());
                            temp2 /= 2;

                            for (int i = 0; i < whitePieces.Count; i++)
                            {
                                if (Convert.ToInt32(whitePieces[i].GetNewPosition()) == temp2 ||
                                    Convert.ToInt32(whitePieces[i].GetPosition()) == temp2)
                                {
                                    whitePieces[i].SetTaken(true);
                                }
                            }
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Move is not valid!");
                    return false;
                }
            }
        }

        public static void CanPieceBeTaken(Button cell, ref Piece currentPiece, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces)
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
                    Operations.EdgeOperation(currentPiece, whitePieces, Convert.ToInt32(currentPiece.GetPosition()) - 9) == false)
                {
                    if (Convert.ToInt32(currentPiece.GetPosition()) - 18 > 0 && buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 18].Background == Brushes.Gray)
                    {
                        buttonList[Convert.ToInt32(currentPiece.GetPosition()) - 9].Background = Brushes.Cyan;
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

        public static void IsPieceKing(Button cell, Piece currentPiece, Button[] buttonList, int oldPosition, int newPosition, ref bool pieceTaken,
            List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (currentPiece.GetColour() == "Black" && Convert.ToInt32(currentPiece.GetNewPosition()) > 55
                                                        && Convert.ToInt32(currentPiece.GetNewPosition()) < 64)
            {
                for (int i = 0; i < blackPieces.Count; i++)
                {
                    if (currentPiece.GetNewPosition() == blackPieces[i].GetNewPosition())
                    {
                        blackPieces[i].SetPieceAsKing(true);
                        cell.Content = "K";
                        cell.Foreground = Brushes.White;
                    }
                }
            }
            if (currentPiece.GetColour() == "White" && Convert.ToInt32(currentPiece.GetNewPosition()) > -1
                                                    && Convert.ToInt32(currentPiece.GetNewPosition()) < 8)
            {
                for (int i = 0; i < whitePieces.Count; i++)
                {
                    if (currentPiece.GetNewPosition() == whitePieces[i].GetNewPosition())
                    {
                        whitePieces[i].SetPieceAsKing(true);
                        cell.Content = "K";
                        cell.Foreground = Brushes.Black;
                    }
                }
            }
        }

        public void HasGameEnded(List<Piece> whitePieces, List<Piece> blackPieces)
        {
            if (whitePieces.Count == 0 || blackPieces.Count == 0)
            {
                MessageBox.Show("Game has ended!");
            }
        }
    }
}
