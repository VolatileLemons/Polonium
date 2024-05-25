using PoloniumEngine;
using System;
using Microsoft.Xna.Framework;

namespace PoloniumEngine.Physics
{
    public class Spatial : GameObject
    {
        public Spatial(Polonium polonium) : base(polonium)
        {

        }

        public Spatial(Polonium polonium, Vector3 pos, Vector3 rot, Vector3 scal) : base(polonium)
        {
            position = pos;
            scale = scal;
            rotation = rot;
        }

        public Spatial(Polonium polonium, Vector3 pos, Vector3 rot) : base(polonium)
        {
            position = pos;
            rotation = rot;
        }

        public Spatial(Polonium polonium, Vector3 pos) : base(polonium)
        {
            position = pos;
        }

        public Vector3 position = Vector3.Zero;
        public Vector3 scale = Vector3.One;
        public Vector3 rotation = Vector3.Zero;

        public virtual void Move(Vector3 vector)
        {
            position += vector;
        }

        public virtual void Rotate(Vector3 vector)
        {
            rotation += vector;
        }

        public virtual void Debug()
        {
            System.Diagnostics.Debug.WriteLine(this);
        }
    }
}