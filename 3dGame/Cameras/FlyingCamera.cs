using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _3dGame.Cameras
{
    public class FlyingCamera : BaseCamera
    {
        float speed;

        public FlyingCamera(Game game, Vector3 pos, Vector3 target, Vector3 up) 
            : base(game, pos, target, up)
        {
            speed = 3f;
        }

        public override void Initialize()
        {
            // Set initial mouse position to the center of the game window
            Mouse.SetPosition(Game.Window.ClientBounds.Width / 2,
                Game.Window.ClientBounds.Height / 2);
            prevMouseState = Mouse.GetState();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                CameraPosition += cameraDirection * speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                CameraPosition -= cameraDirection * speed;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                CameraPosition -= Vector3.Cross(cameraDirection, cameraUp) * speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                CameraPosition += Vector3.Cross(cameraDirection, cameraUp) * speed;

            // Yaw            
            cameraDirection = Vector3.Transform(cameraDirection, Matrix.CreateFromAxisAngle(
                cameraUp, (-MathHelper.PiOver4 / 150) * (Mouse.GetState().X - prevMouseState.X)));

            // Roll
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(
                    cameraDirection, (MathHelper.PiOver4 / 45)));
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(
                    cameraDirection, (-MathHelper.PiOver4 / 45)));
            }

            // Pitch
            cameraDirection = Vector3.Transform(cameraDirection, Matrix.CreateFromAxisAngle(
                Vector3.Cross(cameraUp, cameraDirection), (MathHelper.PiOver4 / 100) *
                (Mouse.GetState().Y - prevMouseState.Y)));

            cameraUp = Vector3.Transform(cameraUp, Matrix.CreateFromAxisAngle(
                Vector3.Cross(cameraUp, cameraDirection), (MathHelper.PiOver4 / 100) *
                (Mouse.GetState().Y - prevMouseState.Y)));

            // Reset mouse state
            Mouse.SetPosition(Game.Window.ClientBounds.Width / 2,
                Game.Window.ClientBounds.Height / 2);
            prevMouseState = Mouse.GetState();

            CreateLookAt();

            base.Update(gameTime);
        }

        private void CreateLookAt( )
        {
            View = Matrix.CreateLookAt(CameraPosition, CameraPosition + cameraDirection,
                cameraUp);
        }
    }
}
