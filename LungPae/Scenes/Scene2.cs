using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using LungPae.Model;
using lungpae;

namespace LungPae.Scenes
{
    internal class Scene2 : Component
    {
        Texture2D Floor;
        Texture2D grass;
        Item hat;
        NPC npc1, npc2, npc3;
        Building building,building2,building3,building4,building5,building6,building7, building8, building9, building10;
        material bin;
        
        TAE tae;
       // Building Shed;
        Player player;
        
        
        public Scene2()
        {
            
            //Shed = new Building(new Vector2(350, 150), 2f);
            player = new Player();
            bin = new material(new Vector2(1020, 320),1f);
            building = new Building(new Vector2(0, 20),0.15f);
            building2 = new Building(new Vector2(200, 20), 0.15f);
            building3 = new Building(new Vector2(0, 460), 0.15f);
            building4 = new Building(new Vector2(700, 20), 0.15f);
            building5 = new Building(new Vector2(900, 20), 0.15f);
            building6 = new Building(new Vector2(1100, 20), 0.15f);
            building7 = new Building(new Vector2(200, 460), 0.15f);
            building8 = new Building(new Vector2(700, 460), 0.15f);
            building9 = new Building(new Vector2(900, 460), 0.15f);
            building10 = new Building(new Vector2(1100, 460), 0.15f);
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(200, 300));
            npc2 = new NPC(0, 0.6f, 0.5f, new Vector2(920, 350));
            npc3 = new NPC(0, 0.6f, 0.5f, new Vector2(750, 320));

            hat = new Item(new Vector2(1000, 315));
            player.row = 4;
            tae = new TAE();

        }
        internal override void LoadContent(ContentManager Content)
        {
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            building.Load(Content, "buliding");
            building2.Load(Content, "buliding");
            building3.Load(Content, "buliding");
            building4.Load(Content, "buliding");
            building5.Load(Content, "buliding");
            building6.Load(Content, "buliding");
            building7.Load(Content, "buliding");
            building8.Load(Content, "buliding");
            building9.Load(Content, "buliding");
            building10.Load(Content, "buliding");
            npc1.Load(Content, "NPC", 4, 4, 0);
            npc2.Load(Content, "NPC", 4, 4, 0);
            npc3.Load(Content, "NPC", 4, 4, 0);
            hat.Load(Content, "RobberHat");
            bin.Load(Content,"recyclebin");
            Data.RobberHAt.Load(Content, "RobberHat");
            
            //Shed.Load(Content, "Shed");
            tae.Load(Content);

            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
           
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            tae.Update(gameTime);
            npc1.Update(gameTime);
            npc2.Update(gameTime);
            npc3.Update(gameTime);
            player.Collision(building.ObjRecDown);
            player.Collision(building2.ObjRecDown);
            player.Collision(building3.ObjRecDown);
            player.Collision(building4.ObjRecDown);
            player.Collision(building5.ObjRecDown);
            player.Collision(building6.ObjRecDown);
            player.Collision(building7.ObjRecDown);
            player.Collision(building8.ObjRecDown);
            player.Collision(building9.ObjRecDown);
            player.Collision(building10.ObjRecDown);
            building.CheckCollision(player);
            building2.CheckCollision(player);
            building3.CheckCollision(player);
            building4.CheckCollision(player);
            building5.CheckCollision(player);
            building6.CheckCollision(player);
            building7.CheckCollision(player);
            building8.CheckCollision(player);
            building9.CheckCollision(player);
            building10.CheckCollision(player);
            player.Collision(npc1.NpcRec);
            player.Collision(npc2.NpcRec);
            player.Collision(npc3.NpcRec);
            npc1.Npccheck(player);
            npc2.Npccheck(player);
            npc3.Npccheck(player);
            bin.CheckCollision(player);

            tae.taeCheck(player);
            
            if (player.PlayerRec.Intersects(hat.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(hat.itemRec) && hat.pickup == false)
            {
                Data.inv.AddItem(Data.RobberHAt);
                Data.mask = true;
                hat.pickup = true;

            }
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
            if (player.PlayerRec.Intersects(npc3.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc3.talk = true;
                Data.CanControl = false;
            }
            if (Data.CanControl == true)
            {
                //player.Collision(Shed.ObjRec);
                player.Update(gameTime);
            }
           
            if (player.PlayerRec.Intersects(tae.taeRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(tae.taeRecTalk))
            {

                tae.Talktae = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    tae.row = 3;
                }
                if (player.row == 2)
                {
                    tae.row = 2;
                }
                if (player.row == 3)
                {
                    tae.row = 1;
                }
                if (player.row == 4)
                {
                    tae.row = 4;
                }

            }
            if (player.PlayerRec.Intersects(tae.taeRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(tae.taeRecTalk))
            {
                Data.CanControl = false;
                tae.Talktae = true;
            }

                //if (player.PlayerRec.Intersects(Shed.ObjRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(Shed.ObjRec))
                //{
                //    Data.CanControl = false;

                //}
                
            }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);
            building.Draw(_spriteBatch);
            building2.Draw(_spriteBatch);
            building3.Draw(_spriteBatch);
            building4.Draw(_spriteBatch);
            building5.Draw(_spriteBatch);
            building6.Draw(_spriteBatch);
            building7.Draw(_spriteBatch);
            building8.Draw(_spriteBatch);
            building9.Draw(_spriteBatch);
            building10.Draw(_spriteBatch);
            bin.Draw(_spriteBatch);
            npc1.Draw(_spriteBatch, 1,2);
            npc2.Draw(_spriteBatch, 2,3);
            npc3.Draw(_spriteBatch, 3,4);

            if (hat.pickup == false)
            {
                hat.Draw(_spriteBatch);
            }
            


            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene1;
                Data.Plypos.Y = 720 -80 ;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene3;
                Data.Plypos.Y = 0 + 10;
            }
            
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            for (int i = 0; i < 19; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY*i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2-40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 80, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            //Shed.Draw(_spriteBatch);
            
            player.Draw(_spriteBatch);
            if (Data.Quest3Finish == false)
            {
                tae.Draw(_spriteBatch);
            }
            if (npc1.talk == true)
            {
                npc1.Dialog(_spriteBatch);
            }
            if (npc2.talk == true)
            {
                npc2.Dialog(_spriteBatch);
            }
            if (npc3.talk == true)
            {
                npc3.Dialog(_spriteBatch);
            }

        }
    }
}
