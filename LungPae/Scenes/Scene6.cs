using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using Microsoft.Xna.Framework.Content;
using LungPae.Model;

namespace LungPae.Scenes
{
    internal class Scene6 : Component
    {
        Player player;
        public Scene6()
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
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 5, 5);
            Data.TpRec2 = new Rectangle(0, Data.ScreenH/2 , 5, 5);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene7;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene5;
                Data.Plypos.X =1280 - 61;
            }
            player.Draw(_spriteBatch);
        }
    }
}
