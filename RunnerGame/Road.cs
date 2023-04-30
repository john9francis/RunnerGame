using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq.Expressions;


public class Road : RectangleObject
{
	public Road()
	{
        // generating the hitboxRectangle
        SetHitbox(_hitboxWidth, _hitboxHeight);
    }
}
