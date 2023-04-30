﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Player : RectangleObject
{

    public Player()
    {
        // generating the hitboxRectangle
        SetHitbox(_hitboxWidth, _hitboxHeight);
    }

    public void Update(GameTime gameTime)
    {
        float gameTimeConstant = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_hasJumped)
        {
            //ApplyPhysics(gameTimeConstant);
        }

        var kstate = Keyboard.GetState();

        // move the player when the user presses the keys
        if (kstate.IsKeyDown(Keys.Left))
        {
            MoveLeft(gameTimeConstant);
        }
        if (kstate.IsKeyDown(Keys.Right))
        {
            MoveRight(gameTimeConstant);
        }
        if (kstate.IsKeyDown(Keys.Up))
        {
            MoveUp(gameTimeConstant);
        }
        if (kstate.IsKeyDown(Keys.Down))
        {
            MoveDown(gameTimeConstant);
        }
        if (kstate.IsKeyDown(Keys.Space))
        {
            //Jump(gameTimeConstant);
        }
    }

    


}
