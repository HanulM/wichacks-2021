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
        FirstSlide,
        SecondSlide,
        ThirdSlide,
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
        private Texture2D firstSlide;
        private Texture2D secondSlide;
        private Texture2D thirdSlide;

        // Other Asset Fields
        private Texture2D titleScreen;
        private Texture2D enterButton;
        private Rectangle enterRect;
        private Texture2D tourGuide;
        private Texture2D second;
        private Texture2D third;
        private Texture2D exhibitButton;
        private Texture2D backButton;
        private Rectangle backRect;
        private Texture2D nextButton;
        private Rectangle nextRect;

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
            // Misc. Buttons
            backRect = new Rectangle(1400, 850, 100, 100);
            nextRect = new Rectangle(1400, 850, 100, 100);
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
            firstSlide = this.Content.Load<Texture2D>("slide1");
            secondSlide = this.Content.Load<Texture2D>("slide2");
            backButton = this.Content.Load<Texture2D>("back-button");
            nextButton = this.Content.Load<Texture2D>("right");
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
                    if (firstButton.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.FirstSlide;
                    }

                    if (secondButton.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.SecondSlide;
                    }

                    if (thirdButton.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.ThirdSlide;
                    }

                    if(nextRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.SecondScene;
                    }
                    break;

                case GameState.FirstSlide:
                    if(backRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.FirstScene;
                    }
                    break;

                case GameState.SecondSlide:
                    if (backRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.FirstScene;
                    }
                    break;

                case GameState.ThirdSlide:
                    if (backRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.FirstScene;
                    }
                    break;

                case GameState.SecondScene:
                    if (nextRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.ThirdScene;
                    }
                    break;

                case GameState.ThirdScene:
                    if (nextRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.EndScreen;
                    }
                    break;

                case GameState.EndScreen:
                    if (nextRect.Contains(currentMouseState.X, currentMouseState.Y) && SingleMousePress(currentMouseState))
                    {
                        currentState = GameState.Credits;
                    }
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
            GraphicsDevice.Clear(Color.SkyBlue);

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
                    _spriteBatch.Draw(nextButton, nextRect, Color.White);
                    break;

                case GameState.FirstSlide:
                    _spriteBatch.Draw(firstSlide, screenRect, Color.White);
                    _spriteBatch.Draw(backButton, backRect, Color.White);
                    break;

                case GameState.SecondSlide:
                    _spriteBatch.Draw(secondSlide, screenRect, Color.White);
                    _spriteBatch.Draw(backButton, backRect, Color.White);
                    break;

                case GameState.ThirdSlide:
                    _spriteBatch.DrawString(spriteFont, "Display coming soon!", new Vector2(750, 400), Color.Black);
                    _spriteBatch.Draw(backButton, backRect, Color.White);
                    break;

                case GameState.SecondScene:
                    _spriteBatch.DrawString(spriteFont, "Exhibit under construction!", new Vector2(750, 400), Color.Black);
                    _spriteBatch.Draw(nextButton, nextRect, Color.White);
                    break;

                case GameState.ThirdScene:
                    _spriteBatch.DrawString(spriteFont, "Exhibit under construction!", new Vector2(750, 400), Color.Black);
                    _spriteBatch.Draw(nextButton, nextRect, Color.White);
                    break;

                case GameState.EndScreen:
                    _spriteBatch.Draw(titleScreen, screenRect, Color.White);
                    _spriteBatch.Draw(tourGuide, new Rectangle(20, 300, 700, 800), Color.White);
                    _spriteBatch.DrawString(spriteFont, "Thanks for coming!", new Vector2(0, 500), Color.Black);
                    _spriteBatch.Draw(nextButton, nextRect, Color.White);
                    break;

                case GameState.Credits:
                    _spriteBatch.DrawString(spriteFont, "Back and next button icons were created by Freepik.", new Vector2(100, 500), Color.Black);
                    _spriteBatch.DrawString(spriteFont, "Press escape to exit.", new Vector2(100, 300), Color.Black);
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private bool SingleMousePress(MouseState mState)
        {
            mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }

            return false;
        }
        private bool SingleKeyPress(Keys key, KeyboardState kbState)
        {
            kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(key) && prevKbState.IsKeyUp(key))
            {
                return true;
            }

            return false;
        }
    }
}
