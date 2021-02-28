using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace wichacksSpring
{
    enum GameState
    {
        TitleScreen,
        GameIntro,
        FirstScene,
        SecondScene,
        ThirdScene,
        EndScreen,
        Credits
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState currentState;

        // Asset Fields
        private Texture2D titleScreen;
        private Texture2D enterButton;
        private Rectangle enterRect;
        private Texture2D tourGuide;

        // Object Fields
        private Exhibit firstExhibit;
        private Exhibit secondExhibit;
        private Exhibit thirdExhibit;

        // Keyboard and Mouse Input
        private KeyboardState currentKbState;
        private KeyboardState prevKbState;
        private MouseState currentMouseState;
        private MouseState prevMouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();
            currentState = GameState.TitleScreen;

            enterRect = new Rectangle(600, 500, 430, 330); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            titleScreen = this.Content.Load<Texture2D>("titlescreen-background");
            tourGuide = this.Content.Load<Texture2D>("tourguide");
            enterButton = this.Content.Load<Texture2D>("enter-button");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            currentKbState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();
            prevKbState = Keyboard.GetState();
            prevMouseState = Mouse.GetState();

            switch (currentState)
            {

                case GameState.TitleScreen:
                    if (enterRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.GameIntro;
                    }

                    currentMouseState = prevMouseState;
                    break;


                case GameState.GameIntro:
                    break;

                case GameState.FirstScene:
                    break;

                case GameState.SecondScene:
                    break;

                case GameState.ThirdScene:
                    break;

                case GameState.EndScreen:
                    break;

                case GameState.Credits:
                    break;
        }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            switch (currentState)
            {
                case GameState.TitleScreen:
                    _spriteBatch.Draw(titleScreen, new Rectangle(0, 0, 1600, 1000), Color.White);
                    _spriteBatch.Draw(tourGuide, new Rectangle(20, 300, 700, 800), Color.White);
                    _spriteBatch.Draw(enterButton, enterRect, Color.White);
                    break;

                case GameState.GameIntro:
                    break;

                case GameState.FirstScene:
                    break;

                case GameState.SecondScene:
                    break;

                case GameState.ThirdScene:
                    break;

                case GameState.EndScreen:
                    break;

                case GameState.Credits:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private bool SingleMousePress(MouseState mState)
        {
            if(mState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }

            return false;
        }
    }
}
