using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3dGame.Models
{
    class SpinningEnemy : BasicModel
    {
        Matrix rotation;
        float yawAngle;
        float pitchAngle;
        float rollAngle;
        Vector3 direction;

        public SpinningEnemy(Model model, Vector3 position, Vector3 direction,
            float yawAngle, float pitchAngle, float rollAngle) 
            : base(model)
        {
            world = Matrix.CreateTranslation(position);
            this.yawAngle = yawAngle;
            this.pitchAngle = pitchAngle;
            this.rollAngle = rollAngle;
            this.direction = direction;
        }

        public override void Update()
        {           
            rotation *= Matrix.CreateFromYawPitchRoll(yawAngle, pitchAngle, rollAngle);

            world *= Matrix.CreateTranslation(direction);

            base.Update();
        }

        public override Matrix World
        {
            get { return rotation * world; }
        }
    }
}
