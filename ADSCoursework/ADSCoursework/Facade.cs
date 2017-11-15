using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains all logic for making the game run, including moving pieces,
 *                taking pieces, undo moves, redo moves, etc.
 * Date last modified: 15/11/2017
 */

namespace ADSCoursework
{
    class BoardCleaning
    {
        public void CleanButtons(MainWindow main, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces, Player currentPlayer)
        {
            // Accumulator for iterating through each black piece.
            int j = 0;
            // Accumulator for iterating through each white piece.
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

            // On the GUI, show who's turn it is.
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
                // Set Black Pieces in their respective starting positions:
                if (i % 2 == 0 && i < 8)
                {
                    blackPieces[j].SetPosition(i);
                    blackPieces[j].SetNewPosition(i);
                    buttonList[i].Background = Brushes.Black;
                    j++;
                }
                // If the index of the piece is odd, more than 8 and less than 16, set as a black piece.
                // (This will set the second row of pieces from the bottom on a checkers board).
                else if (i % 2 == 1 && i > 8 && i < 16)
                {
                    blackPieces[j].SetPosition(i);
                    blackPieces[j].SetNewPosition(i);
                    buttonList[i].Background = Brushes.Black;
                    j++;
                    // And finally, the top row of black pieces.
                }
                else if (i % 2 == 0 && i > 15 && i < 23)
                {
                    blackPieces[j].SetPosition(i);
                    blackPieces[j].SetNewPosition(i);
                    buttonList[i].Background = Brushes.Black;
                    j++;
                }

                // Set White Pieces in their respective starting positions:
                if (i % 2 == 1 && i > 40 && i < 48)
                {
                    whitePieces[k].SetPosition(i);
                    whitePieces[k].SetNewPosition(i);
                    buttonList[i].Background = Brushes.White;
                    k++;
                }
                // If the index of the piece is even, more than 47 and less than 56, set as a white piece.
                // (This will set the second row of pieces from the top on a checkers board).
                else if (i % 2 == 0 && i > 47 && i < 56)
                {
                    whitePieces[k].SetPosition(i);
                    whitePieces[k].SetNewPosition(i);
                    buttonList[i].Background = Brushes.White;
                    k++;
                    // And finally, the top row.
                }
                else if (i % 2 == 1 && i > 55 && i < 64)
                {
                    whitePieces[k].SetPosition(i);
                    whitePieces[k].SetNewPosition(i);
                    buttonList[i].Background = Brushes.White;
                    k++;
                }
            }
        }

