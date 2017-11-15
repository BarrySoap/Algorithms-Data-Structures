/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains all logic for pieces.
 * Date last modified: 15/11/2017
 */

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
