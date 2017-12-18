using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3dGame.Cameras;

namespace _3dGame.Models
{
    class BasicModel
    {
        public Model Model { get; protected set; }
        public Matrix world;

        public BasicModel(Model model)
        {
            Model = model;
            world = Matrix.CreateFromYawPitchRoll(0f, MathHelper.Pi * -0.5f, 0f);
        }

        public virtual void Update()
        {
            //world = Matrix.CreateFromYawPitchRoll(0f, MathHelper.Pi * -0.5f, 0f) *
            //    Matrix.CreateTranslation(new Vector3(0f, 0f, -50f));
        }

        public void Draw(BaseCamera camera)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.Projection = camera.Projection;
                    be.View = camera.View;
                    be.World = World + mesh.ParentBone.Transform;
                }

                mesh.Draw();
            }
        }

        public virtual Matrix World
        {
            get { return world; }
        }
    }
}
