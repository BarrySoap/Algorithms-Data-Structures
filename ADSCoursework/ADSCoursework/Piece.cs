using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSCoursework
{
    public class Piece
    {
        public Piece()
        {
            
        }

        /*****   Piece Variables   *****/
        private int position;
        private int newPosition;
        private string colour;
        private bool kingship = false;
        private bool isPieceOnEdge = false;
        private bool isTaken = false;
        /*******************************/

        /*****            Get Methods            *****/
        public int GetPosition() { return position; }
        public int GetNewPosition() { return newPosition; }
        public string GetColour() { return colour; }
        public bool IsPieceKing() { return kingship; }
        public bool GetEdge() { return isPieceOnEdge; }
        public bool Taken() { return isTaken; }
        /*********************************************/

        /*****                 Set Methods                   *****/
        public void SetPosition(int pos) { position = pos; }
        public void SetNewPosition(int newPos) { newPosition = newPos; }
        public void SetColour(string col) { colour = col; }
        public void SetPieceAsKing(bool type) { kingship = type; }
        public void SetEdge(bool edge) { isPieceOnEdge = edge; }
        public void SetTaken(bool take) { isTaken = take; }
        /*********************************************************/
    }
}
