using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Obstacle : GameObject
{
    //public Obstacle() { }
    public Obstacle(Vector2 position, float hitboxWidth, float hitboxHeight, Texture2D texture)
    {
        SetPosition(position);
        SetHitBoxWidth(hitboxWidth);
        SetHitBoxHeight(hitboxHeight);
        SetTexture(texture);
    }

    public override void Update(GameTime gameTime)
    {
        float gameTimeConstant = (float)gameTime.ElapsedGameTime.TotalSeconds;

        MoveLeft(gameTimeConstant);

    }
}
