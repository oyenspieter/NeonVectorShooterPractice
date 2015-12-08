using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeonVectorShooter
{
    class PlayerShip : Enitity
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
            image = Art.player;
            position = GameRoot.ScreenSize / 2;
            radius = 10;
        }

        public override void Update()
        {
            // ship logic
        }
    }
}
