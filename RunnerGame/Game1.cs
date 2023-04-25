using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunnerGame
{
    public class Game1 : Game
    {
        Texture2D playerTexture;
        Vector2 playerPosition;
        Texture2D roadTexture;
        Vector2 roadPosition;

        float playerSpeed;

        // monogame stuff
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            // monogame stuff
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 2);
            roadPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 5);

            playerSpeed = 100;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerTexture = Content.Load<Texture2D>("punk1");
            roadTexture = Content.Load<Texture2D>("road");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            // user key input: moves the ball at a constant speed no matter the framerate
            if (kstate.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {   
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // make sure the player doesn't go off the screen
            if (playerPosition.X > _graphics.PreferredBackBufferWidth - playerTexture.Width / 2)
            {
                playerPosition.X = _graphics.PreferredBackBufferWidth - playerTexture.Width / 2;
            }
            else if (playerPosition.X < playerTexture.Width / 2)
            {
                playerPosition.X = playerTexture.Width / 2;
            }

            if (playerPosition.Y > _graphics.PreferredBackBufferHeight - playerTexture.Height / 2)
            {
                playerPosition.Y = _graphics.PreferredBackBufferHeight - playerTexture.Height / 2;
            }
            else if (playerPosition.Y < playerTexture.Height / 2)
            {
                playerPosition.Y = playerTexture.Height / 2;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            // draw player
            _spriteBatch.Draw(
                playerTexture,
                playerPosition,
                null,
                Color.White,
                0f,
                new Vector2(playerTexture.Width / 2, playerTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
            // draw road
            _spriteBatch.Draw(
                roadTexture,
                roadPosition,
                null,
                Color.White,
                0f,
                new Vector2(playerTexture.Width / 2, playerTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}