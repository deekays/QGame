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
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Q_Game
{
    /// <summary>
    /// Wall class. Allows users to create walls on the board.
    /// </summary>
    public class Wall : MyObject
    {
        /// <summary>
        /// Constructor. Sets Index and Image. Colour not required.
        /// </summary>
        public Wall()
        {
            MyImage = Resources.wall;
            Index = 1;
        }
    }
}
