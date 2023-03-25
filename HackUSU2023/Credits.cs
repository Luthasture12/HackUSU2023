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
    
    internal class Credits : GameState
    {

        private int currentCredit = 0;
        private String[] creditList = new string[] { "Programming: Ian Adams and Daniel Barfuss", "Art: Amanda Barfuss" };
        public Credits(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, MainGame mainGame) : base(graphics, spriteBatch, mainGame)
        {

        }

        public override void draw(GameTime gameTime)
        {
            for (int i = 0; i < creditList.Length; i++)
            {
                Vector2 stringPosition = new Vector2(900, 200 * (i + 1));
                spriteBatch.DrawString(mainGame.MainFont, creditList[i], stringPosition, Color.Blue);

            }
        }

        public override bool update(GameTime gameTime)
        {
            return Keyboard.GetState().IsKeyDown(Keys.Escape);
           
        }
    }
}
