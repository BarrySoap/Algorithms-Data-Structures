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
            public int piece1pos;
            public int piece1NewPos;
            public bool pieceTaken;
            public int piece2pos;
            public int piece2NewPos;
        }
        /*****************************/

        public MainWindow()
        {
            InitializeComponent();

            turns = new Stack<Turn>();
            facade = new Facade(this, turns);
            facade.InitialFacade(this, whitePieces, blackPieces, buttonList, currentPlayer);
        }

        private void btnCell1_Click(object sender, RoutedEventArgs e)
        {
            currentCell = (Button)sender;

            facade.MoveFacade(currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            facade.TakeFacade(ref pieceTaken, currentPiece, currentCell, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList);
            
            Operations.CheckColouring(whitePieces, blackPieces, buttonList);
            Validations.HasGameEnded(this, whitePieces, blackPieces);
        }

        private void btnConsole_Click(object sender, RoutedEventArgs e)
        {
            ConsoleAllocator.ShowConsoleWindow();
        }

        private void btnCloseConsole_Click(object sender, RoutedEventArgs e)
        {
            ConsoleAllocator.HideConsoleWindow();
        }

        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            facade.EndTurnFacade(this, currentPlayer, currentCell);
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            facade.UndoFacade(this, ref turnOrder, currentPiece, currentCell, currentPlayer, buttonList);
        }
    }
}