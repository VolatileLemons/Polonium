using Microsoft.Xna.Framework;
using PoloniumEngine;
using PoloniumEngine.Visuals;
using System;
using System.Collections.Generic;
namespace PoloniumEngine.Physics
{
    public class Physicalbody : Spatial
    {
        public Physicalbody(Polonium polonium) : base(polonium)
        {
            colliders = new List<Collider>();
        }
        public Physicalbody(Polonium polonium, float bounch) : base(polonium)
        {
            colliders = new List<Collider>();
            bounce = bounch;
        }
        public Physicalbody(Polonium polonium, Mesh mech) : base(polonium)
        {
            colliders = new List<Collider>();
            mesh = mech;
        }
        public Physicalbody(Polonium polonium, float bounch, Mesh mech) : base(polonium)
        {
            colliders = new List<Collider>();
            bounce = bounch;
            mesh = mech;
        }
        public List<Collider> colliders;
        public Vector3 velocity = Vector3.Zero;
        public float bounce;
        public Mesh mesh;

        public override void update()
        {
            base.update();

            foreach (Collider collider in colliders)
            {

            }

            Move(velocity);
        }
    }
}