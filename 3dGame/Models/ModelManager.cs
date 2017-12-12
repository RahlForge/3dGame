using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _3dGame.Models
{
    class ModelManager : DrawableGameComponent
    {
        List<BasicModel> models = new List<BasicModel>();

        public ModelManager(Game game) 
            : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            models.Add(new SpinningEnemy(Game.Content.Load<Model>(@"Models/starwars-tie-fighter")));

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < models.Count; i++)
            {
                models[i].Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (BasicModel bm in models)
            {
                bm.Draw(((Game1)Game).Camera);
            }

            base.Draw(gameTime);
        }
    }
}
