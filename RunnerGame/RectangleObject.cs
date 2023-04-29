using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class RectangleObject : GameObject
{
    // this object is going to use rectangles for the hitbox. 
    private Rectangle _hitboxRectangle;

    public RectangleObject()
	{
        // generating the hitboxRectangle
        SetHitbox(60,60);
        
    }

    public void SetHitbox(int width, int height, int x=0, int y=0) 
    {
        if (x == 0)
        {
            x = (int)GetPosition().X - width;
        }
        if (y == 0)
        {
            y = (int)GetPosition().Y - height;
        }
        _hitboxRectangle = new Rectangle(x, y, width, height);
    }

    public override Rectangle GetHitbox() 
    { 
        return _hitboxRectangle; 
    }

    public void KeepOnScreen(float backBufferWidth, float backBufferHeight)
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
        if (_position.Y < _hitboxRectangle.Height / 2)
        {
            _position.Y = _hitboxRectangle.Height / 2;
        }
        //if (_hitboxRectangle.Bottom > backBufferHeight)
        if (_position.Y > backBufferHeight - _hitboxRectangle.Height / 2)
        {
            _position.Y = backBufferHeight - _hitboxRectangle.Height / 2;
        }
    }

    public void StayOnTopOf1(GameObject otherObject)
    {
        // make sure the bottom hitbox of THIS object doesn't go through the top of the OTHER object
        if (CheckIfTouching(otherObject))
        {
            _position.Y = otherObject.GetPosition().Y - otherObject.GetHitBoxHeight() / 2 - GetHitBoxHeight() / 2;
            _hasJumped = false;
        }

    }

    public void StayOnTopOf(GameObject otherObject)
    {
        if (CheckIfTouching(otherObject))
        {
            _position.Y = otherObject.GetHitbox().Top - _hitboxRectangle.Height / 2;
            _hasJumped = false;
        }
    }

    public bool CheckIfTouching(GameObject otherObject)
    {
        if (_hitboxRectangle.Intersects(otherObject.GetHitbox()))
        {
            return true;
        }

        return false;
    }
}
