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
        Button[] buttonList = new Button[64];

        public void CleanButtons(MainWindow main)
        {
            for (int i = 0; i < 64; i++)
            {
                buttonList[i] = (Button)main.FindName("btnCell" + i);
                buttonList[i].Background = Brushes.Gray;
            }

            for (int i = 0; i < 64; i++)
            {
                // Set White Pieces //
                if (i % 2 == 0 && i < 8)
                {
                    buttonList[i].Background = Brushes.Black;
                } else if (i % 2 == 1 && i > 8 && i < 16)
                {
                    buttonList[i].Background = Brushes.Black;
                } else if (i % 2 == 0 && i > 15 && i < 23)
                {
                    buttonList[i].Background = Brushes.Black;
                }
                /*******************************************/

                // Set Black Pieces //
                if (i % 2 == 1 && i > 40 && i < 48)
                {
                    buttonList[i].Background = Brushes.White;
                } else if (i % 2 == 0 && i > 47 && i < 56)
                {
                    buttonList[i].Background = Brushes.White;
                } else if (i % 2 == 1 && i > 55 && i < 64)
                {
                    buttonList[i].Background = Brushes.White;
                }
            }
        }
    }

    class TurnOrder
    {
        public void MovePiece(MainWindow main, Piece currentPiece)
        {
            
        }
    }

    public class Facade
    {
        ButtonCleaning cleaner;
        TurnOrder turn;

        public Facade(MainWindow main)
        {
            cleaner = new ButtonCleaning();
            turn = new TurnOrder();
        }

        public void InitialFacade(MainWindow main)
        {
            cleaner.CleanButtons(main);
        }

        public void UseFacade(MainWindow main, Piece currentPiece)
        {
            turn.MovePiece(main, currentPiece);
        }
    }
}
