using PoloniumEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace PoloniumEngine.Physics
{
    public class Raycast
    {
        public Raycast(Polonium polonium, Vector3 pos, Vector3 dir)
        {
            hits = new List<Collision>();

            foreach (GameObject gameObject in polonium.gameObjects)
            {
                Room room = null;
                if (gameObject is Room)
                {
                    room = (Room)gameObject;
                    foreach (Physicalbody body in room.bodies)
                    {
                        foreach (Collider collider in body.colliders)
                        {
                            tempdist = new Ray(pos, dir).Intersects((BoundingBox)collider.Bounder);
                            if (tempdist != null)
                            {
                                hits.Add(new Collision(collider, tempdist));
                                hit = true;
                            }
                            tempdist = new Ray(pos, dir).Intersects((BoundingSphere)collider.Bounder);
                            if (tempdist != null)
                            {
                                hits.Add(new Collision(collider, tempdist));
                                hit = true;
                            }
                        }
                    }
                }
            }
        }
        public List<Collision> hits;
        public float? tempdist;
        public bool hit;
    }
}