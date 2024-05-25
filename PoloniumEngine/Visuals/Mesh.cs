using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PoloniumEngine.Physics;

namespace PoloniumEngine.Visuals
{
    public class Mesh : Spatial
    {
        public Mesh(PoloniumEngine.Polonium polonium, Model Model) : base(polonium)
        {
            model = Model;
        }

        public Mesh(PoloniumEngine.Polonium polonium, Model Model, Vector3 pos, Vector3 rot, Vector3 scal) : base(polonium, pos, rot, scal)
        {
            model = Model;
        }

        public Mesh(PoloniumEngine.Polonium polonium, Model Model, Vector3 pos, Vector3 rot) : base(polonium, pos, rot)
        {
            model = Model;
        }

        public Mesh(PoloniumEngine.Polonium polonium, Model Model, Vector3 pos) : base(polonium, pos)
        {
            model = Model;
        }

        public Model model;

        public override void draw(Camera camera)
        {
            base.draw();
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    //effect.EnableDefaultLighting();
                    effect.AmbientLightColor = new Vector3(1f, 0, 0);
                    effect.View = camera.viewMatrix;
                    effect.World = Matrix.CreateWorld(position, Vector3.Forward, Vector3.Up) * Matrix.CreateFromQuaternion(Quaternion.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z)); //* camera.worldMatrix;
                    effect.Projection = camera.projectionMatrix;
                }
                mesh.Draw();
            }

        }
    }

    public class Shapes
    {
        public Model Cube;
        public Model Sphere;
    }
}
