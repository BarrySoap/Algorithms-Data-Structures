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

        public void SetBackgrounds()
        {
            /***** Set Initial Black Pieces *****/
            btnCell1.Background = Brushes.Black;
            btnCell3.Background = Brushes.Black;
            btnCell5.Background = Brushes.Black;
            btnCell7.Background = Brushes.Black;
            btnCell10.Background = Brushes.Black;
            btnCell12.Background = Brushes.Black;
            btnCell14.Background = Brushes.Black;
            btnCell16.Background = Brushes.Black;
            btnCell17.Background = Brushes.Black;
            btnCell19.Background = Brushes.Black;
            btnCell21.Background = Brushes.Black;
            btnCell23.Background = Brushes.Black;
            /************************************/

            /***** Set Initial White Pieces *****/
            btnCell42.Background = Brushes.White;
            btnCell44.Background = Brushes.White;
            btnCell46.Background = Brushes.White;
            btnCell48.Background = Brushes.White;
            btnCell49.Background = Brushes.White;
            btnCell51.Background = Brushes.White;
            btnCell53.Background = Brushes.White;
            btnCell55.Background = Brushes.White;
            btnCell58.Background = Brushes.White;
            btnCell60.Background = Brushes.White;
            btnCell62.Background = Brushes.White;
            btnCell64.Background = Brushes.White;
            /************************************/
        }

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
            SetBackgrounds();
        }

        private void btnCell1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCell2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnCell3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell14_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell15_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell16_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell17_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell18_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell19_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell20_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell21_Click(object sender, RoutedEventArgs e)
        {
                
        }

        private void btnCell22_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell23_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell24_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell25_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell26_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell27_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell28_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell29_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell30_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell31_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell32_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell33_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell34_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell35_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell36_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell37_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell38_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell39_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell40_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell41_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell42_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell43_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell44_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell45_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell46_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell47_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell48_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell49_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell50_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell51_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell52_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell53_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell54_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell55_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell56_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell57_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell58_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell59_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell60_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell61_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell62_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell63_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCell64_Click(object sender, RoutedEventArgs e)
        {

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
