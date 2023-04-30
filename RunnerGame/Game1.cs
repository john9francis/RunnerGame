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
        Player player;
        Road road;
        Obstacle obstacle;
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

            // set window size:
            _graphics.PreferredBackBufferWidth = 1200;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            // create objects
            player = new Player();
            road = new Road();
            obstacle = new Obstacle();

            // player settings
            player.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 4));
            player.SetSpeed(200f);
            //player.SetHitBoxHeight(200);
            //player.SetHitBoxWidth(50);

            // road settings
            road.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight * 4 / 5));

            //road.SetHitbox((int)_graphics.PreferredBackBufferWidth, 100, 0, _graphics.PreferredBackBufferHeight *3/4);
            //road.SetHitBoxHeight(250);
            //road.SetHitBoxWidth(10000);

            // obstacle settings
            obstacle.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth * 3 / 4,
                _graphics.PreferredBackBufferHeight / 2));  

            // add all objects to the objects list
            objects = new List<GameObject>();
            objects.Add(player);
            objects.Add(obstacle);
            objects.Add(road);

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.SetTexture(Content.Load<Texture2D>("punk1"));
            obstacle.SetTexture(Content.Load<Texture2D>("obstacle (1)"));
            road.SetTexture(Content.Load<Texture2D>("longRoad"));


        }

        protected override void Update(GameTime gameTime)
        {
            // exit if escape is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            // keep the player on the screen
            player.KeepOnScreen(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            // keep obstacle on the screen
            obstacle.KeepOnScreen(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            // make sure the player doesn't go through road
            //player.StayOnTopOf(road);
            
            // update all the player stuff
            player.Update(gameTime);

            // update obstacle
            obstacle.Update(gameTime);

            // trying to get player hitting road to work:
            if (player.CheckIfTouching(obstacle))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //_spriteBatch.Begin();
            //// draw everything in the objects list
            //foreach (GameObject obj in objects)
            //{
            //    _spriteBatch.Draw(
            //        obj.GetTexture(),
            //        obj.GetPosition(),
            //        null,
            //        Color.White,
            //        0f,
            //        //new Vector2(obj.GetTexture().Width / 2, obj.GetTexture().Height / 2),
            //        new Vector2(0,0),
            //        Vector2.One,
            //        SpriteEffects.None,
            //        0f);
            //}
            //
            //_spriteBatch.End();
            
            // draw each object
            foreach (GameObject obj in objects)
            {
                obj.Draw(_spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}