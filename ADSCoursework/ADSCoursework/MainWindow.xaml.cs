using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        int turnOrder = 0;
        bool pieceTaken = false;

        public struct Turn
        {
            public string pieceColour;
            public int piece1pos;
            public int piece1NewPos;
            public int takenPiecePos;
            public bool pieceTaken;
        }
        /*****************************/

        public MainWindow()
        {
            InitializeComponent();

            turns = new Stack<Turn>();
            
            facade = new Facade(this);
            facade.InitialFacade(this, whitePieces, blackPieces, buttonList, currentPlayer);
        }

        private void btnCell1_Click(object sender, RoutedEventArgs e)
        {
            Turn turn = new Turn();
            int takenPiecePos = 0;
            currentCell = (Button)sender;
            
            facade.MoveFacade(currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            facade.TakeFacade(ref pieceTaken, currentPiece, currentCell, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList, ref takenPiecePos);

            if (turnOrder == 0 && currentPiece.GetPosition() != currentPiece.GetNewPosition())
            {
                if (pieceTaken == true)
                {
                    turn.pieceTaken = true;
                    turn.takenPiecePos = takenPiecePos;
                }

                turn.pieceColour = currentPiece.GetColour();
                turn.piece1pos = currentPiece.GetPosition();
                turn.piece1NewPos = currentPiece.GetNewPosition();
                turns.Push(turn);
            }

            pieceTaken = false;
            Operations.CheckColouring(whitePieces, blackPieces, buttonList);
            Validations.HasGameEnded(this, whitePieces, blackPieces);
        }

        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            facade.EndTurnFacade(this, currentPlayer, currentCell);
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            facade.UndoFacade(this, ref turnOrder, currentPiece, currentCell, currentPlayer, buttonList, whitePieces, blackPieces, turns, takenWhitePieces, takenBlackPieces);
        }
    }
}