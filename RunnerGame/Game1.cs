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
        GameObject test;

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
            player = new Player();
            road = new GameObject();
            test = new GameObject();
            objects = new List<GameObject> {player,road,test};
            
            // player settings
            player.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 2));
            player.SetSpeed(200f);
            player.SetHitBoxHeight(200);
            player.SetHitBoxWidth(50);

            // road settings
            road.SetPosition(new Vector2(0,
                _graphics.PreferredBackBufferHeight));
            road.SetHitBoxHeight(250);
            road.SetHitBoxWidth(10000);

            // test
            test.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth*3 / 4,
                _graphics.PreferredBackBufferHeight / 2));
            test.SetHitBoxHeight(200);
            test.SetHitBoxWidth(50);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.SetTexture(Content.Load<Texture2D>("punk1"));
            road.SetTexture(Content.Load<Texture2D>("longRoad"));

            test.SetTexture(Content.Load<Texture2D>("punk1"));

        }

        protected override void Update(GameTime gameTime)
        {
            // exit if escape is pressed
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

            // keep the player on the screen
            player.KeepOnScreen(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            // make sure the player doesn't go through road
            player.DontGoThrough(road);
            player.DontGoThrough(test);


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