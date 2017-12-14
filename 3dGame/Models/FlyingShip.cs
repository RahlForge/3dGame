using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3dGame.Models
{
    class FlyingShip : BasicModel
    {
        Matrix rotation;
        Matrix translation;
        Vector3 Direction = new Vector3(0, -1, 0);


        public FlyingShip(Model model)
            : base(model)
        {
            world = Matrix.CreateFromYawPitchRoll(MathHelper.Pi, MathHelper.Pi * -0.5f, 0f);
            rotation = Matrix.Identity;
            translation = Matrix.Identity;
        }

        public override void Update()
        {
            if (translation.Translation.Y < -400 ||
                translation.Translation.Y > 0)
            {
                Direction.Y *= -1;
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
