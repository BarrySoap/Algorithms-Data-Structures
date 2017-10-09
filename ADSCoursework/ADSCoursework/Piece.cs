using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSCoursework
{
    class Piece
    {
        /*****   Piece Variables   *****/
        private float position;
        private float newPosition;
        private string colour;
        private bool kingship = false;
        /*******************************/

        /*****            Get Methods            *****/
        float GetPosition() { return position; }
        float GetNewPosition() { return newPosition; }
        string GetColour() { return colour; }
        bool IsPieceKing() { return kingship; }
        /*********************************************/

        /*****                  Set Methods                  *****/
        void SetPosition(float pos) { position = pos; }
        void SetNewPosition(float newPos) { newPosition = newPos; }
        void SetColour(string col) { colour = col; }
        void SetPieceAsKing(bool type) { kingship = type; }
        /*********************************************************/
    }
}
