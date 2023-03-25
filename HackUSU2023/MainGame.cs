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


        public void pushState(GameState state)
        {
            gameStates.Push(state);
        }

        public SpriteFont MainFont
        {
            get { return mainFont; }
        }

        public SpriteFont LargerFont
        {
            get { return largerFont; }
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
            mainFont = Content.Load<SpriteFont>("fonts/RobotoNormal");
            largerFont = Content.Load<SpriteFont>("fonts/RobotoBigger");

            gameStates.Push(new MainMenu(_graphics, _spriteBatch, this));
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            var topState = gameStates.Peek();
            bool shouldPop = topState.update(gameTime);
            if (shouldPop)
            {
                gameStates.Pop();
            }

            if (gameStates.Count == 0)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            var states = gameStates.ToArray();
            for (int i = 0; i < states.Length; i++)
            {
                states[i].draw(gameTime);
                if (states[i].isFullScreen())
                {
                    break;
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}