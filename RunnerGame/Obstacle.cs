using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Obstacle : GameObject
{
    // this object is going to use rectangles for the hitbox. 
    private Rectangle _hitboxRectangle;
	public Obstacle()
	{
        // generating the hitboxRectangle
        int width = 60;
        int height = 60;
        int x = (int)GetPosition().X - width;
        int y = (int)GetPosition().Y - height;
        _hitboxRectangle = new Rectangle(x,y,width,height);
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
                    new Vector2(GetTexture().Width/2, GetTexture().Height/2),
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
