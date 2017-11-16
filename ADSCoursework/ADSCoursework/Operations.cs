using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains logic for helpful operations that can be used
 *                in a number of scenarios.
 * Date last modified: 15/11/2017
 */

namespace ADSCoursework
{
    class Operations
    {
        // This method is used to check if a given position is on the edge of the board.
        public static bool EdgeOperation(List<Piece> pieces, int position)
        {
            // For each given piece,
            for (int i = 0; i < pieces.Count; i++)
            {
                // Find the respective piece by iterating through the list.
                if (pieces[i].GetNewPosition() == position)
                {
                    // If it's on the edge, return it as true.
                    if (pieces[i].GetEdge() == true)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        // This method is used to check if pieces that are being moved are diagonal from an opposing piece.
        public static bool FactionCheck(Button[] buttonList, int oldPosition, int newPosition)
        {
            // 14 is two board spaces down to the right.
            if (oldPosition - newPosition == 14)
            {
                // Check if the piece in between is of the opposing faction (only white pieces can move downwards).
                if (buttonList[newPosition + 7].Background == Brushes.Black)
                {
                    return true;
                }
            }
            // 18 is two board spaces to the left.
            if (oldPosition - newPosition == 18)
            {
                if (buttonList[newPosition + 9].Background == Brushes.Black)
                {
                    return true;
                }
            }
            // Up two board spaces to the left.
            if (oldPosition - newPosition == -14)
            {
                if (buttonList[newPosition - 7].Background == Brushes.White)
                {
                    return true;
                }
            }
            // Up two board spaces to the right.
            if (oldPosition - newPosition == -18)
            {
                if (buttonList[newPosition - 9].Background == Brushes.White)
                {
                    return true;
                }
            }
            return false;
        }

        // This method is almost identical to the last, except it accounts for king movement.
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

        // This method is used to check pieces of a list directly, rather than using 'currentPiece'.
        public static Piece ComparePieces(Piece currentPiece, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // For each piece in the list of white pieces,
            for (int i = 0; i < whitePieces.Count; i++)
            {
                // Check if the current piece's position corresponds to one from the list,
                if (currentPiece.GetPosition() == whitePieces[i].GetPosition() && whitePieces[i].IsPieceKing() == true)
                {
                    // Then return it.
                    return whitePieces[i];
                }
                else if (currentPiece.GetNewPosition() == whitePieces[i].GetNewPosition())
                {
                    return whitePieces[i];
                }
            }
            for (int i = 0; i < blackPieces.Count; i++)
            {
                if (currentPiece.GetPosition() == blackPieces[i].GetPosition() && blackPieces[i].IsPieceKing() == true)
                {
                    return blackPieces[i];
                }
                if (currentPiece.GetNewPosition() == blackPieces[i].GetNewPosition())
                {
                    return blackPieces[i];
                }
            }
            // If no corresponding pieces are found, return the current piece that is selected.
            return currentPiece;
        }

        // This method is used solely as a validation that pieces on an edge can't go to the opposite side in one move.
        public static bool EdgeToEdge(int oldPosition, int newPosition)
        {
            // If the old position is on the left or right side of board,
            if (oldPosition % 8 == 0 || oldPosition % 8 == 7)
            {
                // and the new position is on the opposite side,
                if (newPosition % 8 == 0 || newPosition % 8 == 7)
                {
                    // Then it is an edge to and edge.
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

        // This method is used to constantly check that the colouring and text for a king piece is correct.
        public static void CheckColouring(List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList)
        {
            for (int i = 0; i < whitePieces.Count; i++)
            {
                // If any white pieces are kings,
                if (whitePieces[i].IsPieceKing() == true)
                {
                    // Iterate through the list of buttons (or board spaces),
                    buttonList[whitePieces[i].GetNewPosition()].Content = "K";
                    // and make sure it is clearly defined as a king.
                    buttonList[whitePieces[i].GetNewPosition()].Foreground = Brushes.Black;
                }
            }
            for (int j = 0; j < blackPieces.Count; j++)
            {
                if (blackPieces[j].IsPieceKing() == true)
                {
                    buttonList[blackPieces[j].GetNewPosition()].Content = "K";
                    buttonList[blackPieces[j].GetNewPosition()].Foreground = Brushes.White;
                }
            }
            // Then make sure no empty cells still have a "K".
            for (int k = 0; k < buttonList.Length; k++)
            {
                if (buttonList[k].Content.ToString() == "K" && buttonList[k].Background == Brushes.Gray)
                {
                    buttonList[k].Content = buttonList[k].Name.Substring(7);
                    buttonList[k].Foreground = Brushes.Black;
                }
            }
        }

        // This method is used to show that a piece can be taken.
        public static bool CheckDiagonal(Piece currentPiece, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList, int position)
        {
            if (currentPiece.GetColour() == "White")
            {
                // Check that the position down a space to the right isn't going off the bottom of the board,
                // as well as being a piece of the opposing faction, and not going from edge to edge.
                if (position - 7 > 0 && buttonList[position - 7].Background == Brushes.Black &&
                    Operations.EdgeOperation(blackPieces, position - 7) == false)
                {
                    // If the position down two spaces to the right is not off the bottom, as well as empty.
                    if (position - 14 > 0 && buttonList[position - 14].Background == Brushes.Gray)
                    {
                        // If so, highlight that cell as a piece able to be taken.
                        buttonList[position - 7].Background = Brushes.Cyan;
                        return true;
                    }
                }
                // Check down to the left,
                if (position - 9 > 0 && buttonList[position - 9].Background == Brushes.Black &&
                     Operations.EdgeOperation(blackPieces, position - 9) == false)
                {
                    if (position - 18 > 0 && buttonList[position - 18].Background == Brushes.Gray)
                    {
                        buttonList[position - 9].Background = Brushes.Cyan;
                        return true;
                    }
                }
            }

            if (currentPiece.GetColour() == "Black")
            {
                // Check up to the right,
                if (position + 7 < 63 && buttonList[position + 7].Background == Brushes.White &&
                     Operations.EdgeOperation(whitePieces, position + 7) == false)
                {
                    if (position + 14 < 63 && buttonList[position + 14].Background == Brushes.Gray)
                    {
                        buttonList[position + 7].Background = Brushes.Cyan;
                        return true;
                    }
                }
                // Check up to the left.
                if (position + 9 < 63 && buttonList[position + 9].Background == Brushes.White &&
                     Operations.EdgeOperation(whitePieces, position + 9) == false)
                {
                    if (position + 18 < 63 && buttonList[position + 18].Background == Brushes.Gray)
                    {
                        buttonList[position + 9].Background = Brushes.Cyan;
                        return true;
                    }
                }
            }
            return false;
        }

        // This method is extremely similar to the last, except it takes into account the movement of the king.
        public static void CheckKingDiagonal(Piece currentPiece, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList, int position)
        {
            if (Operations.ComparePieces(currentPiece, whitePieces, blackPieces).IsPieceKing() == true)
            {
                if (currentPiece.GetColour() == "White")
                {
                    if (position - 7 > 0 && buttonList[position - 7].Background == Brushes.Black &&
                    Operations.EdgeOperation(blackPieces, position - 7) == false)
                    {
                        if (position - 14 > 0 && buttonList[position - 14].Background == Brushes.Gray)
                        {
                            buttonList[position - 7].Background = Brushes.Cyan;
                        }
                    }
                    if (position - 9 > 0 && buttonList[position - 9].Background == Brushes.Black &&
                         Operations.EdgeOperation(blackPieces, position - 9) == false)
                    {
                        if (position - 18 > 0 && buttonList[position - 18].Background == Brushes.Gray)
                        {
                            buttonList[position - 9].Background = Brushes.Cyan;
                        }
                    }
                    if (position + 7 < 63 && buttonList[position + 7].Background == Brushes.Black &&
                     Operations.EdgeOperation(blackPieces, position + 7) == false)
                    {
                        if (position + 14 < 63 && buttonList[position + 14].Background == Brushes.Gray)
                        {
                            buttonList[position + 7].Background = Brushes.Cyan;
                        }
                    }
                    if (position + 9 < 63 && buttonList[position + 9].Background == Brushes.Black &&
                         Operations.EdgeOperation(blackPieces, position + 9) == false)
                    {
                        if (position + 18 < 63 && buttonList[position + 18].Background == Brushes.Gray)
                        {
                            buttonList[position + 9].Background = Brushes.Cyan;
                        }
                    }
                }

                if (currentPiece.GetColour() == "Black")
                {
                    if (position - 7 > 0 && buttonList[position - 7].Background == Brushes.White &&
                    Operations.EdgeOperation(whitePieces, position - 7) == false)
                    {
                        if (position - 14 > 0 && buttonList[position - 14].Background == Brushes.Gray)
                        {
                            buttonList[position - 7].Background = Brushes.Cyan;
                        }
                    }
                    if (position - 9 > 0 && buttonList[position - 9].Background == Brushes.White &&
                         Operations.EdgeOperation(whitePieces, position - 9) == false)
                    {
                        if (position - 18 > 0 && buttonList[position - 18].Background == Brushes.Gray)
                        {
                            buttonList[position - 9].Background = Brushes.Cyan;
                        }
                    }
                    if (position + 7 < 63 && buttonList[position + 7].Background == Brushes.White &&
                     Operations.EdgeOperation(whitePieces, position + 7) == false)
                    {
                        if (position + 14 < 63 && buttonList[position + 14].Background == Brushes.Gray)
                        {
                            buttonList[position + 7].Background = Brushes.Cyan;
                        }
                    }
                    if (position + 9 < 63 && buttonList[position + 9].Background == Brushes.White &&
                         Operations.EdgeOperation(whitePieces, position + 9) == false)
                    {
                        if (position + 18 < 63 && buttonList[position + 18].Background == Brushes.Gray)
                        {
                            buttonList[position + 9].Background = Brushes.Cyan;
                        }
                    }
                }
            }
        }

        public static void EditTurn(Piece currentPiece, Button[] buttonList, ref bool pieceTaken, ref int takenPiecePos, 
                                    MainWindow.Turn turn, Stack<MainWindow.Turn> turns)
        {
            // Check if a piece was taken.
            if (pieceTaken == true)
            {
                // If so, update the struct.
                turn.pieceTaken = true;
                turn.takenPiecePos = takenPiecePos;
                
                if (buttonList.ElementAt(turn.takenPiecePos).Content.ToString() == "K")
                {
                    turn.wasTakenPieceKing = true;
                }
            }
            // Update the struct accordingly to record the turn.
            turn.pieceColour = currentPiece.GetColour();
            turn.piece1pos = currentPiece.GetPosition();
            turn.piece1NewPos = currentPiece.GetNewPosition();

            if (turn.piece1NewPos > 55 && turn.piece1NewPos < 64)
            {
                turn.wasPieceKing = true;
            }
            if (turn.piece1NewPos < 8)
            {
                turn.wasPieceKing = true;
            }

            turns.Push(turn);
        }

        public static Piece CheckForMove(Button currentCell, ref Piece currentPiece, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            Piece tempPiece = currentPiece;

            if (currentPiece.GetColour() == "White")
            {
                for (int i = 0; i < whitePieces.Count; i++)
                {
                    if (Operations.CheckDiagonal(currentPiece, whitePieces, blackPieces, buttonList, whitePieces[i].GetNewPosition()) == true)
                    {
                        tempPiece = whitePieces[i];
                        return tempPiece;
                    }
                }
            } 
            if (currentPiece.GetColour() == "Black")
            {
                for (int i = 0; i < blackPieces.Count; i++)
                {
                    if (Operations.CheckDiagonal(currentPiece, whitePieces, blackPieces, buttonList, blackPieces[i].GetNewPosition()) == true)
                    {
                        tempPiece = blackPieces[i];
                        return tempPiece;
                    }
                }
            }
            return tempPiece;
        }
    }
}