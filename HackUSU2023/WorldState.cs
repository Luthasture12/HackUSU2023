using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    internal class WorldState : GameState
    {
        public override void draw(GameTime gameTime)
        {
            spriteBatch.DrawString(mainGame.MainFont, "World", new Vector2(100, 100), Color.White);

            spriteBatch.Draw(mainGame.main_sprite_sheet, new Vector2(200, 200), Color.White);
        }

        public override bool update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return true;
            }
            return false;
        }

        public WorldState(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, MainGame mainGame) : base(graphics, spriteBatch, mainGame)
        {
            
        }
    }
}
