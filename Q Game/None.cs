/* Program ID: QGame
 * 
 * Purpose: Create a functional game to demonstrate programing knowledge
 * 
 * History:
 *      created November 2020, by Stephen Draper
 */

using Q_Game.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Game
{
    /// <summary>
    /// None class. Used when the user wants to remove one of the other classes/images from the board.
    /// </summary>
    public class None : MyObject
    {
        /// <summary>
        /// Constructor. Simply sets Index to 0.
        /// </summary>
        public None()
        {
            Index = 0;
        }
    }
}
