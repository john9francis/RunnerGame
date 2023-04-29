using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Obstacle : GameObject
{
    private Rectangle _hitboxRectangle;
	// this object is going to use rectangles for the hitbox. 
	public Obstacle()
	{
        _hitboxRectangle = new Rectangle((int)GetPosition().X,(int)GetPosition().Y,20,20);
	}

	public void Update(GameTime gameTime)
	{
        float gameTimeConstant = (float)gameTime.ElapsedGameTime.TotalSeconds;

        var kstate = Keyboard.GetState();

        // move the player when the user presses the keys
        if (kstate.IsKeyDown(Keys.A))
        {
            MoveLeft(gameTimeConstant);
        }
        if (kstate.IsKeyDown(Keys.D))
        {
            MoveRight(gameTimeConstant);
        }
        if (kstate.IsKeyDown(Keys.W))
        {
            MoveUp(gameTimeConstant);
        }
        if (kstate.IsKeyDown (Keys.S))
        {
            MoveDown(gameTimeConstant);
        }

        // make sure the hitbox rectangle follows the player.
        _hitboxRectangle.X = (int)_position.X;
        _hitboxRectangle.Y = (int)_position.Y;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(
                    GetTexture(),
                    GetPosition(),
                    null,
                    Color.White,
                    0f,
                    new Vector2(0,0),
                    Vector2.One,
                    SpriteEffects.None,
                    0f);
        spriteBatch.End();
    }

    public void KeepOnScreen1(float backBufferWidth, float backBufferHeight)
    {
        //if (_hitboxRectangle.Left < 0)
        if (_position.X < _hitboxRectangle.Width / 2)
        {
            _position.X = _hitboxRectangle.Width / 2;
        }
        //if (_hitboxRectangle.Right > backBufferWidth)
        if (_position.X > backBufferWidth - _hitboxRectangle.Width / 2)
        {
            _position.X = backBufferWidth - _hitboxRectangle.Width / 2;
        }
        // if (_hitboxRectangle.Top < 0)
        if (_position.Y < _hitboxRectangle.Height/2)
        {
            _position.Y = _hitboxRectangle.Height / 2;
        }
        //if (_hitboxRectangle.Bottom > backBufferHeight)
        if (_position.Y > backBufferHeight -  _hitboxRectangle.Height / 2)
        {
            _position.Y = backBufferHeight - _hitboxRectangle.Height / 2;
        }
    }
}
