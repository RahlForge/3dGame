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
        Matrix translation;
        Matrix currentOrientation;
        Matrix newOrientation;
        Vector3 Direction = new Vector3(0, 0, -1);
        

        public SpinningEnemy(Model model) 
            : base(model)
        {
            world = Matrix.CreateFromYawPitchRoll(MathHelper.Pi, MathHelper.Pi * -0.5f, 0f);
            rotation = Matrix.Identity;
            translation = Matrix.Identity;
            currentOrientation = rotation;
            newOrientation = currentOrientation * Matrix.CreateRotationZ(MathHelper.Pi);
        }

        public override void Update()
        {           
            if (translation.Translation.Z < -400 ||
                translation.Translation.Z > 0)
            {
                Direction.Z *= -1;
                rotation *= Matrix.CreateRotationZ(MathHelper.Pi);
            }

            translation *= Matrix.CreateTranslation(Direction);

            base.Update();
        }

        public override Matrix World
        {
            get { return rotation * translation * world; }
        }
    }
}
