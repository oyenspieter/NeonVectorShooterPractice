using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeonVectorShooter
{
    class Bullet : Entity
    {
        public Bullet (Vector2 position, Vector2 velocity)
        {
            image = Art.Bullet;
            this.position = position;
            this.velocity = velocity;
            orientation = velocity.ToAngle();
            radius = 8;
        }

        public override void Update()
        {
            if (velocity.LengthSquared() > 0)
                orientation = velocity.ToAngle();

            position += velocity;

            if (!GameRoot.Viewport.Bounds.Contains(position.ToPoint()))
                isExpired = true;
        }
    }
}
