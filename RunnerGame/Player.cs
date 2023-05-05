using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;


public class Player : GameObject
{
    public Keys _jumpKey = Keys.Space;
    private Keys _leftKey = Keys.A;
    private Keys _rightKey = Keys.D;
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
        if (kstate.IsKeyDown(_leftKey))
        {
            MoveLeft(gameTimeConstant);
        }
        if (kstate.IsKeyDown(_rightKey))
        {
            MoveRight(gameTimeConstant);
        }
        if (kstate.IsKeyDown(_jumpKey))
        {
            Jump(gameTimeConstant);
        }
    }




}
