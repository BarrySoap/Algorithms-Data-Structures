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
    class ButtonCleaning
    {
        public void CleanButtons(MainWindow main, Button[] buttonList)
        {
            // For all 64 tiles (or buttons), set the background colour to gray.
            for (int i = 0; i < 64; i++)
            {
                // Each button begins with the name: "btnCell", followed by a number for it's index in the list.
                buttonList[i] = (Button)main.FindName("btnCell" + i);
                buttonList[i].Background = Brushes.Gray;
            }

            for (int i = 0; i < 64; i++)
            {
                // Set Black Pieces in their respective starting positions //
                if (i % 2 == 0 && i < 8)
                {
                    buttonList[i].Background = Brushes.Black;
                }
                // If the index of the piece is odd, more than 8 and less than 16, set as a black piece.
                // (This will set the second row of pieces from the bottom on a checkers board).
                else if (i % 2 == 1 && i > 8 && i < 16)
                {
                    buttonList[i].Background = Brushes.Black;
                } else if (i % 2 == 0 && i > 15 && i < 23)
                {
                    buttonList[i].Background = Brushes.Black;
                }
                /***********************************************************/

                // Set White Pieces in their respective starting positions //
                if (i % 2 == 1 && i > 40 && i < 48)
                {
                    buttonList[i].Background = Brushes.White;
                }
                // If the index of the piece is even, more than 47 and less than 56, set as a white piece.
                // (This will set the second row of pieces from the top on a checkers board).
                else if (i % 2 == 0 && i > 47 && i < 56)
                {
                    buttonList[i].Background = Brushes.White;
                } else if (i % 2 == 1 && i > 55 && i < 64)
                {
                    buttonList[i].Background = Brushes.White;
                }
                /***********************************************************/
            }
        }

        // This method is used a check to see if any pieces are on the sides or edges of
        // the board.
        public void CleanEdges(MainWindow main, List<Piece> pieces)
        {
            // For each piece in a given list (black or white pieces)
            for (int i = 0; i < pieces.Count; i++)
            {
                // Check the entire left column of the board (indexes are divisible by 8).
                if (Convert.ToInt32(pieces[i].GetPosition()) % 8 == 0 ||
                    // Check if the index divided by eight returns a remainder of 7 (For the right column).
                    Convert.ToInt32(pieces[i].GetPosition()) % 8 == 7 ||
                    // For the top row,
                    Convert.ToInt32(pieces[i].GetPosition()) > 55 ||
                    // and then the bottom row.
                    Convert.ToInt32(pieces[i].GetPosition()) < 8)
                {
                    // If any of these if statements are true, then the piece must be on a side or edge of the board.
                    pieces[i].SetEdge(true);
                }
            }
        }
    }

    class SetInitialPieces
    {
        // This class/method is used to mutate the position variables of the piece classes, so that each piece
        // knows it's position on the starting board from inside the list.
        public void SetPieces(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // The bottom left tile of the board has index 0, so start there as it's a black piece. 
            int a = 0;
            // The 41st index holds the first white piece of the board.
            int b = 41;

            // For the amount of pieces on each side:
            for (int i = 0; i < 12; i++)
            {
                blackPieces[i].SetPosition(a.ToString());
                whitePieces[i].SetPosition(b.ToString());

                // Each piece is always separated by 2 spaces.
                a += 2;
                b += 2;

                if (a == 8)
                {
                    // As the 'a' accumulator reaches 8, the indexes are no longer 
                    // 2 spaces apart, unless they are at the 9th index instead.
                    a = 9;
                } else if (a == 17)
                {
                    a = 16;
                }

                if (b == 49)
                {
                    // Same scenario: As the index reaches 49, the spaces are no longer 
                    // 2 apart, so the accumulator has to be put back on track.
                    b = 48;
                } else if (b == 56)
                {
                    b = 57;
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
                    // If the space isn't empty:
                    if (Validations.IsSpaceEmpty(currentCell) == false)
                    {
                        // If a given cell has the name 'btnCell48', then this will set
                        // the position to '48'.
                        currentPiece.SetPosition(currentCell.Name.ToString().Substring(7));
                        // This validation will highlight cells as cyan based on
                        // whether or not they can be taken.
                        Validations.CanPieceBeTaken(currentCell, ref currentPiece, buttonList, Convert.ToInt32(currentPiece.GetPosition()));
                        // Highlight the currently selected cell as gold.
                        currentCell.Background = Brushes.Gold;
                        turnOrder++;
                    } else
                    {
                        MessageBox.Show("Please select a piece!");
                    }
                    break;
                case 1:
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
                                if (whitePieces[i].GetPosition() == currentPiece.GetPosition())
                                {
                                    whitePieces[i].SetNewPosition(currentCell.Name.ToString().Substring(7));
                                }
                            }
                            // This needs to be 2 separate for loops, to account for pieces being taken (can't use the same range value).
                            for (int i = 0; i < blackPieces.Count; i++)
                            {
                                if (blackPieces[i].GetPosition() == currentPiece.GetPosition())
                                {
                                    blackPieces[i].SetNewPosition(currentCell.Name.ToString().Substring(7));
                                }
                            }

                            currentPiece.SetNewPosition(currentCell.Name.ToString().Substring(7));

                            // Check if the move is valid, from within the Validations class.
                            if (Validations.IsMoveValid(currentCell, currentPiece, buttonList,
                                Convert.ToInt32(currentPiece.GetPosition()), Convert.ToInt32(currentPiece.GetNewPosition()), ref pieceTaken,
                                whitePieces, blackPieces) == true)
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
                            MessageBox.Show("Please move the piece to an empty space!");
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
                for (int i = 0; i < whitePieces.Count; i++)
                {
                    if (whitePieces[i].Taken() == true)
                    {
                        takenWhitePieces.Add(whitePieces[i]);
                        whitePieces.Remove(whitePieces[i]);
                    }
                }
                for (int j = 0; j < blackPieces.Count; j++)
                {
                    if (blackPieces[j].Taken() == true)
                    {
                        takenBlackPieces.Add(blackPieces[j]);
                        blackPieces.Remove(blackPieces[j]);
                    }
                }
                pieceTaken = false;
            }
        }
    }

    public class Facade
    {
        ButtonCleaning cleaner;
        SetInitialPieces setPieces;
        TurnOrder turn;
        UndoRedoMoves unredo;
        TakePiece tp;

        // Initialise the subsystems as a Facade constructor.
        public Facade(MainWindow main)
        {
            cleaner = new ButtonCleaning();
            turn = new TurnOrder();
            setPieces = new SetInitialPieces();
            unredo = new UndoRedoMoves();
            tp = new TakePiece();
        }

        public void InitialFacade(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList)
        {
            cleaner.CleanButtons(main, buttonList);
            setPieces.SetPieces(main, whitePieces, blackPieces);
            cleaner.CleanEdges(main, whitePieces);
            cleaner.CleanEdges(main, blackPieces);
        }

        public void MoveFacade(MainWindow main, Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList, ref Player currentPlayer, 
            ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            turn.MovePiece(main, currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
        }

        public void undoFacade(MainWindow main, ref int turnOrder, Button currentCell, Player currentPlayer, Button[] buttonList)
        {
            unredo.UndoMove(main, ref turnOrder, currentCell, currentPlayer, buttonList);
        }

        public void takeFacade(ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces,
            Button[] buttonList)
        {
            tp.TakePieces(ref pieceTaken, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList);
        }
    }
}
