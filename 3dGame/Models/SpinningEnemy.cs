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

        public SpinningEnemy(Model model) 
            : base(model)
        {
            rotation = Matrix.Identity;
        }

        public override void Update()
        {           
            rotation *= Matrix.CreateRotationZ(MathHelper.Pi / 180);

            base.Update();
        }

        public override Matrix World
        {
            get { return rotation * world; }
        }
    }
}
