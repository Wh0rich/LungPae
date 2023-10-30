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
using Microsoft.Xna.Framework.Input;

namespace LungPae.Scenes
{
    internal class Scene12 : Component
    {
        Player player;
        Texture2D Floor, grass;
        Building seven1, seven2, h1, h2;
        material fontaine;
        public Scene12()
        {
            player = new Player();
            seven1 = new Building(new Vector2(0, 20), 0.3f);
            seven2 = new Building(new Vector2(900, 20), 0.3f);
            h1 = new Building(new Vector2(0, 450), 0.3f);
            h2 = new Building(new Vector2(1020, 450), 0.3f);
            fontaine = new material(new Vector2(560, 280), 1.2f);

        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            seven1.Load(Content, "7-11");
            seven2.Load(Content, "7-11");
            h1.Load(Content, "House3");
            h2.Load(Content, "House1");
            fontaine.Load(Content, "fontaine");
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            h1.CheckCollision(player);
            player.Collision(h1.ObjRecDown);
            h2.CheckCollision(player);
            player.Collision(h2.ObjRecDown);
            seven1.CheckCollision(player);
            player.Collision(seven1.ObjRecDown);
            seven2.CheckCollision(player);
            player.Collision(seven2.ObjRecDown);
            fontaine.CheckCollision(player);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW - 5, Data.ScreenH / 2, 5, 40);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec3 = new Rectangle(Data.ScreenW/2, Data.ScreenH - 5 , 40, 5);
            seven1.Draw(_spriteBatch);
            seven2.Draw(_spriteBatch);
            h1.Draw(_spriteBatch);
            h2.Draw(_spriteBatch);
            fontaine.Draw(_spriteBatch);
            for (int i = 0; i < 15; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2+80) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2+40) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            for (int i = 0; i < 19; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 + 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene11;
                Data.Plypos.X = 0 + 70;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene14;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene13;
                Data.Plypos.Y = 0 + 10;
            }
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }
            }
            
            player.Draw(_spriteBatch);





        }
    }
}
