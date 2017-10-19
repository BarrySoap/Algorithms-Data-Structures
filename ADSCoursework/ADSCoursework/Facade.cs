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
        public void CleanButtons(MainWindow main, Button[] buttonList)
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
        public void MovePiece(MainWindow main, Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList)
        {
            switch (turnOrder)
            {
                case 0:
                    if (Validations.IsSpaceEmpty(currentCell) == false)
                    {
                        currentPiece.SetPosition(currentCell.Name.ToString().Substring(7));
                        turnOrder++;
                    } else
                    {
                        MessageBox.Show("Please select a piece!");
                    }
                    break;
                case 1:
                    if (currentCell.Name.ToString().Substring(7) != currentPiece.GetPosition())
                    {
                        if (Validations.IsSpaceEmpty(currentCell) == true)
                        {
                            currentPiece.SetNewPosition(currentCell.Name.ToString().Substring(7));
                            buttonList.ElementAt(Convert.ToInt32(currentPiece.GetPosition())).Background = Brushes.Gray;
                            if (currentPiece.GetColour() == "White")
                            {
                                buttonList.ElementAt(Convert.ToInt32(currentPiece.GetNewPosition())).Background = Brushes.White;
                            }
                            else
                            {
                                buttonList.ElementAt(Convert.ToInt32(currentPiece.GetNewPosition())).Background = Brushes.Black;
                            }
                            turnOrder--;
                            break;
                        } else
                        {
                            MessageBox.Show("Please move the piece to an empty space!");
                            break;
                        }
                    } else
                    {
                        MessageBox.Show("You can't move a piece to the same place!");
                        break;
                    }
            }
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

        public void InitialFacade(MainWindow main, List<Piece> whitePieces, List<Piece> blackPieces, Button[] buttonList)
        {
            cleaner.CleanButtons(main, buttonList);
            setPieces.SetPieces(main, whitePieces, blackPieces);
        }

        public void UseFacade(MainWindow main, Piece currentPiece, ref int turnOrder, Button currentCell, Button[] buttonList)
        {
            turn.MovePiece(main, currentPiece, ref turnOrder, currentCell, buttonList);
        }
    }
}
