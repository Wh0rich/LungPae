using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.Scenes
{
    internal class Scene8 : Component
    {
        Player player;
        public Scene8()
        {
            player = new Player();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            
            Data.TpRec = new Rectangle(0+5, Data.ScreenH / 2, 5, 40);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene7;
                Data.Plypos.X = 1280-60;
            }
            
            player.Draw(_spriteBatch);
        }
    }
}
