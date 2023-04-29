using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Obstacle : RectangleObject
{
    
	public Obstacle()
	{
        
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

    
}
