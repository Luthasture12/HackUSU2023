using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace HackUSU2023
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private Dictionary<int, Texture2D> textures;
        //private Dictionary<int, Song> songs;

        public static int screenWidth = 1920;
        public static int screenHeight = 1080;

        private SpriteFont mainFont;
        private SpriteFont largerFont;

        private Stack<GameState> gameStates;

        public Texture2D skin;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;


            _graphics.ApplyChanges();

            gameStates = new Stack<GameState>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            skin = Content.Load<Texture2D>("images/Main_test");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            //_spriteBatch.Draw(skin, new Rectangle(100, 100, 64, 64), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}