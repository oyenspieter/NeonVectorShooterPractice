using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace NeonVectorShooter
{
    class PlayerShip : Entity
    {
        private static PlayerShip instance;

        public static PlayerShip Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerShip();
                return instance;
            }
        }

        private PlayerShip()
        {
            image = Art.Player;
            position = GameRoot.ScreenSize / 2;
            radius = 10;
        }

        public override void Update()
        {
            const float speed = 8;
            velocity = speed * Input.GetMovementDirection();
            position += velocity;
            position = Vector2.Clamp(position, Size / 2, GameRoot.ScreenSize - Size / 2);

            if (velocity.LengthSquared() > 0)
                orientation = velocity.ToAngle();
        }
    }
}
