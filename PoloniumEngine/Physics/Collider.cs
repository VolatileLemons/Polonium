using PoloniumEngine;
using System;
using Microsoft.Xna.Framework;

namespace PoloniumEngine.Physics
{
    public class Collider : Spatial
    {
        public Collider(Polonium polonium, BoundingBox bounder) : base(polonium)
        {
            Bounder = bounder;
        }
        public Collider(Polonium polonium, BoundingSphere bounder) : base(polonium)
        {
            Bounder = bounder;
        }
        public Object Bounder;
    }
}