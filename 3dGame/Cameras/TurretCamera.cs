using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3dGame.Cameras
{
    public class TurretCamera : BaseCamera
    {
        float currentYaw;
        float currentPitch;

        const float totalYaw = MathHelper.PiOver4 / 2;
        const float totalPitch = MathHelper.PiOver4 / 2;

        public TurretCamera(Game game, Vector3 pos, Vector3 target, Vector3 up) 
            : base(game, pos, target, up)
        {
            CameraPosition = pos;
            cameraDirection = target - pos;
            cameraDirection.Normalize();
            cameraUp = up;
            CreateLookAt();

            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)Game.Window.ClientBounds.Width /
                (float)Game.Window.ClientBounds.Height,
                1f, 3000f);
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
            // Yaw            
            float yawAngle = (-MathHelper.PiOver4 / 150) * (Mouse.GetState().X - prevMouseState.X);

            if (Math.Abs(currentYaw + yawAngle) < totalYaw)
            {
                cameraDirection = Vector3.Transform(cameraDirection, Matrix.CreateFromAxisAngle(
                    cameraUp, yawAngle));
                currentYaw += yawAngle;
            }

            // Pitch
            float pitchAngle = (-MathHelper.PiOver4 / 150) * (Mouse.GetState().Y - prevMouseState.Y);

            if (Math.Abs(currentPitch + pitchAngle) < totalPitch)
            {
                cameraDirection = Vector3.Transform(cameraDirection, Matrix.CreateFromAxisAngle(
                    Vector3.Cross(cameraUp, cameraDirection), -pitchAngle));
                currentPitch += pitchAngle;
            }

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
