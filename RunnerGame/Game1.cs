﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RunnerGame
{
    public class Game1 : Game
    {
        Player player;
        Road road;
        List<GameObject> objects;
        List<Obstacle> obstacles;

        private float _time;
        private int _count = 2;
        private Random random = new Random();
        private int randMin;
        private int randMax;

        Texture2D obstacle1Texture;

        private int windowWidth = 1200;
        private int windowHeight = 600;

        private Song _bounceSound;

        private SpriteFont _font;
        private int _score = 0;
       
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
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
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
            obstacles = new List<Obstacle>();

            // initialize time (used for obstacle generation)
            _time = 0f;

            // randoms initialized (used for obstacle gen)
            randMin = 100;
            randMax = 200;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Textures
            player.SetTexture(Content.Load<Texture2D>("punk1"));
            road.SetTexture(Content.Load<Texture2D>("longRoad"));
            obstacle1Texture = Content.Load<Texture2D>("obstacle (1)");

            // sounds
            _bounceSound = Content.Load<Song>("bounce");

            // words
            _font = Content.Load<SpriteFont>("score");
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

            // update player stuff
            player.Update(gameTime);

            // update obstacles
            foreach (Obstacle obj in obstacles)
            {
                obj.Update(gameTime);
            }

            _time++;

            // generate obstacles on semi-random intervals. 
            if (_time > _count)
            {
                // add a new obstacle and add to the count
                obstacles.Add(new Obstacle(new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight * 3 / 5), 60f, 60f, obstacle1Texture));
                int num = random.Next(randMin, randMax);
                _count += num;

                // make the generation a little quicker.
                randMin--;
                randMin--;
            }

            // kill player if obstacle hits them.
            foreach (Obstacle o in obstacles)
            {
                if (player.CheckIfTouching(o))
                    Exit();
            }

            // play bounce sound on jump
            Keyboard1.CheckKey();
            if (Keyboard1.ActivateOnce(Keys.Space))
            {
                MediaPlayer.Play(_bounceSound);
            }

            // if obstacles go off screen, earn a point.
            for (int i=0; i<obstacles.Count; i++)
            {
                if (obstacles[i].GetPosition().X < 0)
                {
                    // delete the obstacle so it doesn't take up space
                    obstacles.RemoveAt(i);
                    _score++;
                }
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

            // draw words
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Score:" + _score, new Vector2(50, 50), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}