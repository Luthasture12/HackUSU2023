using HackUSU2023.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    internal abstract class GameState
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected KeyboardHandler keyboardHandler;
        abstract public bool update(GameTime gameTime);

        abstract public void draw(GameTime gameTime);

        public GameState(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.keyboardHandler = new KeyboardHandler();
        }
    }
}
