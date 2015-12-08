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
        public float radius = 20; // used for circular collision detection
        public bool isExpired; // true if the entity is destroyed and should be deleted 

        public Vector2 Size
        {
            get
            {
                return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height); 
            }
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, null, color, orientation, Size / 2f, 1f, 0, 0);
        }
    }
}
