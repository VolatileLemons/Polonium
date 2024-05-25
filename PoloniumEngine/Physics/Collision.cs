using System;
using System.Collections.Generic;
using System.Text;

namespace PoloniumEngine.Physics
{
    public class Collision
    {
        public Collision(Collider collider, float? distance = null)
        {
            Collider = collider;
            Distance = distance;
        }
        public Collider Collider;
        public float? Distance;
    }
}
