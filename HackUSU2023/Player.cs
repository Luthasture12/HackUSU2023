using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    public class Player : Entity
    {
        private Vector2 position;
        private Vector2 direction;

        private int velocity;

        public Player() 
        { 
            width = 64; 
            height = 64;
            x = 400;
            y = 400;
            velocity = 2;
        }

        public void moveYUp(GameTime gameTime)
        {
            y -= (int)(velocity * gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        public void moveYDown(GameTime gameTime)
        {
            y += (int)(velocity * gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        public void moveXUp(GameTime gameTime)
        {
            x += (int)(velocity * gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        public void moveXDown(GameTime gameTime)
        {
            x -= (int)(velocity * gameTime.ElapsedGameTime.TotalMilliseconds);
        }
    }
}
