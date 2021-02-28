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
        private SpriteFont spriteFont;

        private Rectangle screenRect = new Rectangle(0, 0, 1600, 1000);

        // First Exhibit Assets
        private Texture2D first;
        private Rectangle firstButton = new Rectangle(150, 700, 200, 125);
        private Rectangle secondButton = new Rectangle(700, 700, 200, 125);
        private Rectangle thirdButton = new Rectangle(1250, 700, 200, 125);

        // Other Asset Fields
        private Texture2D titleScreen;
        private Texture2D enterButton;
        private Rectangle enterRect;
        private Texture2D tourGuide;
        private Texture2D second;
        private Texture2D third;
        private Texture2D exhibitButton;

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
            spriteFont = this.Content.Load<SpriteFont>("font");
            exhibitButton = this.Content.Load<Texture2D>("exhibit-button");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            currentKbState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            switch (currentState)
            {

                case GameState.TitleScreen:
                    if (SingleKeyPress(Keys.Enter, currentKbState)) // Press enter to start game
                    {
                        currentState = GameState.GameIntro;
                    }
                    break;


                case GameState.GameIntro: // Enter button to "enter" museum
                    if (enterRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.FirstScene;
                    }
                    break;

                case GameState.FirstScene:
                    if(firstButton.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        // call method for first slide
                    }

                    if(secondButton.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        // call method for second slide
                    }

                    if(thirdButton.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        // call method for third slide
                    }
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
            prevKbState = currentKbState;
            prevMouseState = currentMouseState;

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
                    _spriteBatch.DrawString(spriteFont, "Press enter to start!", new Vector2(0, 500), Color.Black);
                    break;

                case GameState.GameIntro:
                    _spriteBatch.Draw(titleScreen, screenRect, Color.White);
                    _spriteBatch.Draw(tourGuide, new Rectangle(20, 300, 700, 800), Color.White);
                    _spriteBatch.Draw(enterButton, enterRect, Color.White);
                    break;

                case GameState.FirstScene:
                    _spriteBatch.Draw(first, screenRect, Color.White);
                    _spriteBatch.Draw(exhibitButton, firstButton, Color.White);
                    _spriteBatch.Draw(exhibitButton, secondButton, Color.White);
                    _spriteBatch.Draw(exhibitButton, thirdButton, Color.White);
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
            mState = Mouse.GetState();
            if(mState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }

            return false;
        }
        private bool SingleKeyPress(Keys key, KeyboardState kbState)
        {
            kbState = Keyboard.GetState();
            if(kbState.IsKeyDown(key) && prevKbState.IsKeyUp(key))
            {
                return true;
            }

            return false;
        }

        private void ProcessFirstSlide()
        {

        }
        private void ProcessSecondSlide()
        {

        }
        private void ProcessThirdSlide()
        {

        }
    }
}
