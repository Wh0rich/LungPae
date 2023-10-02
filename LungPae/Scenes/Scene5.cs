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
    internal class Scene5 : Component
    {
        Player player;
        Texture2D grass, Floor;
        public Scene5()
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
            Data.TpRec3 = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec4 = new Rectangle(Data.ScreenW-5, Data.ScreenH / 2, 5, 40);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene4;
                Data.Plypos.Y = 720 - 60;
            }
            if (player.PlayerRec.Intersects(Data.TpRec4))
            {
                Data.CurrentState = Data.Scenes.scene6;
                Data.Plypos.X = 0 + 10;
            }
            player.Draw(_spriteBatch);
        }
    }
}
