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
    class Operations
    {
        public static bool EdgeOperation(Piece currentPiece, List<Piece> pieces, int position)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (Convert.ToInt32(pieces[i].GetNewPosition()) == position)
                {
                    if (pieces[i].GetEdge() == true)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static bool FactionCheck(Button[] buttonList, int oldPosition, int newPosition)
        {
            if (oldPosition - newPosition == 14)
            {
                if (buttonList[newPosition + 7].Background == Brushes.Black)
                {
                    return true;
                }
            }
            if (oldPosition - newPosition == 18)
            {
                if (buttonList[newPosition + 9].Background == Brushes.Black)
                {
                    return true;
                }
            }
            if (oldPosition - newPosition == -14)
            {
                if (buttonList[newPosition - 7].Background == Brushes.White)
                {
                    return true;
                }
            }
            if (oldPosition - newPosition == -18)
            {
                if (buttonList[newPosition - 9].Background == Brushes.White)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
