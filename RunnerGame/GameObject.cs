using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class GameObject
{
    private Texture2D _texture;
    private Vector2 _position;
    private float _speed;

    public GameObject()
    {

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

    // todo: create colission detection.
}
