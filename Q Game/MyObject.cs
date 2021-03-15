using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Game
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MyObject
    {
        private Image myImage;
        private int index;
        public int Index { get => index; set => index = value; }
        public Image MyImage { get => myImage; set => myImage = value; }

        public enum ObjColor
        {
            Red,
            Green,
        }

        public int returnIndex()
        {
            return index;
        }
    }
}