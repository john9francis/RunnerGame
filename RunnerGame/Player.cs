using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;


public class Player : GameObject
{

    public Player()
    {

    }

    public override void Update(GameTime gameTime)
    {
        float gameTimeConstant = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // only apply gravity if the player is in the air jumping. 
        if (_hasJumped)
        {
            ApplyPhysics(gameTimeConstant);
        }

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
        if (kstate.IsKeyDown(Keys.Space))
        {
            Jump(gameTimeConstant);
        }
    }




}
