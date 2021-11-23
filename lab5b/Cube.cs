using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab5b {

    public class Cube {

        private Matrix worldTranslation = Matrix.Identity;
        private Matrix worldRotation = Matrix.Identity;
        private VertexPositionColor[] vertices;
        private VertexPositionColor[] axisLines;
        private BasicEffect effect;

        public Cube(GraphicsDevice graphicsDevice) {
            vertices = new VertexPositionColor[36];
            buildCube();
            effect = new BasicEffect(graphicsDevice);
            effect.VertexColorEnabled = true;
        }

        private void buildCube() {
            vertices[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Blue);
            vertices[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue);
            vertices[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);
            vertices[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue);
            vertices[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Blue);
            vertices[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);

            vertices[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Red);
            vertices[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
            vertices[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Red);
            vertices[9] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Red);
            vertices[10] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
            vertices[11] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Red);

            vertices[12] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Yellow);
            vertices[13] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);
            vertices[14] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Yellow);
            vertices[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Yellow);
            vertices[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Yellow);
            vertices[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);

            vertices[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Green);
            vertices[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);
            vertices[20] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Green);
            vertices[21] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Green);
            vertices[22] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Green);
            vertices[23] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Green);

            vertices[24] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Salmon);
            vertices[25] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Salmon);
            vertices[26] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Salmon);
            vertices[27] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Salmon);
            vertices[28] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Salmon);
            vertices[29] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Salmon);

            vertices[30] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Lime);
            vertices[31] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Lime);
            vertices[32] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Lime);
            vertices[33] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Lime);
            vertices[34] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Lime);
            vertices[35] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Lime);
        }

        public void Update(Matrix view, Matrix projection) {
            KeyboardState kbdState = Keyboard.GetState();

            if (kbdState.IsKeyDown(Keys.A))
                worldTranslation *= Matrix.CreateTranslation(-1f, 0, 0);
            if (kbdState.IsKeyDown(Keys.D))
                worldTranslation *= Matrix.CreateTranslation(1f, 0, 0);
            if (kbdState.IsKeyDown(Keys.W))
                worldTranslation *= Matrix.CreateTranslation(0, 0, -1f);
            if (kbdState.IsKeyDown(Keys.S))
                worldTranslation *= Matrix.CreateTranslation(0, 0, 1f);
            if (kbdState.IsKeyDown(Keys.Q))
                worldTranslation *= Matrix.CreateTranslation(0, 1f, 0);
            if (kbdState.IsKeyDown(Keys.E))
                worldTranslation *= Matrix.CreateTranslation(0, -1f, 0);
            if (kbdState.IsKeyDown(Keys.P))
                worldRotation *= Matrix.CreateRotationY(MathHelper.ToRadians(30));
            if (kbdState.IsKeyDown(Keys.O))
                worldRotation *= Matrix.CreateRotationY(-MathHelper.ToRadians(30));

            effect.World = worldRotation * worldTranslation;
            effect.View = view;
            effect.Projection = projection;
        }

        public void Draw() {

            effect.CurrentTechnique.Passes[0].Apply();

            effect.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
               PrimitiveType.TriangleList,
               vertices,
               0,
               vertices.Length / 3);
        }
    }
}
