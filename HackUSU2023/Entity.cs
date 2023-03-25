using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    public abstract class Entity
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height 
        {
            get { return height; }
            set { height = value; }
        }

        public Entity() { }

    }
}
