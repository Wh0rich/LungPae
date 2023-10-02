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
    internal class Scene7 : Component
    {
        Player player;
        Texture2D grass, Floor;
        public Scene7()
        {
            player = new Player();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            grass = Content.Load<Texture2D>("grass");
            Floor = Content.Load<Texture2D>("Floor");
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(0, Data.ScreenH /2, 5, 40);
            Data.TpRec2 = new Rectangle(Data.ScreenW/2, 0, 40, 5);
            Data.TpRec3 = new Rectangle(Data.ScreenW, Data.ScreenH / 2, 5, 40);
            _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW -Floor.Width, Data.ScreenH/2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
           
             if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene6;
                Data.Plypos.X = Data.ScreenW - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene9;
                Data.Plypos.Y = 720 -80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene8;
                Data.Plypos.X = 0 + 10;
            }
            player.Draw(_spriteBatch);
        }
    }
}
