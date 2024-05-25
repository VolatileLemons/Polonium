using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PoloniumEngine.Visuals
{
    public class Camera
    {
        public PoloniumEngine.Polonium Polonium;

        public Camera(PoloniumEngine.Polonium polonium)
        {
            Polonium = polonium;
            polonium.cameras.Add(this);
            init();
        }
        public Vector3 target;
        public Vector3 position;
        public Vector3 rotation;
        public Matrix projectionMatrix;
        public Matrix viewMatrix;
        public Matrix worldMatrix;

        public bool orbit = false;

        public void init()
        {
            position = new Vector3(0f, 0f, 0f);
            rotation = new Vector3(90f, -90f, 0f);
            target = new Vector3(target.X = position.X + (float)Math.Cos(MathHelper.ToRadians(rotation.X)), 0, target.Z = position.Z + (float)Math.Sin(MathHelper.ToRadians(rotation.X)));
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), Polonium.GraphicsDevice.DisplayMode.AspectRatio, 1f, 1000f);
            viewMatrix = Matrix.CreateLookAt(position, target, new Vector3(0f, 1f, 0f));// Y up
            worldMatrix = Matrix.CreateWorld(target, Vector3.Forward, Vector3.Up);
        }

        public void update()
        {
            if (orbit)
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1f));
                position = Vector3.Transform(position, rotationMatrix);
            }

            viewMatrix = Matrix.CreateLookAt(position, target, Vector3.Up);
        }

        public virtual void Move(Vector3 vector)
        {
            position += vector;
            target += vector;
        }

        /*public virtual void MoveRelative(Vector3 vector)
        {
            position += vector;
        }*/

        public virtual void Rotate(Vector3 vector, float reducer = 1)
        {
            rotation += vector/reducer;
            target.X = position.X + -(float)Math.Cos(MathHelper.ToRadians(rotation.X));
            target.Z = position.Z + ((float)Math.Sin(MathHelper.ToRadians(rotation.X)) * (float)Math.Sin(MathHelper.ToRadians(rotation.Y)));
            target.Y = position.Y + (float)Math.Cos(MathHelper.ToRadians(rotation.Y));
        }
    }
}