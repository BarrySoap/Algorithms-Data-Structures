using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: This contains the entry point for the program, and the
 *                flow of control.
 * Date last modified: 15/11/2017
 */

namespace ADSCoursework
{
    public partial class MainWindow : Window
    {
        /*****          Set Up Lists            *****/
        List<Piece> whitePieces = new List<Piece>();
        List<Piece> blackPieces = new List<Piece>();

        List<Piece> takenWhitePieces = new List<Piece>();
        List<Piece> takenBlackPieces = new List<Piece>();
        /********************************************/
        
        /***** General Variables *****/
        Button currentCell = new Button();
        Button[] buttonList = new Button[64];
        Player currentPlayer = new Player("White");
        Piece currentPiece = new Piece();
        Facade facade;
        public Stack<Turn> turns;
        public Stack<Turn> unDoneTurns;
        int turnOrder = 0;
        bool pieceTaken = false;

        public struct Turn
        {
            public string pieceColour;
            public int piece1pos;
            public int piece1NewPos;
            public int takenPiecePos;
            public bool pieceTaken;
            public bool wasPieceKing;
        }
        /*****************************/

        public MainWindow()
        {
            InitializeComponent();

            turns = new Stack<Turn>();
            unDoneTurns = new Stack<Turn>();
            
            facade = new Facade();
            facade.InitialFacade(this, whitePieces, blackPieces, buttonList, currentPlayer);
        }

        private void btnCell1_Click(object sender, RoutedEventArgs e)
        {
            // Initialise a new turn,
            Turn turn = new Turn();
            int takenPiecePos = 0;
            // Then set the clicked button as the current cell.
            currentCell = (Button)sender;
            
            // Call the logic for moving a piece,
            facade.MoveFacade(currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            // As well as taking a piece if needed.
            facade.TakeFacade(ref pieceTaken, currentPiece, currentCell, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList, ref takenPiecePos);

            // If the turn order is 0 (Which should have been decremented by the move facade),
            if (turnOrder == 0 && currentPiece.GetPosition() != currentPiece.GetNewPosition())
            {
                Operations.EditTurn(currentPiece, ref pieceTaken, ref takenPiecePos, turn, turns);
            }

            // Check that all the pieces are the correct colour.
            Operations.CheckColouring(whitePieces, blackPieces, buttonList);
            // Check if the game has ended.
            Validations.HasGameEnded(this, whitePieces, blackPieces);
            
            if (turnOrder == 0 && pieceTaken == false && currentCell.Background != Brushes.Gray)
            {
                facade.EndTurnFacade(this, currentPlayer, currentCell);
            } else if (turnOrder == 0 && pieceTaken == true && Operations.CheckDiagonal(currentPiece, whitePieces, blackPieces, buttonList, currentPiece.GetNewPosition()) == false)
            {
                facade.EndTurnFacade(this, currentPlayer, currentCell);
            }

            // Set the global boolean back to false if needed, so more pieces can be taken.
            pieceTaken = false;
        }

        // Undo logic from the facade class.
        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            facade.UndoFacade(this, ref turnOrder, currentPiece, currentPlayer, buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, unDoneTurns);
        }

        // Redo logic from the facade class.
        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            facade.RedoFacade(buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, unDoneTurns);
        }

        // Game replay logic from the facade class.
        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            facade.ReplayFacade(this, ref turnOrder, currentPlayer, buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces, unDoneTurns, currentPiece);
        }
    }
}