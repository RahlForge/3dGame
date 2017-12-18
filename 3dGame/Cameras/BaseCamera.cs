using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3dGame.Cameras
{
    public class BaseCamera : GameComponent
    {
        protected Vector3 cameraDirection;
        protected Vector3 cameraUp;
        protected MouseState prevMouseState;
        public Vector3 CameraPosition { get; protected set; }
        public Matrix View { get; protected set; }
        public Matrix Projection { get; protected set; }

        const float totalYaw = MathHelper.PiOver4 / 2;
        const float totalPitch = MathHelper.PiOver4 / 2;

        public BaseCamera(Game game, Vector3 pos, Vector3 target, Vector3 up) 
            : base(game)
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
