using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSCoursework
{
    class Player
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
