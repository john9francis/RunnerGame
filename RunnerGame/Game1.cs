using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RunnerGame
{
    public class Game1 : Game
    {
        GameObject player;
        GameObject road;

        List<GameObject> objects;

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
            player = new GameObject();
            road = new GameObject();
            objects = new List<GameObject> {player,road};
            
            player.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 2));
            player.SetSpeed(200f);

            road.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 5));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.SetTexture(Content.Load<Texture2D>("punk1"));
            road.SetTexture(Content.Load<Texture2D>("road"));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            // move the player when the user presses the keys
            float gameTimeConstant = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.Up))
            {
                player.MoveUp(gameTimeConstant);
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                player.MoveDown(gameTimeConstant);
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                player.MoveLeft(gameTimeConstant);
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                player.MoveRight(gameTimeConstant);
            }

            /*

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
            */


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            // draw everything in the objects list
            foreach (GameObject obj in objects)
            {
                _spriteBatch.Draw(
                    obj.GetTexture(),
                    obj.GetPosition(),
                    null,
                    Color.White,
                    0f,
                    new Vector2(player.GetTexture().Width / 2, player.GetTexture().Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f);
            }
            
            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}