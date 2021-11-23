using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lab5b {

    public class Game1 : Game {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BasicEffect effect;

        private Net net;
        private Cube cube1, cube2;

        private Vector3 cameraPos = new Vector3(0, 0, 100);
        private Vector3 cameraTarget = Vector3.Zero;

        private Matrix view, projection;
        float angleX = 0.0f;
        float angleY = 0.0f;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            
            projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)Window.ClientBounds.Width / (float)Window.ClientBounds.Height,
                0.1f,
                1000f);

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;

            net = new Net(GraphicsDevice, new Vector3(-60, 0, -60), new Vector3(60, 0, 60));
            net.Load();

            cube1 = new Cube(GraphicsDevice, new Vector3(10, 10, 0), 1, 1);
            cube2 = new Cube(GraphicsDevice, new Vector3(20, 10, 20), 3, 3);
        }

        protected override void Update(GameTime gameTime) {
            KeyboardState kbd = Keyboard.GetState();

            if (kbd.IsKeyDown(Keys.Escape)) {
                Exit();
            }

            if (kbd.IsKeyDown(Keys.Right)) {
                angleY += 0.02f;
            }
            if (kbd.IsKeyDown(Keys.Left)) {
                angleY -= 0.02f;
            }
            if (kbd.IsKeyDown(Keys.Up)) {
                angleX += 0.02f;
            }
            if (kbd.IsKeyDown(Keys.Down)) {
                angleX -= 0.02f;
            }

            // TODO: Add your update logic here
            view = Matrix.CreateLookAt(cameraPos, cameraTarget, Vector3.Up);
            view = Matrix.CreateRotationX(angleX) * Matrix.CreateRotationY(angleY) * view;

            effect.View = view;
            effect.Projection = projection;

            cube1.Update(view, projection);
            cube2.Update(view, projection);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            net.DrawWithCoordinateSystem(view, projection);
            cube1.Draw();
            cube2.Draw();

            base.Draw(gameTime);
        }
    }
}
