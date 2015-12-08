using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeonVectorShooter
{
    abstract class Enitity
    {
        protected Texture2D image;
        // The tint of the image. This allows us to chagne the transparancy
        protected Color color = Color.White;

        public Vector2 position, velocity;
        public float orientation;
        public float radius;
        public bool isExpired;

        
    }
}
