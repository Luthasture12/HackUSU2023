using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    internal class DialogueMenu : GameState
    {
        private String dialogue;
        public DialogueMenu(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, MainGame mainGame, String dialogue) : base(graphics, spriteBatch, mainGame)
        {
            this.dialogue = dialogue;
        }
        
        

        public override void draw(GameTime gameTime)
        {

            Vector2 size = mainGame.MainFont.MeasureString(dialogue);
            if (size.X > graphics.PreferredBackBufferWidth - 15)
            {

            }
            Rectangle textBox = new Rectangle(1080 - ((int) size.X + 15), 15, (int) size.X, (int) size.Y);

            spriteBatch.Draw(mainGame.textBoxFiller, textBox, Color.White);
            spriteBatch.DrawString(mainGame.MainFont, dialogue, size, Color.Black);

        }

        public override bool update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
