using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NeonVectorShooter
{
    static class Art
    {
        public static Texture2D player { get; private set; }
        public static Texture2D seeker { get; private set; }
        public static Texture2D wanderer { get; private set; }
        public static Texture2D bullet { get; private set; }
        public static Texture2D pointer { get; private set; }

        public static void Load(ContentManager content)
        {
            player = content.Load<Texture2D>("Player");
            seeker = content.Load<Texture2D>("Seeker");
            wanderer = content.Load<Texture2D>("Wanderer");
            bullet = content.Load<Texture2D>("Bullet");
            pointer = content.Load<Texture2D>("Pointer");
        }
    }
}
