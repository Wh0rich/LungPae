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
using Microsoft.Xna.Framework.Input;

namespace LungPae.Scenes
{
    internal class Scene8 : Component
    {
        Player player;
        WatermelonShop melonshop;
        public Scene8()
        {
            player = new Player();
            melonshop = new WatermelonShop();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            melonshop.Load(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            melonshop?.Update(gameTime);
            melonshop.CheckCollision(player);
            if (player.PlayerRec.Intersects(melonshop.TalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(melonshop.TalkRec))
            {
                melonshop.Talk = true;
                Data.CanControl = false;
            }
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
            melonshop.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
        }
    }
}
