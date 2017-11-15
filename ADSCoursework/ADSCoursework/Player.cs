/* Author: Glenn Wilkie-Sullivan (40208762)
 * Class Purpose: Contains logic for players.
 * Date last modified: 15/11/2017
 */

namespace ADSCoursework
{
    public class Player
    {
        public Player(string col)
        {
            colour = col;
        }

        /***** Player Variables *****/
        private string colour;
        /****************************/

        /*****           Get Methods          *****/
        public string GetColour() { return colour; }
        /******************************************/

        /*****             Set Methods               *****/
        public void SetColour(string col) { colour = col; }
        /*************************************************/
    }
}
