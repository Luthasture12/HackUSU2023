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
        private Player player;
        private Villager villager;
        public override void draw(GameTime gameTime)
        {
            spriteBatch.DrawString(mainGame.MainFont, "World", new Vector2(100, 100), Color.White);

            spriteBatch.Draw(mainGame.main_sprite_sheet, new Rectangle(player.X, player.Y, 64, 64), Color.White);

            spriteBatch.Draw(mainGame.m_karol_sprite_sheet, new Rectangle(villager.X, villager.Y, 64, 64), Color.White);
        }

        public override bool update(GameTime gameTime)
        {
            keyboardHandler.update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return true;
            }
            return false;
        }

        public WorldState(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, MainGame mainGame) : base(graphics, spriteBatch, mainGame)
        {
            player = new Player();
            villager = new Villager();
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Keys.W, player.moveYUp, false));
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Keys.S, player.moveYDown, false));
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Keys.A, player.moveXDown, false));
            keyboardHandler.addEntry(new Content.KeyboardHandler.KeyEntry(Keys.D, player.moveXUp, false));
        }
    }
}
