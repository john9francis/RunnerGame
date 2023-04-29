using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class GameObject
{
    private Texture2D _texture;
    protected Vector2 _position;

    private float _gravity = 500f;
    private float _jumpStrength = 400f;

    private float _speed;
    private float _hitBoxHeight;
    private float _hitBoxWidth;

    protected bool _hasJumped;

    // physics
    protected Vector2 _velocity;

    public GameObject()
    {
        _hasJumped = true;
        _speed = 200f;
    }

    // getters and setters
    public void SetTexture(Texture2D texture)
    {
        _texture = texture;
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetHitBoxHeight(float hitBoxHeight) 
    {
        _hitBoxHeight = hitBoxHeight;
    }

    public void SetHitBoxWidth(float hitBoxWidth)
    {
        _hitBoxWidth = hitBoxWidth;
    }

    public abstract Rectangle GetHitbox();

    public Texture2D GetTexture()
    {
        return _texture;
    }

    public Vector2 GetPosition()
    {
        return _position;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetHitBoxHeight()
    {
        return _hitBoxHeight;
    }

    public float GetHitBoxWidth()
    {
        return _hitBoxWidth;
    }

    // Movements:
    public void MoveLeft(float gameTimeConstant=1)
    {
        _position.X -= _speed * gameTimeConstant;
    }
    public void MoveRight(float gameTimeConstant=1)
    {
        _position.X += _speed * gameTimeConstant;
    }
    public void MoveUp(float gameTimeConstant=1)
    {
        _position.Y -= _speed * gameTimeConstant;
    }
    public void MoveDown(float gameTimeConstant=1)
    {
        _position.Y += _speed * gameTimeConstant;
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
                    new Vector2(GetTexture().Width / 2, GetTexture().Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f);
        spriteBatch.End();
    }

    public bool CheckIfTouching1(GameObject otherObject)
    {
        // returns true if the object is touching another object. 
        // define where the object hitbox is
        float top = _position.Y - _hitBoxHeight / 2;
        float bottom = _position.Y + _hitBoxHeight / 2;
        float left = _position.X - _hitBoxWidth / 2;
        float right = _position.X + _hitBoxWidth / 2;

        // define where the other object hitbox is
        float otop = otherObject.GetPosition().Y - otherObject.GetHitBoxHeight() / 2;
        float obottom = otherObject.GetPosition().Y + otherObject.GetHitBoxHeight() / 2;
        float oleft = otherObject.GetPosition().X - otherObject.GetHitBoxWidth() / 2;
        float oright = otherObject.GetPosition().X + otherObject.GetHitBoxWidth() / 2;

        // make sure the bottom hitbox of THIS object doesn't go through the top of the OTHER object
        if (bottom > otop && top < obottom)
        {
            if (right > oleft && left < oright)
            {
                return true;
            }
        }

        return false;

    }


    public void ApplyPhysics(float gameTimeConstant)
    {
        // updates position and velocity based on gravity. (uses Euler's method)
        _position.Y += _velocity.Y * gameTimeConstant;
        _velocity.Y += _gravity * gameTimeConstant;
    }

    public void Jump(float gameTimeConstant)
    {
        if (_hasJumped == false)
        {
            _position.Y -= 10f;
            _velocity.Y = -_jumpStrength;
            _hasJumped = true;
        }
    }

}
