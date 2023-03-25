using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackUSU2023
{
    internal class MainMenu : GameState
    {
        private int position = 0;
        private String[] menuOptions = new string[] {"New Game", "Credits", "Exit" };
        private bool shouldExit = false;


        public MainMenu(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, MainGame mainGame) : base(graphics, spriteBatch, mainGame) 
        {
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Microsoft.Xna.Framework.Input.Keys.W, moveMenuUp, true));
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Microsoft.Xna.Framework.Input.Keys.S, moveMenuDown, true));
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Microsoft.Xna.Framework.Input.Keys.Enter, selectMenuOption, true));

        }

        public override void draw(GameTime gameTime)
        {
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Vector2 stringPosition = new Vector2 (900, 200 * (i + 1));
                Color textColor = Color.White;
                if (i == position)
                {
                    textColor = Color.Blue;
                }
                spriteBatch.DrawString(mainGame.MainFont, menuOptions[i], stringPosition, textColor);

            }
        }

        public override bool update(GameTime gameTime)
        {
            keyboardHandler.update(gameTime);
            return shouldExit;
        }

        private void moveMenuDown(GameTime gameTime) 
        {
            if (position == menuOptions.Length - 1)
            {
                position = 0;
            }
            
            else
            {
                position++;
            }
        }
        
        private void moveMenuUp(GameTime gameTime)
        {
            if (position == 0)
            {
                position = menuOptions.Length - 1;
            }

            else 
            {
                position--;
            }
        }

        private void selectMenuOption(GameTime gameTime)
        {
            if (position == 0)
            {
                mainGame.pushState(new WorldState(graphics, spriteBatch, mainGame));
            }
            else if (position == 1)
            {
               mainGame.pushState(new Credits(graphics, spriteBatch, mainGame));
            }
            else
            {
                shouldExit = true;
            }
        }
    }
}
