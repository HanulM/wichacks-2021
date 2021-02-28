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

        private Rectangle screenRect = new Rectangle(0, 0, 1600, 1000);

        // Asset Fields
        private Texture2D titleScreen;
        private Texture2D enterButton;
        private Rectangle enterRect;
        private Texture2D tourGuide;
        private Texture2D first;
        private Texture2D second;
        private Texture2D third;

        // Object Fields
        private GameObject firstExhibit;
        private GameObject secondExhibit;
        private GameObject thirdExhibit;

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

            // Graphics
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();
            // State Initialize
            currentState = GameState.TitleScreen;
            // Title Screen
            enterRect = new Rectangle(600, 500, 430, 330);
            // First Exhibit
            firstExhibit = new Exhibit(first, screenRect);
            // Second Exhibit
            secondExhibit = new Exhibit(second, screenRect);
            // Third Exhibit
            thirdExhibit = new Exhibit(third, screenRect);
            // End Screen

            // Credits
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            titleScreen = this.Content.Load<Texture2D>("titlescreen-background");
            tourGuide = this.Content.Load<Texture2D>("tourguide");
            enterButton = this.Content.Load<Texture2D>("enter-button");
            first = this.Content.Load<Texture2D>("exhibit-1");
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
                    _spriteBatch.Draw(titleScreen, screenRect, Color.White);
                    _spriteBatch.Draw(tourGuide, new Rectangle(20, 300, 700, 800), Color.White);
                    _spriteBatch.Draw(enterButton, enterRect, Color.White);
                    break;

                case GameState.GameIntro:
                    break;

                case GameState.FirstScene:
                    firstExhibit.Draw(_spriteBatch);
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
