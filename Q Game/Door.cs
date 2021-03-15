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
using System.Text;
using System.Threading.Tasks;

namespace Q_Game
{
    /// <summary>
    /// The Door class, allows users to create either green or red doors
    /// </summary>
    public class Door : MyObject
    {
        private ObjColor objColor;

        /// <summary>
        /// Constructor. Requires colour, which allows us to set the picture and index properly. 
        /// </summary>
        /// <param name="color">Either red or green. ObjColor is an enum.</param>
        public Door(ObjColor color)
        {
            this.objColor = color;
            if(color == ObjColor.Red)
            {
                Index = 2;
                MyImage = Resources.redDoorSmall;
            }
            else if(color == ObjColor.Green)
            {
                Index = 3;
                MyImage = Resources.greenDoorSmall;
            }
        }
    }
}
