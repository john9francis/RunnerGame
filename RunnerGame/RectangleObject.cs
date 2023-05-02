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
    protected int _hitboxWidth = 60;
    protected int _hitboxHeight = 60;

    public RectangleObject()
	{
        
        
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

    // we need to move the rectangle hitbox as the texture moves.
    public override void MoveUp(float gameTimeConstant)
    {
        base.MoveUp(gameTimeConstant);
        SetHitbox(_hitboxWidth, _hitboxHeight);
    }

    public override void MoveDown(float gameTimeConstant)
    {
        base.MoveDown(gameTimeConstant);
        SetHitbox(_hitboxWidth, _hitboxHeight);

    }

    public override void MoveLeft(float gameTimeConstant)
    {
        base.MoveLeft(gameTimeConstant);
        SetHitbox(_hitboxWidth, _hitboxHeight);

    }

    public override void MoveRight(float gameTimeConstant)
    {
        base.MoveRight(gameTimeConstant);
        SetHitbox(_hitboxWidth, _hitboxHeight);

    }


    public void KeepOnScreen(float backBufferWidth, float backBufferHeight)
    {
        if (_position.X < _hitboxRectangle.Width / 2)
        {
            _position.X = _hitboxRectangle.Width / 2;
        }
        if (_position.X > backBufferWidth - _hitboxRectangle.Width / 2)
        {
            _position.X = backBufferWidth - _hitboxRectangle.Width / 2;
        }
        if (_position.Y < _hitboxRectangle.Height / 2)
        {
            _position.Y = _hitboxRectangle.Height / 2;
        }
        if (_position.Y > backBufferHeight - _hitboxRectangle.Height / 2)
        {
            _position.Y = backBufferHeight - _hitboxRectangle.Height / 2;
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