        // This method is used as a constant check to see if any pieces are on the
        // sides or edges of the board.
        public void CleanEdges(List<Piece> pieces)
        {
            // For each piece in a given list (black or white pieces)
            for (int i = 0; i < pieces.Count; i++)
            {
                // Check the entire left column of the board (indexes are divisible by 8).
                if (pieces[i].GetNewPosition() % 8 == 0 ||
                    // Check if the index divided by eight returns a remainder of 7 (For the right column).
                    pieces[i].GetNewPosition() % 8 == 7 ||
                    // For the top row,
                    pieces[i].GetNewPosition() > 55 ||
                    // and then the bottom row.
                    pieces[i].GetNewPosition() < 8)
                {
                    // If any of these if statements are true, then the piece must be on a side or edge of the board.
                    pieces[i].SetEdge(true);
                }
                else
                {
                    pieces[i].SetEdge(false);
                }
            }
        }
    }

    class TurnOrder
    {
        // This class/method contains all of the logic for the basic movement of a piece.
        public void MovePiece(Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList, ref Player currentPlayer,
            ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            // Turn order is split into 2 parts: 0, which involves the player selecting a piece to move,
            // and 1, which involves the player moving the piece to a new location.
            switch (turnOrder)
            {
                case 0:
                    // If the cell is white, the current piece selected must be white.
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
                    currentPiece.SetPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));
                    currentPiece.SetNewPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));

                    // If the space isn't empty:
                    if (Validations.IsSpaceEmpty(currentCell) == false && Validations.IsPieceYours(currentCell, currentPlayer))
                    {
                        // This validation will highlight cells as cyan based on
                        // whether or not they can be taken.
                        Validations.CanPieceBeTaken(currentCell, ref currentPiece, buttonList, whitePieces, blackPieces);
                        // Highlight the currently selected cell as gold.
                        currentCell.Background = Brushes.Gold;

                        // If it passes, set the new position.
                        for (int i = 0; i < whitePieces.Count; i++)
                        {
                            if (currentPlayer.GetColour() == "White" && whitePieces[i].GetNewPosition() == currentPiece.GetPosition())
                            {
                                whitePieces[i].SetPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));
                            }
                        }
                        // This needs to be 2 separate for loops, to account for pieces being taken (can't use the same range value).
                        for (int i = 0; i < blackPieces.Count; i++)
                        {
                            if (currentPlayer.GetColour() == "Black" && blackPieces[i].GetNewPosition() == currentPiece.GetPosition())
                            {
                                blackPieces[i].SetPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));
                            }
                        }

                        // Increment the turn order.
                        turnOrder++;
                    }
                    break;
                case 1:
                    currentPiece.SetNewPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));

                    // Check if the piece isn't trying to be moved to the same space.
                    if (Convert.ToInt32(currentCell.Name.ToString().Substring(7)) != currentPiece.GetPosition())
                    {
                        // After a piece has been moved, a check has to be made
                        // incase there are any pieces still highlighted as cyan.
                        for (int i = 0; i < buttonList.Length; i++)
                        {
                            if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "White")
                            {
                                buttonList[i].Background = Brushes.Black;
                            }
                            else if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "Black")
                            {
                                buttonList[i].Background = Brushes.White;
                            }
                        }

                        // Check if the piece is being moved to an empty cell.
                        if (Validations.IsSpaceEmpty(currentCell) == true)
                        {
                            // Check if the move is valid, from within the Validations class.
                            if (Validations.IsMoveValid(currentCell, currentPiece, buttonList, currentPiece.GetPosition(),
                                currentPiece.GetNewPosition(), ref pieceTaken, whitePieces, blackPieces) == true &&
                                Operations.EdgeToEdge(currentPiece.GetPosition(), currentPiece.GetNewPosition()) == false)
                            {
                                // If it passes, set the new position.
                                for (int i = 0; i < whitePieces.Count; i++)
                                {
                                    if (currentPlayer.GetColour() == "White" && whitePieces[i].GetNewPosition() == currentPiece.GetPosition())
                                    {
                                        whitePieces[i].SetNewPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));
                                    }
                                }
                                // This needs to be 2 separate for loops, to account for pieces being taken (can't use the same range value).
                                for (int i = 0; i < blackPieces.Count; i++)
                                {
                                    if (currentPlayer.GetColour() == "Black" && blackPieces[i].GetNewPosition() == currentPiece.GetPosition())
                                    {
                                        blackPieces[i].SetNewPosition(Convert.ToInt32(currentCell.Name.ToString().Substring(7)));
                                    }
                                }
                                // Set the previous cell (where the piece used to be) back to gray.
                                buttonList.ElementAt(currentPiece.GetPosition()).Background = Brushes.Gray;
                                if (currentPiece.GetColour() == "White")
                                {
                                    // The new position should be for a white piece.
                                    buttonList.ElementAt(currentPiece.GetNewPosition()).Background = Brushes.White;
                                }
                                else
                                {
                                    buttonList.ElementAt(currentPiece.GetNewPosition()).Background = Brushes.Black;
                                }

                                // Check if the piece is a king. If so, update accordingly.
                                Validations.IsPieceKing(currentCell, currentPiece, buttonList, currentPiece.GetPosition(),
                                    currentPiece.GetNewPosition(), ref pieceTaken, whitePieces, blackPieces);

                                // Decrement the turn order so that more moves can be made.
                                turnOrder--;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Move is not valid!");
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please make a valid move!");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can't move a piece to the same place!");
                        break;
                    }
            }
        }

        // This method is used to end a turn.
        public void EndTurn(MainWindow main, Player currentPlayer, Button currentCell)
        {
            // If there aren't any pieces currently highlighted,
            if (currentPlayer.GetColour() == "White")
            {
                // The current player is the opposite of the previous turns' player.
                currentPlayer.SetColour("Black");
                main.txtTurnOrder.Text = "Turn: Black";
            }
            else if (currentPlayer.GetColour() == "Black")
            {
                currentPlayer.SetColour("White");
                main.txtTurnOrder.Text = "Turn: White";
            }
        }
    }

    // This class contains logic undo/redoing a move.
    class UndoRedoMoves
    {
        public void UndoMove(MainWindow main, ref int turnOrder, Player currentPlayer, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces,
            Stack<MainWindow.Turn> turns, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Stack<MainWindow.Turn> undoneTurns)
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
            // If there are recorded turns,
            else if (turns.Count > 0)
            {
                // Get the latest turn.
                MainWindow.Turn temp = turns.Pop();
                // Push this turn onto a stack so that it can be redone.
                undoneTurns.Push(temp);

                for (int i = 0; i < whitePieces.Count; i++)
                {
                    // If the latest turn was a white piece being moved,
                    if (temp.pieceColour == "White")
                    {
                        // Iterate through the list of pieces to find the piece in question (using their positions).
                        if (temp.piece1pos == whitePieces[i].GetPosition() ||
                        temp.piece1NewPos == whitePieces[i].GetPosition() || temp.piece1NewPos == whitePieces[i].GetNewPosition())
                        {
                            if (temp.wasPieceKing == true && temp.piece1NewPos < 55)
                            {
                                buttonList.ElementAt(temp.piece1NewPos).Content = "K";
                                buttonList.ElementAt(temp.piece1NewPos).Foreground = Brushes.Black;
                            }
                            else
                            {
                                buttonList.ElementAt(temp.piece1NewPos).Content = buttonList.ElementAt(temp.piece1NewPos).Name.Substring(7);
                            }
                            // The current cell has to be set back to empty,
                            buttonList.ElementAt(temp.piece1NewPos).Background = Brushes.Gray;
                            whitePieces[i].SetNewPosition(temp.piece1pos);
                            // Then the previous cell must be the new selection.
                            buttonList.ElementAt(temp.piece1pos).Background = Brushes.White;
                            currentPlayer.SetColour("White");
                            main.txtTurnOrder.Text = "Turn: White";
                        }
                    }
                }
                for (int i = 0; i < blackPieces.Count; i++)
                {
                    if (temp.pieceColour == "Black")
                    {
                        if (temp.piece1pos == blackPieces[i].GetPosition() ||
                        temp.piece1NewPos == blackPieces[i].GetPosition() || temp.piece1NewPos == blackPieces[i].GetNewPosition())
                        {
                            if (temp.wasPieceKing == true && temp.piece1NewPos < 55)
                            {
                                buttonList.ElementAt(temp.piece1pos).Content = "K";
                                buttonList.ElementAt(temp.piece1pos).Foreground = Brushes.White;
                            }
                            else
                            {
                                buttonList.ElementAt(temp.piece1pos).Content = buttonList.ElementAt(temp.piece1pos).Name.Substring(7);
                                buttonList.ElementAt(temp.piece1pos).Foreground = Brushes.Black;
                            }
                            buttonList.ElementAt(temp.piece1NewPos).Background = Brushes.Gray;
                            blackPieces[i].SetNewPosition(temp.piece1pos);
                            buttonList.ElementAt(temp.piece1pos).Background = Brushes.Black;
                            currentPlayer.SetColour("Black");
                            main.txtTurnOrder.Text = "Turn: Black";
                        }
                    }
                }
                Operations.CheckColouring(whitePieces, blackPieces, buttonList);

                // If a piece was taken during the turn,
                if (temp.pieceTaken == true)
                {
                    for (int i = 0; i < takenWhitePieces.Count; i++)
                    {
                        // Find the piece in question from the list of taken pieces.
                        if (temp.takenPiecePos == takenWhitePieces[i].GetPosition() || temp.takenPiecePos == takenWhitePieces[i].GetNewPosition())
                        {
                            // Take the piece from the list,
                            Piece tempPiece = takenWhitePieces.ElementAt(i);
                            takenWhitePieces.RemoveAt(i);
                            tempPiece.SetTaken(false);
                            // Then add it back to the original pieces list.
                            whitePieces.Add(tempPiece);
                            // Show it on the board.
                            buttonList.ElementAt(temp.takenPiecePos).Background = Brushes.White;
                        }
                    }
                    for (int j = 0; j < takenBlackPieces.Count; j++)
                    {
                        if (temp.takenPiecePos == takenBlackPieces[j].GetPosition() || temp.takenPiecePos == takenBlackPieces[j].GetNewPosition())
                        {
                            Piece tempPiece = takenBlackPieces.ElementAt(j);
                            takenBlackPieces.RemoveAt(j);
                            tempPiece.SetTaken(false);
                            blackPieces.Add(tempPiece);
                            buttonList.ElementAt(temp.takenPiecePos).Background = Brushes.Black;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No moves to undo!");
            }

            for (int i = 0; i < buttonList.Length; i++)
            {
                // If any pieces are highlighted as 'able to be taken',
                if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "White")
                {
                    // Set them back to their respective colours.
                    buttonList[i].Background = Brushes.Black;
                }
                else if (buttonList[i].Background == Brushes.Cyan && currentPlayer.GetColour() == "Black")
                {
                    buttonList[i].Background = Brushes.White;
                }
            }
        }

        public void RedoMove(Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces,
            Stack<MainWindow.Turn> turns, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Stack<MainWindow.Turn> undoneTurns)
        {
            // Check if any moves were undone.
            if (undoneTurns.Count > 0)
            {
                // Get the latest undone turn.
                MainWindow.Turn temp = undoneTurns.Pop();
                turns.Push(temp);

                // All the logic is the same as the previous 'undo' function, except for a couple of changes.
                for (int i = 0; i < whitePieces.Count; i++)
                {
                    if (temp.pieceColour == "White")
                    {
                        // The original pieces list has to be iterated through, rather than the list of taken pieces.
                        if (temp.piece1pos == whitePieces[i].GetPosition() ||
                        temp.piece1NewPos == whitePieces[i].GetPosition() || temp.piece1NewPos == whitePieces[i].GetNewPosition())
                        {
                            // The original cell is then set back to empty,
                            buttonList.ElementAt(temp.piece1pos).Background = Brushes.Gray;
                            whitePieces[i].SetNewPosition(temp.piece1NewPos);
                            // Whereas the new cell as rechosen as the position.
                            buttonList.ElementAt(temp.piece1NewPos).Background = Brushes.White;
                        }
                    }
                }
                for (int i = 0; i < blackPieces.Count; i++)
                {
                    if (temp.pieceColour == "Black")
                    {
                        if (temp.piece1pos == blackPieces[i].GetPosition() ||
                        temp.piece1NewPos == blackPieces[i].GetPosition() || temp.piece1NewPos == blackPieces[i].GetNewPosition())
                        {
                            buttonList.ElementAt(temp.piece1pos).Background = Brushes.Gray;
                            blackPieces[i].SetNewPosition(temp.piece1NewPos);
                            buttonList.ElementAt(temp.piece1NewPos).Background = Brushes.Black;
                        }
                    }
                }

                if (temp.pieceTaken == true)
                {
                    for (int i = 0; i < whitePieces.Count; i++)
                    {
                        if (temp.takenPiecePos == whitePieces[i].GetPosition() || temp.takenPiecePos == whitePieces[i].GetNewPosition())
                        {
                            Piece tempPiece = whitePieces.ElementAt(i);
                            whitePieces.RemoveAt(i);
                            tempPiece.SetTaken(true);
                            takenWhitePieces.Add(tempPiece);
                            buttonList.ElementAt(temp.takenPiecePos).Background = Brushes.Gray;
                        }
                    }
                    for (int j = 0; j < blackPieces.Count; j++)
                    {
                        if (temp.takenPiecePos == blackPieces[j].GetPosition() || temp.takenPiecePos == blackPieces[j].GetNewPosition())
                        {
                            Piece tempPiece = blackPieces.ElementAt(j);
                            blackPieces.RemoveAt(j);
                            tempPiece.SetTaken(true);
                            takenBlackPieces.Add(tempPiece);
                            buttonList.ElementAt(temp.takenPiecePos).Background = Brushes.Gray;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No moves to redo!");
            }
        }

        // This method contains logic for replaying a game.
        public void ReplayGame(MainWindow main, ref int turnOrder, Player currentPlayer, Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces,
            Stack<MainWindow.Turn> turns, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Stack<MainWindow.Turn> undoneTurns)
        {
            // If there are still turns,
            while (turns.Count > 0)
            {
                // Put the board back to it's original state,
                this.UndoMove(main, ref turnOrder, currentPlayer, buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, undoneTurns);
            }
            while (undoneTurns.Count > 0)
            {
                // Then redo all the moves as a replay.
                this.RedoMove(buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, undoneTurns);
            }
        }
    }

    // This class contains logic solely for taking a piece.
    class TakePiece
    {
        public void TakePieces(ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces,
            Button[] buttonList, ref int takenPiecePos)
        {
            // If the global boolean was triggered to signal a piece being taken,
            if (pieceTaken == true)
            {
                int tempPos = 0;

                // Check if a white piece was taken.
                for (int i = 0; i < whitePieces.Count; i++)
                {
                    // If so,
                    if (whitePieces[i].Taken() == true)
                    {
                        tempPos = whitePieces[i].GetNewPosition();
                        // Update the turn struct with the position of the taken piece.
                        takenPiecePos = tempPos;
                        // Then, add it to a list of taken pieces.
                        takenWhitePieces.Add(whitePieces[i]);
                        // Set the cell to empty,
                        buttonList[tempPos].Background = Brushes.Gray;
                        // Then remove it from the active pieces.
                        whitePieces.Remove(whitePieces[i]);
                    }
                }

                for (int j = 0; j < blackPieces.Count; j++)
                {
                    if (blackPieces[j].Taken() == true)
                    {
                        tempPos = blackPieces[j].GetNewPosition();
                        takenPiecePos = tempPos;
                        takenBlackPieces.Add(blackPieces[j]);
                        buttonList[tempPos].Background = Brushes.Gray;
                        blackPieces.Remove(blackPieces[j]);
                    }
                }
            }
        }
    }

    public class Facade
    {
        BoardCleaning cleaner;
        TurnOrder turnOrd;
        UndoRedoMoves unredo;
        TakePiece tp;

        // Initialise the subsystems as a Facade constructor.
        public Facade()
        {
            cleaner = new BoardCleaning();
            turnOrd = new TurnOrder();
            unredo = new UndoRedoMoves();
            tp = new TakePiece();
        }

        public void InitialFacade(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList, Player currentPlayer)
        {
            cleaner.CleanButtons(main, buttonList, whitePieces, blackPieces, currentPlayer);
            cleaner.CleanEdges(whitePieces);
            cleaner.CleanEdges(blackPieces);
        }

        public void MoveFacade(Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList, ref Player currentPlayer,
            ref bool pieceTaken, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            turnOrd.MovePiece(currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            cleaner.CleanEdges(whitePieces);
            cleaner.CleanEdges(blackPieces);
        }

        public void TakeFacade(ref bool pieceTaken, Piece currentPiece, Button currentCell, List<Piece> whitePieces, List<Piece> blackPieces,
            List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Button[] buttonList, ref int takenPiecePos)
        {
            tp.TakePieces(ref pieceTaken, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList, ref takenPiecePos);
        }

        public void UndoFacade(MainWindow main, ref int turnOrder, Piece currentPiece, Player currentPlayer, Button[] buttonList,
            List<Piece> whitePieces, List<Piece> blackPieces, Stack<MainWindow.Turn> turns, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Stack<MainWindow.Turn> undoneTurns)
        {
            unredo.UndoMove(main, ref turnOrder, currentPlayer, buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, undoneTurns);
        }

        public void RedoFacade(Button[] buttonList, List<Piece> whitePieces, List<Piece> blackPieces, Stack<MainWindow.Turn> turns,
            List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Stack<MainWindow.Turn> undoneTurns)
        {
            unredo.RedoMove(buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, undoneTurns);
        }

        public void EndTurnFacade(MainWindow main, Player currentPlayer, Button currentCell)
        {
            turnOrd.EndTurn(main, currentPlayer, currentCell);
        }

        public void ReplayFacade(MainWindow main, ref int turnOrder, Player currentPlayer, Button[] buttonList,
            List<Piece> whitePieces, List<Piece> blackPieces, Stack<MainWindow.Turn> turns, List<Piece> takenWhitePieces, List<Piece> takenBlackPieces, Stack<MainWindow.Turn> undoneTurns)
        {
            unredo.ReplayGame(main, ref turnOrder, currentPlayer, buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, undoneTurns);
        }
    }
}