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
    /// Box class, allows user to create either red or green boxes
    /// </summary>
    public class Box : MyObject
    {
        private ObjColor objColor;

        /// <summary>
        /// Constructor. Requires colour, which allows us to set the picture and index properly. 
        /// </summary>
        /// <param name="color">Either red or green. ObjColor is an enum.</param>
        public Box(ObjColor color)
        {
            this.objColor = color;
            if (color == ObjColor.Red)
            {
                Index = 4;
                MyImage = Resources.redBoxSmall;
            }
            else if (color == ObjColor.Green)
            {
                Index = 5;
                MyImage = Resources.greenBoxSmall;
            }
        }
    }
}
