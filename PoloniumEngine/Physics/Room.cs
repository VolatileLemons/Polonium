using PoloniumEngine;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PoloniumEngine.Physics
{
    public class Room : GameObject
    {
        public Room(Polonium polonium) : base(polonium, "room0")
        {
            bodies = new List<Physicalbody>();
        }
        public List<Physicalbody> bodies;

        public override void update()
        {
            base.update();
        }
    }
}