using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeonVectorShooter
{
    static class EntityManager
    {
        static List<Enitity> entities = new List<Enitity>();

        static bool isUpdating;
        static List<Enitity> addedEntities = new List<Enitity>();

        public static int Count
        {
            get { return entities.Count; }
        }

        public static void Add(Enitity entity)
        {
            if (!isUpdating)
                entities.Add(entity);
            else
                addedEntities.Add(entity);
        }

        public static void Update()
        {
            isUpdating = true;

            foreach (var entity in entities)
                entity.Update();

            isUpdating = false;

            foreach (var entity in addedEntities)
                entities.Add(entity);

            addedEntities.Clear();

            // remove any expired entities
            entities = entities.Where(x => !x.isExpired).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in entities)
                entity.Draw(spriteBatch);
        }
    }
}
