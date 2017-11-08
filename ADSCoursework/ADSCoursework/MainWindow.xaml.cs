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

        /*****    Set Up Players    *****/
        Player playerOne = new Player("White");
        Player playerTwo = new Player("Black");
        /********************************/

        /***** General Variables *****/
        Button currentCell = new Button();
        Button[] buttonList = new Button[64];
        Player currentPlayer = new Player("White");
        Piece currentPiece = new Piece();
        Facade facade;
        int turnOrder = 0;
        bool pieceTaken = false;
        /*****************************/

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                Piece whitePiece = new Piece();
                Piece blackPiece = new Piece();
                whitePiece.SetColour("White");
                blackPiece.SetColour("Black");
                whitePieces.Add(whitePiece);
                blackPieces.Add(blackPiece);
            }
            txtTurnOrder.Text = "Turn: " + playerOne.GetColour();
            
            facade = new Facade(this);
            facade.InitialFacade(this, whitePieces, blackPieces, buttonList);
        }

        private void btnCell1_Click(object sender, RoutedEventArgs e)
        {
            currentCell = (Button)sender;

            if (turnOrder == 0 && Validations.IsSpaceEmpty(currentCell) == false && Validations.IsPieceYours(currentCell, currentPlayer) == true)
            {
                if (currentCell.Background == Brushes.White && turnOrder == 0)
                {
                    currentPiece.SetColour("White");
                }
                else if (currentCell.Background == Brushes.Black && turnOrder == 0)
                {
                    currentPiece.SetColour("Black");
                }

                facade.MoveFacade(this, currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            }

            if (turnOrder == 1 && Validations.IsSpaceEmpty(currentCell) == true)
            {
                facade.MoveFacade(this, currentPiece, ref turnOrder, currentCell, buttonList, ref currentPlayer, ref pieceTaken, whitePieces, blackPieces);
            }

            facade.takeFacade(ref pieceTaken, currentPiece, currentCell, whitePieces, blackPieces, takenWhitePieces, takenBlackPieces, buttonList);
            Validations.IsPieceKing(currentCell, currentPiece, buttonList, Convert.ToInt32(currentPiece.GetPosition()),
                Convert.ToInt32(currentPiece.GetNewPosition()), ref pieceTaken, whitePieces, blackPieces);
            
            Operations.CheckColouring(whitePieces, blackPieces, buttonList);
            Validations.HasGameEnded(whitePieces, blackPieces);
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
            if (currentPlayer.GetColour() == "White")
            {
                currentPlayer.SetColour("Black");
                txtTurnOrder.Text = "Turn: Black";
            } else
            {
                currentPlayer.SetColour("White");
                txtTurnOrder.Text = "Turn: White";
            }
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            facade.undoFacade(this, ref turnOrder, currentPiece, currentCell, currentPlayer, buttonList);
        }
    }
}