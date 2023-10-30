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
    internal class Scene3 : Component
    {
        Player player;
        Building house, house2, house3,house4, house5, house6,building,building2;
        NPC npc1, npc2;
        Texture2D Floor , grass;
        public Scene3()
        {
            player = new Player();
            building = new Building(new Vector2(300, 20), 0.2f);
            building2 = new Building(new Vector2(300, 480), 0.2f);
            house = new Building(new Vector2(0, 20), 0.3f);
            house2 = new Building(new Vector2(750, 20), 0.3f);
            house3 = new Building(new Vector2(1000, 20), 0.5f);
            house4 = new Building(new Vector2(0, 450), 0.3f);
            house5 = new Building(new Vector2(750, 450), 0.3f);
            house6 = new Building(new Vector2(1000, 450), 0.5f);
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(200, 380));
            npc2 = new NPC(0, 0.6f, 0.5f, new Vector2(1020, 400));

        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            
            house.Load(Content, "House1");
            house2.Load(Content, "House3");
            house3.Load(Content, "house-2");
            house4.Load(Content, "House1");
            house5.Load(Content, "House3");
            house6.Load(Content, "house-2");
            building.Load(Content, "buliding");
            building2.Load(Content, "buliding");
            npc1.Load(Content, "NPC", 4, 4, 0);
            npc2.Load(Content, "NPC", 4, 4, 0);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            npc1.Update(gameTime);
            npc2.Update(gameTime);
            npc1.Npccheck(player);
            npc2.Npccheck(player);
            player.Collision(npc1.NpcRec);
            player.Collision(npc2.NpcRec);
            house.CheckCollision(player);
            house2.CheckCollision(player);
            house3.CheckCollision(player);
            house4.CheckCollision(player);
            house5.CheckCollision(player);
            house6.CheckCollision(player);
            building.CheckCollision(player);
            player.Collision(building.ObjRecDown);
            player.Collision(building2.ObjRecDown);
            player.Collision(house.ObjRecDown);
            player.Collision(house2.ObjRecDown);
            player.Collision(house3.ObjRecDown);
            player.Collision(house4.ObjRecDown);
            player.Collision(house5.ObjRecDown);
            player.Collision(house6.ObjRecDown);

            if (player.PlayerRec.Intersects(npc1.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc1.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc2.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc2.talk = true;
                Data.CanControl = false;
            }
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 5);
            npc1.Draw(_spriteBatch, 2, 2);
            npc2.Draw(_spriteBatch, 1, 3);
            building.Draw(_spriteBatch);
            building2.Draw(_spriteBatch);
            house.Draw(_spriteBatch);
            house2.Draw(_spriteBatch);
            house3.Draw(_spriteBatch);
            house4.Draw(_spriteBatch);
            house5.Draw(_spriteBatch);
            house6.Draw(_spriteBatch);

            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene2;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene4;
                Data.Plypos.Y = 0 + 10;
            }
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            for (int i = 0; i < 19; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 80, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            player.Draw(_spriteBatch);
            if (npc1.talk == true)
            {
                npc1.Dialog(_spriteBatch);
            }
            if (npc2.talk == true)
            {
                npc2.Dialog(_spriteBatch);
            }




        }
    }
}
