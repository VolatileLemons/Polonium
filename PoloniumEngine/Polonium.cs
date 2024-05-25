using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using PoloniumEngine.Physics;
using PoloniumEngine.Visuals;

namespace PoloniumEngine
{
    public class Polonium : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //BasicEffect for rendering
        BasicEffect basicEffect;

        //Geometric info
        VertexPositionColor[] triangleVertices;
        VertexBuffer vertexBuffer;

        public List<Camera> cameras;
        public List<GameObject> gameObjects;

        public Shapes Shapes;

        public Polonium()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            cameras = new List<Camera>();
            gameObjects = new List<GameObject>();

            Shapes = new Shapes();
            new Camera(this);
            new Room(this);
            new Raycast(this, Vector3.Zero, Vector3.Zero);
            //BasicEffect
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;

            // Want to see the colors of the vertices, this needs to be on
            basicEffect.VertexColorEnabled = true;

            //Lighting requires normal information which VertexPositionColor does not have
            //If you want to use lighting and VPC you need to create a custom def
            basicEffect.LightingEnabled = false;
            
            /*
            //Geometry  - a simple triangle about the origin
            triangleVertices = new VertexPositionColor[3];
            triangleVertices[0] = new VertexPositionColor(new Vector3(0, 20, 0), Color.Red);
            triangleVertices[1] = new VertexPositionColor(new Vector3(-20, -20, 0), Color.Green);
            triangleVertices[2] = new VertexPositionColor(new Vector3(20, -20, 0), Color.Blue);
            */
            //Vert buffer
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
            //vertexBuffer.SetData<VertexPositionColor>(triangleVertices);

            new Mesh(this, Shapes.Cube);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Shapes.Cube = Content.Load<Model>("Cube");
            Shapes.Sphere = Content.Load<Model>("Sphere");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                Keys.Escape))
                Exit();

            Parallel.ForEach(cameras, Camera =>
            {
                Camera.update();
            }
            );

            Parallel.ForEach(gameObjects, GameObject =>
            {
                GameObject.update();
            }
            );

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            foreach (Camera camera in cameras)
            {
                basicEffect.Projection = camera.projectionMatrix;
                basicEffect.View = camera.viewMatrix;
                basicEffect.World = camera.worldMatrix;

                GraphicsDevice.Clear(Color.CornflowerBlue);
                GraphicsDevice.SetVertexBuffer(vertexBuffer);

                RasterizerState rasterizerState = new RasterizerState();
                rasterizerState.CullMode = CullMode.None;
                GraphicsDevice.RasterizerState = rasterizerState;

                foreach (EffectPass pass in basicEffect.CurrentTechnique. Passes)
                {
                    pass.Apply();
                    GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
                }

                foreach (GameObject gameObject in gameObjects)
                {
                    gameObject.draw(camera);
                }
            }

            base.Draw(gameTime);
        }
    }
}