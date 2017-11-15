using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains logic for validations, to make sure the program is robust.
 * Date last modified: 15/11/2017
 */

namespace ADSCoursework
{
    class Validations
    {
        // This method is used to check if a cell is empty, with no piece on it.
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

        // A method to check if the piece you select belongs to you.
        public static bool IsPieceYours(Button cell, Player player)
        {
            // Check if the piece corresponds to your player colour.
            if (cell.Background == Brushes.White && player.GetColour() == "White")
            {
                return true;
            }
            else if (cell.Background == Brushes.Black && player.GetColour() == "Black")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Piece is not yours!");
                return false;
            }
        }

        // This method has a number of validations to make sure that a given move is valid.
        public static bool IsMoveValid(Button cell, Piece currentPiece, Button[] buttonList, int oldPosition, int newPosition, ref bool pieceTaken,
            List<Piece> whitePieces, List<Piece> blackPieces)
        {
            int temp = 0;
            int temp2 = 0;

            // If the current piece is a king,
            if (Operations.ComparePieces(currentPiece, whitePieces, blackPieces).IsPieceKing() == true)
            {
                // Check the colour.
                if (currentPiece.GetColour() == "White")
                {
                    // If the king is trying to make a regular move to a diagonal,
                    if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 ||
                        oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && buttonList[newPosition].Background == Brushes.Gray)
                    {
                        // The move is valid, return true.
                        return true;
                    }
                    // Call on a check to see if the diagonals are opposing pieces,
                    else if (Operations.KingFactionCheck(buttonList, currentPiece, oldPosition, newPosition))
                    {
                        // and that they aren't on any edges of the board.
                        if (Operations.EdgeOperation(blackPieces, currentPiece.GetPosition() - 9) == true ||
                            Operations.EdgeOperation(blackPieces, currentPiece.GetPosition() - 7) == true ||
                            Operations.EdgeOperation(blackPieces, currentPiece.GetPosition() + 9) == true ||
                            Operations.EdgeOperation(blackPieces, currentPiece.GetPosition() + 7) == true)
                        {
                            // If they aren't opposing pieces or are on the edges, the move isn't valid.
                            return false;
                        }
                        else
                        {
                            // If the move is valid over a piece, a piece has been taken.
                            pieceTaken = true;
                            // Split the position into a new variable to avoid division issues.
                            temp = currentPiece.GetPosition();
                            temp2 = temp + currentPiece.GetNewPosition();
                            temp2 /= 2;

                            for (int i = 0; i < blackPieces.Count; i++)
                            {
                                // Iterate through the list of pieces to check which one has been taken,
                                if (blackPieces[i].GetNewPosition() == temp2 ||
                                    blackPieces[i].GetPosition() == temp2)
                                {
                                    // and update the variable accordingly.
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
                    if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 ||
                        oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && buttonList[newPosition].Background == Brushes.Gray)
                    {
                        return true;
                    }
                    else if (Operations.KingFactionCheck(buttonList, currentPiece, oldPosition, newPosition))
                    {
                        if (Operations.EdgeOperation(whitePieces, currentPiece.GetPosition() - 9) == true ||
                            Operations.EdgeOperation(whitePieces, currentPiece.GetPosition() - 7) == true ||
                            Operations.EdgeOperation(whitePieces, currentPiece.GetPosition() + 9) == true ||
                            Operations.EdgeOperation(whitePieces, currentPiece.GetPosition() + 7) == true)
                        {
                            return false;
                        }
                        else
                        {

                            pieceTaken = true;
                            temp = currentPiece.GetPosition();
                            temp2 = temp + currentPiece.GetNewPosition();
                            temp2 /= 2;

                            for (int i = 0; i < whitePieces.Count; i++)
                            {
                                if (whitePieces[i].GetNewPosition() == temp2 ||
                                    whitePieces[i].GetPosition() == temp2)
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
                    return false;
                }
            }
            else
            {
                // This section is just for normal pieces, rather than kings.
                if (currentPiece.GetColour() == "White")
                {
                    // Check if the piece is making a normal diagonal move, and that the space is empty.
                    if (oldPosition - newPosition == 7 || oldPosition - newPosition == 9 && Validations.IsSpaceEmpty(buttonList[newPosition]) == true)
                    {
                        return true;
                    }
                    else if (Operations.FactionCheck(buttonList, oldPosition, newPosition))
                    {
                        if (Operations.EdgeOperation(blackPieces, currentPiece.GetPosition() - 9) == true &&
                            Operations.EdgeOperation(blackPieces, currentPiece.GetPosition() - 7) == true)
                        {
                            return false;
                        }
                        else
                        {
                            pieceTaken = true;
                            temp = currentPiece.GetPosition();
                            temp2 = temp + currentPiece.GetNewPosition();
                            temp2 /= 2;

                            for (int i = 0; i < blackPieces.Count; i++)
                            {
                                if (blackPieces[i].GetNewPosition() == temp2 ||
                                    blackPieces[i].GetPosition() == temp2)
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
                    if (oldPosition - newPosition == -7 || oldPosition - newPosition == -9 && Validations.IsSpaceEmpty(buttonList[newPosition]) == true)
                    {
                        return true;
                    }
                    else if (Operations.FactionCheck(buttonList, oldPosition, newPosition))
                    {
                        if (Operations.EdgeOperation(whitePieces, currentPiece.GetPosition() + 9) == true &&
                            Operations.EdgeOperation(whitePieces, currentPiece.GetPosition() + 7) == true)
                        {
                            return false;
                        }
                        else
                        {
                            pieceTaken = true;
                            temp = currentPiece.GetPosition();
                            temp2 = temp + currentPiece.GetNewPosition();
                            temp2 /= 2;

                            for (int i = 0; i < whitePieces.Count; i++)
                            {
                                if (whitePieces[i].GetNewPosition() == temp2 ||
                                    whitePieces[i].GetPosition() == temp2)
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

        // This method is used for clarity, splitting diagonal checks into regular pieces and king pieces.
        public static void CanPieceBeTaken(Button cell, ref Piece currentPiece, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // If the current piece isn't a king,
            if (Operations.ComparePieces(currentPiece, whitePieces, blackPieces).IsPieceKing() == false)
            {
                // Check if any of the diagonals have a piece which can be taken.
                Operations.CheckDiagonal(currentPiece, whitePieces, blackPieces, buttonList);
            }
            else
            {
                Operations.CheckKingDiagonal(currentPiece, whitePieces, blackPieces, buttonList);
            }
        }

        // This method is used as a constant check to make sure the attributes of a king piece are correct.
        public static void IsPieceKing(Button cell, Piece currentPiece, Button[] buttonList, int oldPosition, int newPosition, ref bool pieceTaken,
                List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // If a black piece has reached the top of the board (opposite side),
            if (currentPiece.GetColour() == "Black" && currentPiece.GetNewPosition() > 55
                                                        && currentPiece.GetNewPosition() < 64)
            {
                for (int i = 0; i < blackPieces.Count; i++)
                {
                    // Find the respective piece from the list,
                    if (currentPiece.GetNewPosition() == blackPieces[i].GetNewPosition())
                    {
                        // Make it a king,
                        blackPieces[i].SetPieceAsKing(true);
                        // and give it a new look.
                        cell.Content = "K";
                        cell.Foreground = Brushes.White;
                    }
                }
            }
            if (currentPiece.GetColour() == "White" && currentPiece.GetNewPosition() > -1
                                                    && currentPiece.GetNewPosition() < 8)
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

        // This method is used as a simple check to see if the game has ended.
        public static void HasGameEnded(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // If either of the pieces lists are empty,
            if (whitePieces.Count == 0 || blackPieces.Count == 0)
            {
                // Tell the player the game has ended,
                MessageBox.Show("Game has ended!");
                // and give them the opportunity to replay the game.
                main.btnReplay.IsEnabled = true;
            }
        }
    }
}
