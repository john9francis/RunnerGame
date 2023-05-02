using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class GameObject
{
    // basic game object without a hitbox.
    private Texture2D _texture;
    protected Vector2 _position;

    private float _gravity = 500f;
    private float _jumpStrength = 400f;

    private float _speed;

    protected bool _hasJumped;

    // physics
    protected Vector2 _velocity;

    public GameObject()
    {
        _hasJumped = true;
<<<<<<< HEAD
        SetSpeed(200f);
=======
        _speed = 200f;
>>>>>>> main
    }

    // virtual methods:
    public abstract void Update(GameTime gameTime);

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


    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        // draw everything in the objects list
        
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

    // Movements:
    public virtual void MoveLeft(float gameTimeConstant=1)
    {
        _position.X -= _speed * gameTimeConstant;
    }
    public virtual void MoveRight(float gameTimeConstant=1)
    {
        _position.X += _speed * gameTimeConstant;
    }
    public virtual void MoveUp(float gameTimeConstant=1)
    {
        _position.Y -= _speed * gameTimeConstant;
    }
    public virtual void MoveDown(float gameTimeConstant=1)
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
