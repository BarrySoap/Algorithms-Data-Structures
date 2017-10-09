using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSCoursework
{
    class Piece
    {
        public Piece(string col)
        {
            colour = col;
        }

        /*****   Piece Variables   *****/
        private float position;
        private float newPosition;
        private string colour;
        private bool kingship = false;
        /*******************************/

        /*****            Get Methods            *****/
        public float GetPosition() { return position; }
        public float GetNewPosition() { return newPosition; }
        public string GetColour() { return colour; }
        public bool IsPieceKing() { return kingship; }
        /*********************************************/

        /*****                 Set Methods                   *****/
        public void SetPosition(float pos) { position = pos; }
        public void SetNewPosition(float newPos) { newPosition = newPos; }
        public void SetColour(string col) { colour = col; }
        public void SetPieceAsKing(bool type) { kingship = type; }
        /*********************************************************/
    }
}
