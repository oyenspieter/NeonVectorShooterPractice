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
        const int cooldownFrames = 6;
        int cooldownRemaining = 0;
        static Random rand = new Random();

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
            //const float speed = 8;
            const float speed = 1;

            velocity = speed * Input.GetMovementDirection();

            position += velocity;

            position = Vector2.Clamp(position, Size / 2, GameRoot.ScreenSize - Size / 2);

            if (velocity.LengthSquared() > 0)
                orientation = velocity.ToAngle();

            //shooting
            var aim = Input.GetAimDirection();
            if (aim.LengthSquared() > 0 && cooldownRemaining <= 0 && Input.WasMouseButtonPressed())
            {
                cooldownRemaining = cooldownFrames;
                float aimAngle = aim.ToAngle();
                Quaternion aimQuat = Quaternion.CreateFromYawPitchRoll(0, 0, aimAngle);

                float randomSpread = rand.NextFloat(-0.04f, 0.04f) + rand.NextFloat(-0.04f, 0.04f);
                Vector2 vel = MathUtil.FromPolar(aimAngle + randomSpread, 11f);

                Vector2 offset = Vector2.Transform(new Vector2(25, -8), aimQuat);
                EntityManager.Add(new Bullet(position + offset, vel));

                offset = Vector2.Transform(new Vector2(25, 8), aimQuat);
                EntityManager.Add(new Bullet(position + offset, vel));

            }

            if (cooldownRemaining > 0)
                cooldownRemaining--;
        }
    }
}
