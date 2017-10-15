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

    class SetInitialPieces
    {
        public void SetPieces(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            int a = 0;
            int b = 41;

            for (int i = 0; i < 12; i++)
            {
                blackPieces[i].SetPosition(a.ToString());
                whitePieces[i].SetPosition(b.ToString());
                a += 2;
                b += 2;

                if (a == 8)
                {
                    a = 9;
                } else if (a == 17)
                {
                    a = 16;
                }

                if (b == 49)
                {
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
        public void MovePiece(MainWindow main, Piece currentPiece)
        {
            
        }
    }

    public class Facade
    {
        ButtonCleaning cleaner;
        SetInitialPieces setPieces;
        TurnOrder turn;

        public Facade(MainWindow main)
        {
            cleaner = new ButtonCleaning();
            turn = new TurnOrder();
            setPieces = new SetInitialPieces();
        }

        public void InitialFacade(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces)
        {
            cleaner.CleanButtons(main);
            setPieces.SetPieces(main, whitePieces, blackPieces);
        }

        public void UseFacade(MainWindow main, Piece currentPiece)
        {
            turn.MovePiece(main, currentPiece);
        }
    }
}
