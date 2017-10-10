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
    class ButtonCleaning : MainWindow
    {
        public void cleanButtons()
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

            /***** Set Every Other Piece as Gray - This is for clarity *****/
            btnCell2.Background = Brushes.Gray;
            btnCell4.Background = Brushes.Gray;
            btnCell6.Background = Brushes.Gray;
            btnCell8.Background = Brushes.Gray;
            btnCell9.Background = Brushes.Gray;
            btnCell11.Background = Brushes.Gray;
            btnCell13.Background = Brushes.Gray;
            btnCell15.Background = Brushes.Gray;
            btnCell18.Background = Brushes.Gray;
            btnCell20.Background = Brushes.Gray;
            btnCell22.Background = Brushes.Gray;
            btnCell24.Background = Brushes.Gray;
            btnCell25.Background = Brushes.Gray;
            btnCell26.Background = Brushes.Gray;
            btnCell27.Background = Brushes.Gray;
            btnCell28.Background = Brushes.Gray;
            btnCell29.Background = Brushes.Gray;
            btnCell30.Background = Brushes.Gray;
            btnCell31.Background = Brushes.Gray;
            btnCell32.Background = Brushes.Gray;
            btnCell33.Background = Brushes.Gray;
            btnCell34.Background = Brushes.Gray;
            btnCell35.Background = Brushes.Gray;
            btnCell36.Background = Brushes.Gray;
            btnCell37.Background = Brushes.Gray;
            btnCell38.Background = Brushes.Gray;
            btnCell39.Background = Brushes.Gray;
            btnCell40.Background = Brushes.Gray;
            btnCell41.Background = Brushes.Gray;
            /***************************************************************/
        }
    }

    public class Facade
    {
        ButtonCleaning cleaner;

        public Facade()
        {
            cleaner = new ButtonCleaning();
        }

        public void CommenceFacade()
        {
            cleaner.cleanButtons();
        }
    }
}
