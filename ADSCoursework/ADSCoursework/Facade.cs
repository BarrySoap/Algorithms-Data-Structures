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
    class BoardCleaning
    {
        public void CleanButtons(MainWindow main, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces, Player currentPlayer)
        {
            int j = 0;
            int k = 0;

            for (int i = 0; i < 12; i++)
            {
                Piece whitePiece = new Piece();
                Piece blackPiece = new Piece();
                whitePiece.SetColour("White");
                blackPiece.SetColour("Black");
                whitePieces.Add(whitePiece);
                blackPieces.Add(blackPiece);
            }

            main.txtTurnOrder.Text = "Turn: " + currentPlayer.GetColour();

            // For all 64 tiles (or buttons), set the background colour to gray.
            for (int i = 0; i < 64; i++)
            {
                // Each button begins with the name: "btnCell", followed by a number for it's index in the list.
                buttonList[i] = (Button)main.FindName("btnCell" + i);
                buttonList[i].Background = Brushes.Gray;
                buttonList[i].Content = buttonList[i].Name.Substring(7);
            }

            for (int i = 0; i < 64; i++)
            {
                // Set Black Pieces in their respective starting positions //
                if (i % 2 == 0 && i < 8)
                {
                    blackPieces[j].SetPosition(i.ToString());
                    blackPieces[j].SetNewPosition(i.ToString());
                    buttonList[i].Background = Brushes.Black;
                    j++;
                }
                // If the index of the piece is odd, more than 8 and less than 16, set as a black piece.
                // (This will set the second row of pieces from the bottom on a checkers board).
                else if (i % 2 == 1 && i > 8 && i < 16)
                {
                    blackPieces[j].SetPosition(i.ToString());
                    blackPieces[j].SetNewPosition(i.ToString());
                    buttonList[i].Background = Brushes.Black;
                    j++;
                // And finally, the top row of black pieces.
                } else if (i % 2 == 0 && i > 15 && i < 23)
                {
                    blackPieces[j].SetPosition(i.ToString());
                    blackPieces[j].SetNewPosition(i.ToString());
                    buttonList[i].Background = Brushes.Black;
                    j++;
                }
                /***********************************************************/

                // Set White Pieces in their respective starting positions //
                if (i % 2 == 1 && i > 40 && i < 48)
                {
                    whitePieces[k].SetPosition(i.ToString());
                    whitePieces[k].SetNewPosition(i.ToString());
                    buttonList[i].Background = Brushes.White;
                    k++;
                }
                // If the index of the piece is even, more than 47 and less than 56, set as a white piece.
                // (This will set the second row of pieces from the top on a checkers board).
                else if (i % 2 == 0 && i > 47 && i < 56)
                {
                    whitePieces[k].SetPosition(i.ToString());
                    whitePieces[k].SetNewPosition(i.ToString());
                    buttonList[i].Background = Brushes.White;
                    k++;
                // And finally, the top row.
                } else if (i % 2 == 1 && i > 55 && i < 64)
                {
                    whitePieces[k].SetPosition(i.ToString());
                    whitePieces[k].SetNewPosition(i.ToString());
                    buttonList[i].Background = Brushes.White;
                    k++;
                }
                /***********************************************************/
            }
        }

        // This method is used a check to see if any pieces are on the sides or edges of
        // the board.
        public void CleanEdges(List<Piece> pieces)
        {
            // For each piece in a given list (black or white pieces)
            for (int i = 0; i < pieces.Count; i++)
            {
                // Check the entire left column of the board (indexes are divisible by 8).
                if (Convert.ToInt32(pieces[i].GetNewPosition()) % 8 == 0 ||
                    // Check if the index divided by eight returns a remainder of 7 (For the right column).
                    Convert.ToInt32(pieces[i].GetNewPosition()) % 8 == 7 ||
                    // For the top row,
                    Convert.ToInt32(pieces[i].GetNewPosition()) > 55 ||
                    // and then the bottom row.
                    Convert.ToInt32(pieces[i].GetNewPosition()) < 8)
                {
                    // If any of these if statements are true, then the piece must be on a side or edge of the board.
                    pieces[i].SetEdge(true);
                } else
                {
                    pieces[i].SetEdge(false);
                }
            }
        }
    }

    class TurnOrder
    {
        // This class/method contains all of the logic for the basic movement of a piece.
        public void MovePiece(MainWindow main, Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList, ref Player currentPlayer, 
            ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // Turn order is split into 2 parts: 0, which involves the player selecting a piece to move,
            // and 1, which involves the player moving the piece to a new location.
            switch (turnOrder)
            {
                case 0:

                    if (currentCell.Background == Brushes.White)
                    {
                        currentPiece.SetColour("White");
                    }
                    else if (currentCell.Background == Brushes.Black)
                    {
                        currentPiece.SetColour("Black");
                    }

                    // If a given cell has the name 'btnCell48', then this will set
                    // the position to '48'.
                    currentPiece.SetPosition(currentCell.Name.ToString().Substring(7));
                    currentPiece.SetNewPosition(currentCell.Name.ToString().Substring(7));

                    // If the space isn't empty:
                    if (Validations.IsSpaceEmpty(currentCell) == false)
                    {
                        // This validation will highlight cells as cyan based on
                        // whether or not they can be taken.
                        Validations.CanPieceBeTaken(currentCell, ref currentPiece, buttonList, whitePieces, blackPieces);
                        // Highlight the currently selected cell as gold.
                        currentCell.Background = Brushes.Gold;
                        turnOrder++;
                    } else
                    {
                        MessageBox.Show("Please select a piece!");
                    }
                    break;
                case 1:
                    currentPiece.SetNewPosition(currentCell.Name.ToString().Substring(7));

                    // Check if the piece isn't trying to be moved to the same space.
                    if (currentCell.Name.ToString().Substring(7) != currentPiece.GetPosition())
                    {
                        // After a piece has been moved, a check has to be made
                        // incase there are any pieces still highlighted as cyan.
                        for (int i = 0; i < buttonList.Length; i++)
                        {
                            if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "White")
                            {
                                buttonList[i].Background = Brushes.Black;
                            } else if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "Black")
                            {
                                buttonList[i].Background = Brushes.White;
                            }
                        }

                        // Check if the piece is being moved to an empty cell.
                        if (Validations.IsSpaceEmpty(currentCell) == true)
                        {
                            // If it passes, set the new position.
                            for (int i = 0; i < whitePieces.Count; i++)
                            {
                                if (currentPlayer.GetColour() == "White" && whitePieces[i].GetPosition() == currentPiece.GetPosition() ||
                                    whitePieces[i].GetNewPosition() == currentPiece.GetPosition())
                                {
                                    whitePieces[i].SetNewPosition(currentCell.Name.ToString().Substring(7));
                                }
                            }
                            // This needs to be 2 separate for loops, to account for pieces being taken (can't use the same range value).
                            for (int i = 0; i < blackPieces.Count; i++)
                            {
                                if (currentPlayer.GetColour() == "Black" && blackPieces[i].GetPosition() == currentPiece.GetPosition() ||
                                    blackPieces[i].GetNewPosition() == currentPiece.GetPosition())
                                {
                                    blackPieces[i].SetNewPosition(currentCell.Name.ToString().Substring(7));
                                }
                            }

                            // Check if the move is valid, from within the Validations class.
                            if (Validations.IsMoveValid(currentCell, currentPiece, buttonList, Convert.ToInt32(currentPiece.GetPosition()), 
                                Convert.ToInt32(currentPiece.GetNewPosition()), ref pieceTaken, whitePieces, blackPieces) == true && 
                                Operations.EdgeToEdge(Convert.ToInt32(currentPiece.GetPosition()), Convert.ToInt32(currentPiece.GetNewPosition())) == false)
                            {

                                // Set the previous cell (where the piece used to be) back to gray.
                                buttonList.ElementAt(Convert.ToInt32(currentPiece.GetPosition())).Background = Brushes.Gray;
                                if (currentPiece.GetColour() == "White")
                                {
                                    // The new position should be for a white piece.
                                    buttonList.ElementAt(Convert.ToInt32(currentPiece.GetNewPosition())).Background = Brushes.White;
                                }
                                else
                                {
                                    buttonList.ElementAt(Convert.ToInt32(currentPiece.GetNewPosition())).Background = Brushes.Black;
                                }
                                // Decrement the turn order so that more moves can be made.
                                turnOrder--;
                                break;
                            } else
                            {
                                MessageBox.Show("Move is not valid!");
                                break;
                            }
                        } else
                        {
                            MessageBox.Show("Please make a valid move!");
                            break;
                        }
                    } else
                    {
                        MessageBox.Show("You can't move a piece to the same place!");
                        break;
                    }
            }
        }
    }

    class UndoRedoMoves
    {
        public void UndoMove(MainWindow main, ref int turnOrder, Button currentCell, Player currentPlayer, Button[] buttonList)
        {
            // If a piece was already selected to be moved,
            if (turnOrder == 1)
            {
                // Decrement the turn order.
                turnOrder = 0;

                for (int i = 0; i < buttonList.Length; i++)
                {
                    // If a piece is currently chosen and highlighted,
                    if (buttonList[i].Background == Brushes.Gold && currentPlayer.GetColour() == "White")
                    {
                        // Set it back to it's respective colour.
                        buttonList[i].Background = Brushes.White;
                    }
                    else if (buttonList[i].Background == Brushes.Gold && currentPlayer.GetColour() == "Black")
                    {
                        buttonList[i].Background = Brushes.Black;
                    }
                }
            }

            for (int i = 0; i < buttonList.Length; i++)
            {
                // If any pieces are highlighted as 'able to be taken',
                if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "White")
                {
                    // Set them back to their respective colours.
                    buttonList[i].Background = Brushes.Black;
                } else if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "Black")
                {
                    buttonList[i].Background = Brushes.White;
                }
            }
        }
    }

    class TakePiece
    {
        public void TakePieces(ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces,
            Button[] buttonList)
        {
            if (pieceTaken == true)
            {
                int tempPos = 0;

                for (int i = 0; i < whitePieces.Count; i++)
                {
                    if (whitePieces[i].Taken() == true)
                    {
                        tempPos = Convert.ToInt32(whitePieces[i].GetNewPosition());
                        takenWhitePieces.Add(whitePieces[i]);
                        buttonList[tempPos].Background = Brushes.Gray;
                        whitePieces.Remove(whitePieces[i]);
                    }
                }

                for (int j = 0; j < blackPieces.Count; j++)
                {
                    if (blackPieces[j].Taken() == true)
                    {
                        tempPos = Convert.ToInt32(blackPieces[j].GetNewPosition());
                        takenBlackPieces.Add(blackPieces[j]);
                        buttonList[tempPos].Background = Brushes.Gray;
                        blackPieces.Remove(blackPieces[j]);
                    }
                }

                pieceTaken = false;
            }
        }
    }

    public class Facade
    {
        BoardCleaning cleaner;
        TurnOrder turn;
        UndoRedoMoves unredo;
        TakePiece tp;

        // Initialise the subsystems as a Facade constructor.
        public Facade(MainWindow main)
        {
            cleaner = new BoardCleaning();
            turn = new TurnOrder();
            unredo = new UndoRedoMoves();
            tp = new TakePiece();
        }

        public void InitialFacade(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList, Player currentPlayer)
        {
            cleaner.CleanButtons(main, buttonList, whitePieces, blackPieces, currentPlayer);
            cleaner.CleanEdges(whitePieces);
            cleaner.CleanEdges(blackPieces);
        }

        public void MoveFacade(MainWindow main, Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList, ref Player currentPlayer, 
            ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            turn.MovePiece(main, currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            cleaner.CleanEdges(whitePieces);
            cleaner.CleanEdges(blackPieces);
        }

        public void undoFacade(MainWindow main, ref int turnOrder, Piece currentPiece, Button currentCell, Player currentPlayer, Button[] buttonList)
        {
            unredo.UndoMove(main, ref turnOrder, currentCell, currentPlayer, buttonList);
        }

        public void takeFacade(ref bool pieceTaken, Piece currentPiece, Button currentCell, List<Piece> whitePieces, List<Piece> blackPieces, 
            List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Button[] buttonList)
        {
            tp.TakePieces(ref pieceTaken, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList);
        }
    }
}
