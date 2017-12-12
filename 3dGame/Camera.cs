using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _3dGame
{
    public class Camera : GameComponent
    {
        public Matrix View { get; protected set; }
        public Matrix Projection { get; protected set; }

        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up) 
            : base(game)
        {
            View = Matrix.CreateLookAt(pos, target, up);

            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)Game.Window.ClientBounds.Width /
                (float)Game.Window.ClientBounds.Height,
                1f, 3000f);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


    }
}
