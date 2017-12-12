using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3dGame.Models
{
    class SpinningEnemy : BasicModel
    {
        Matrix rotation;
        float speed;

        public SpinningEnemy(Model model) 
            : base(model)
        {
            speed = -1f;
            world = Matrix.CreateFromYawPitchRoll(MathHelper.Pi, MathHelper.Pi * -0.5f, 0f);
            rotation = Matrix.Identity;
        }

        public override void Update()
        {
            world *= Matrix.CreateTranslation(new Vector3(
                0f, 0f, speed));
            
            if (world.Translation.Z <= -400)
            {
                if (rotation.Rotation.Z < MathHelper.Pi / 270)
                {
                    speed = 0f;
                    rotation *= Matrix.CreateRotationZ(MathHelper.Pi / 180);
                }
                else
                {
                    speed = 1f;
                }
            }
            else if (world.Translation.Z >= 0)
            {
                if (World.Rotation.Y != MathHelper.Pi)
                {
                    speed = 0f;
                    rotation *= Matrix.CreateRotationY(MathHelper.Pi / 180);
                }
                else
                    speed = -1f;               
            }

            base.Update();
        }

        public override Matrix World
        {
            get { return rotation * world; }
        }

        private void Spin()
        {

        }
    }
}
