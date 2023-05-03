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
        // test commit
        // did it merge correctly?
        Player player;
        Road road;
        //Obstacle obstacle;
        List<GameObject> objects;
        List<GameObject> movingObjects;
        List<Obstacle> obstacles;

        private float _time;
        private int _count = 2;

        Texture2D obstacleTexture;

        // test test test

        // monogame stuff
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            // monogame stuff
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // set window size:
            _graphics.PreferredBackBufferWidth = 1200;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            road = new Road();

            // player settings
            player.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 2));
            player.SetHitBoxWidth(50);
            player.SetHitBoxHeight(200);

            // road settings
            road.SetPosition(new Vector2(0,
                _graphics.PreferredBackBufferHeight * 4 / 5));
            road.SetHitBoxWidth(10000);
            road.SetHitBoxHeight(100);

            // lists of stuff
            objects = new List<GameObject> { player, road };
            movingObjects = new List<GameObject> { player };
            obstacles = new List<Obstacle>();

            _time = 1f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.SetTexture(Content.Load<Texture2D>("punk1"));
            road.SetTexture(Content.Load<Texture2D>("longRoad"));
            obstacleTexture = Content.Load<Texture2D>("obstacle (1)");


        }

        protected override void Update(GameTime gameTime)
        {
            // exit if escape is pressed
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // keep the player on the screen
            player.KeepOnScreen(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            // make sure the player doesn't go through road
            player.StayOnTopOf(road);

            // update all the moving objects
            foreach (GameObject obj in movingObjects)
            {
                obj.Update(gameTime);
            }

            foreach (Obstacle obj in obstacles)
            {
                obj.Update(gameTime);
            }

            // kill player if hits obstacle
            //if (player.CheckIfTouching(obstacle))
            //    Exit();

            // get time:
            //_time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _time++;

            // on each 2 seconds, generate obstacle:
            if (_time > _count)
            {
                //Obstacle obstacle = new Obstacle();
                //obstacle.SetPosition(new Vector2(_graphics.PreferredBackBufferWidth,
                //_graphics.PreferredBackBufferHeight * 3 / 5));
                //obstacle.SetHitBoxWidth(60);
                //obstacle.SetHitBoxHeight(60);
                //obstacle.SetTexture(obstacleTexture);

                obstacles.Add(new Obstacle(new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight * 3 / 5), 60f, 60f, obstacleTexture));

                _count += 100;
            }
            foreach (Obstacle o in obstacles)
            {
                if (player.CheckIfTouching(o))
                    Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            foreach (GameObject obj in objects)
            {
                obj.Draw(_spriteBatch);
            }
            foreach (Obstacle obj in obstacles)
            {
                obj.Draw(_spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}