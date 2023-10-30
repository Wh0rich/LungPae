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
    internal class Scene6 : Component
    {
        Player player;
        Item money;
        Texture2D Floor, grass;
        NPC npc1, npc2, npc3, npc4, npc5, npc6, npc7, npc8;
        Campfire fire;
        Building shop1, shop2, shop3, shop4, shop5;
        Dialog dialog;
        Crowd crowd;
        
        Bush bush_1, bush_2, bush_3, bush_4, bush_5, bush_6, bush_7, bush_8, bush_9, bush_10, bush_11, bush_12, bush_13, bush_14;

        Rectangle CrowdRec;
        float temp;
        bool Talk;
        bool mask = false;
        bool stick = false;
        public Scene6()
        {
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(150, 200));
            npc2 = new NPC(0, 0.6f, 0.5f, new Vector2(200, 520));
            npc3 = new NPC(0, 0.6f, 0.5f, new Vector2(300, 190));
            npc4 = new NPC(0, 0.6f, 0.5f, new Vector2(550, 450));
            npc5 = new NPC(0, 0.6f, 0.5f, new Vector2(6500, 220));
            npc6 = new NPC(0, 0.6f, 0.5f, new Vector2(780, 380));
            npc7 = new NPC(0, 0.6f, 0.5f, new Vector2(820, 270));
            npc8 = new NPC(0, 0.6f, 0.5f, new Vector2(980, 290));
            shop1 = new Building(new Vector2(0,0), 0.7f);
            shop2 = new Building(new Vector2(250, 0), 0.7f);
            shop3 = new Building(new Vector2(500, 0), 0.7f);
            shop4 = new Building(new Vector2(750, 0), 0.7f);
            shop5 = new Building(new Vector2(1000, 0), 0.7f);
            player = new Player();
            money = new Item(new Vector2(1200,410));
            dialog = new Dialog();
            fire = new Campfire(new Vector2(20,555), 0.8f);
            crowd = new Crowd();
            bush_1 = new Bush(new Vector2(0, 630), 0.2f);
            bush_2 = new Bush(new Vector2(90, 630), 0.2f);
            bush_3 = new Bush(new Vector2(180, 630), 0.2f);
            bush_4 = new Bush(new Vector2(270, 630), 0.2f);
            bush_5 = new Bush(new Vector2(360, 630), 0.2f);
            bush_6 = new Bush(new Vector2(750, 630), 0.2f);
            bush_7 = new Bush(new Vector2(840, 630), 0.2f);
            bush_8 = new Bush(new Vector2(930, 630), 0.2f);
            bush_9 = new Bush(new Vector2(1020, 630), 0.2f);
            bush_10 = new Bush(new Vector2(1110, 630), 0.2f);
            bush_11 = new Bush(new Vector2(1200, 630), 0.2f);
            bush_12 = new Bush(new Vector2(450, 630), 0.2f);
            bush_13 = new Bush(new Vector2(540, 630), 0.2f);
            bush_14 = new Bush(new Vector2(650, 630), 0.2f);
        }
        internal override void LoadContent(ContentManager Content)
        {
            dialog.LoadContent(Content);
            npc1.Load(Content, "NPC", 4, 4, 0);
            npc2.Load(Content, "NPC", 4, 4, 0);
            npc3.Load(Content, "NPC", 4, 4, 0);
            npc4.Load(Content, "NPC", 4, 4, 0);
            npc5.Load(Content, "NPC", 4, 4, 0);
            npc6.Load(Content, "NPC", 4, 4, 0);
            npc7.Load(Content, "NPC", 4, 4, 0);
            npc8.Load(Content, "NPC", 4, 4, 0);
            player.LoadContent(Content);
            crowd.Load(Content);
            shop1.Load(Content, "shop1");
            shop2.Load(Content, "shop2");
            shop3.Load(Content, "shop3");
            shop4.Load(Content, "shop1");
            shop5.Load(Content, "shop2");
            
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            shop1.Load(Content,"shop1");
            money.Load(Content,"cash1");
            bush_1.Load(Content);
            bush_2.Load(Content);
            bush_3.Load(Content);
            bush_4.Load(Content);
            bush_5.Load(Content);
            bush_6.Load(Content);
            bush_7.Load(Content);
            bush_8.Load(Content);
            bush_9.Load(Content);
            bush_10.Load(Content);
            bush_11.Load(Content);
            bush_12.Load(Content);
            bush_13.Load(Content);
            bush_14.Load(Content);
            Data.Cash.Load(Content,"cash1");
            
            fire.Load(Content);
            

        }
        internal override void Update(GameTime gameTime)
        {
            
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            npc1.Update(gameTime);
            npc2.Update(gameTime);
            npc3.Update(gameTime);
            npc4.Update(gameTime);
            npc5.Update(gameTime);
            npc6.Update(gameTime);
            npc7.Update(gameTime);
            npc8.Update(gameTime);
            npc1.Npccheck(player);
            npc2.Npccheck(player);
            npc3.Npccheck(player);
            npc4.Npccheck(player);
            npc5.Npccheck(player);
            npc6.Npccheck(player);
            npc7.Npccheck(player);
            npc8.Npccheck(player);
            player.Collision(npc1.NpcRec);
            player.Collision(npc2.NpcRec);
            player.Collision(npc3.NpcRec);
            player.Collision(npc4.NpcRec);
            player.Collision(npc5.NpcRec);
            player.Collision(npc6.NpcRec);
            player.Collision(npc7.NpcRec);
            player.Collision(npc8.NpcRec);
            shop1.CheckCollision(player);
            shop2.CheckCollision(player);
            shop3.CheckCollision(player);
            shop4.CheckCollision(player);
            shop5.CheckCollision(player);
            player.Collision(shop1.ObjRecDown);
            player.Collision(shop2.ObjRecDown);
            player.Collision(shop3.ObjRecDown);
            player.Collision(shop4.ObjRecDown);
            player.Collision(shop5.ObjRecDown);
            bush_1.Bushcheck(player);
            bush_2.Bushcheck(player);
            bush_3.Bushcheck(player);
            bush_4.Bushcheck(player);
            bush_5.Bushcheck(player);
            bush_6.Bushcheck(player);
            bush_7.Bushcheck(player);
            bush_8.Bushcheck(player);
            bush_9.Bushcheck(player);
            bush_10.Bushcheck(player);
            bush_11.Bushcheck(player);
            bush_12.Bushcheck(player);
            bush_13.Bushcheck(player);
            bush_14.Bushcheck(player);
            if (Data.Quest2Finish == true && Data.Quest2 == true)
            {

            }
           
            if (player.PlayerRec.Intersects(crowd.CrowdRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(crowd.CrowdRec))
            {
                Talk = true;
                Data.CanControl = false;

            }
            if (player.PlayerRec.Intersects(fire.fireRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(fire.fireRec))
            {
                fire.Talk = true;
                Data.CanControl = false;
                Data.Oldms = Data.ms;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Data.Quest2Finish = true;
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
            if (player.PlayerRec.Intersects(npc4.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc4.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc5.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc5.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc6.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc6.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc7.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc7.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc8.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc8.talk = true;
                Data.CanControl = false;
            }



            crowd.Update(gameTime);
            player.Update(gameTime);
            player.Collision(crowd.CrowdRec);
            player.Collision(fire.fireRec);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
           
           

            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(0, Data.ScreenH / 2, 5, 40);
            Data.TpRec2 = new Rectangle(Data.ScreenW - 5, Data.ScreenH / 2, 5, 40);
            npc1.Draw(_spriteBatch, 0, 2);
            npc2.Draw(_spriteBatch, 2, 1);
            npc3.Draw(_spriteBatch, 3, 1);
            npc4.Draw(_spriteBatch, 3, 2);
            npc5.Draw(_spriteBatch, 1, 2);
            npc6.Draw(_spriteBatch, 0, 3);
            npc7.Draw(_spriteBatch, 1, 4);
            npc8.Draw(_spriteBatch, 2, 4);
            shop1.Draw(_spriteBatch);
            shop2.Draw(_spriteBatch);
            shop3.Draw(_spriteBatch);
            shop4.Draw(_spriteBatch);
            shop5.Draw(_spriteBatch);
            bush_1.Drawbig(_spriteBatch);
            bush_2.Drawbig(_spriteBatch);
            bush_3.Drawbig(_spriteBatch);
            bush_4.Drawbig(_spriteBatch);
            bush_5.Drawbig(_spriteBatch);
            bush_6.Drawbig(_spriteBatch);
            bush_7.Drawbig(_spriteBatch);
            bush_8.Drawbig(_spriteBatch);
            bush_9.Drawbig(_spriteBatch);
            bush_10.Drawbig(_spriteBatch);
            bush_11.Drawbig(_spriteBatch);
            bush_12.Drawbig(_spriteBatch);
            bush_13.Drawbig(_spriteBatch);
            bush_14.Drawbig(_spriteBatch);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            for (int i = 0; i < 33; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2+40)+ Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2-40)+ Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene5;
                Data.Plypos.X = 1280 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene7;
                Data.Plypos.X = 0 + 10;
            }
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }

            if (Talk == true && Data.Quest2Finish == false)
            {

                dialog.Draw(_spriteBatch);
                dialog.ChangeDialog("The crowd was so crowded\nit seemed impossible to continue.");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec))
                {
                    Talk = false;
                    Data.CanControl = true;
                }

            }
           
            if (fire.Talk == true)
            {
                fire.Speak(_spriteBatch);
            }

            if (Data.Quest2Finish == false)
            {
                crowd.Draw(_spriteBatch);
            }
            if (Data.Quest2Finish == true && Data.OnFire == true)
            {
                
                Data.CurrentState = Data.Scenes.Blackscreen;
                Data.inv.RemoveItem(Data.Matchstick);
                Data.inv.RemoveItem(Data.RobberHAt);
               
            }

            if (Data.Quest2Finish == true)
            {
                if (money.pickup == false)
                {
                    money.Draw(_spriteBatch);
                }
            }
            if (player.PlayerRec.Intersects(money.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(money.itemRec) && money.pickup == false)
            {
                Data.Money += 1;
                if (Data.Money ==  1)
                {
                    Data.inv.AddItem(Data.Cash);
                    Data.Cash.pickup = true;
                }
                if (Data.Money == 2)
                {
                    Data.inv.AddItem(Data.Cash2);
                    Data.Cash2.pickup = true;
                }
                if (Data.Money == 3)
                {
                    Data.inv.AddItem(Data.Cash3);
                    Data.Cash3.pickup = true;
                }
                
                money.pickup = true;
                
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
            if (npc4.talk == true)
            {
                npc4.Dialog(_spriteBatch);
            }
            if (npc5.talk == true)
            {
                npc5.Dialog(_spriteBatch);
            }
            if (npc6.talk == true)
            {
                npc6.Dialog(_spriteBatch);
            }
            if (npc7.talk == true)
            {
                npc7.Dialog(_spriteBatch);
            }
            if (npc8.talk == true)
            {
                npc8.Dialog(_spriteBatch);
            }

            fire.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
        }
    }
}