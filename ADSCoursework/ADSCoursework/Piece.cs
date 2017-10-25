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
        private string position;
        private string newPosition;
        private string colour;
        private bool kingship = false;
        private bool isPieceOnEdge = false;
        /*******************************/

        /*****            Get Methods            *****/
        public string GetPosition() { return position; }
        public string GetNewPosition() { return newPosition; }
        public string GetColour() { return colour; }
        public bool IsPieceKing() { return kingship; }
        public bool GetEdge() { return isPieceOnEdge; }
        /*********************************************/

        /*****                 Set Methods                   *****/
        public void SetPosition(string pos) { position = pos; }
        public void SetNewPosition(string newPos) { newPosition = newPos; }
        public void SetColour(string col) { colour = col; }
        public void SetPieceAsKing(bool type) { kingship = type; }
        public void SetEdge(bool edge) { isPieceOnEdge = edge; }
        /*********************************************************/
    }
}
