using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;

public class Obstacle : RectangleObject
{
<<<<<<< HEAD
	//public Obstacle() { }
	public Obstacle(Vector2 position,float hitboxWidth,float hitboxHeight,Texture2D texture)
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
=======
    
	public Obstacle()
	{
        // generating the hitboxRectangle
        //SetHitbox(_hitboxWidth, _hitboxHeight);
         // for some reason if we initialize the hitbox before it moves, it crashes...
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

    
>>>>>>> main
}
