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
        /********************************************/

        /*****    Set Up Players    *****/
        Player playerOne = new Player("White");
        Player playerTwo = new Player("Black");
        /********************************/

        /***** General Variables *****/
        string turn = "White";
        Button currentCell = new Button();
        Facade facade;
        /*****************************/

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                Piece whitePiece = new Piece("White");
                Piece blackPiece = new Piece("Black");
                whitePieces.Add(whitePiece);
                blackPieces.Add(blackPiece);
            }
            txtTurnOrder.Text = "Turn: " + playerOne.GetColour();
            
            facade = new Facade(this);
            facade.UseFacade(this);
        }

        private void btnCell1_Click(object sender, RoutedEventArgs e)
        {
            currentCell = btnCell1;
            Validations.IsSpaceEmpty(currentCell);
        }
        
        private void btnConsole_Click(object sender, RoutedEventArgs e)
        {
            ConsoleAllocator.ShowConsoleWindow();
        }

        private void btnCloseConsole_Click(object sender, RoutedEventArgs e)
        {
            ConsoleAllocator.HideConsoleWindow();
        }
    }
}
