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
using System.Reflection.Metadata;



namespace LungPae.Scenes
{
    internal class Scene4 : Component 
    {
        Player player;
        Kid kid;
        Dialog dialog;
        Inventory inv;
        NPC npc1, npc3;
        Texture2D floor, grass;
        Building sandbox,chicken;
        material fontaine;
        Bush bush1, bush2, bush3, bush4, bush5, bush6, bush7, bush8, bush9, bush10, bush11,bush_1, bush_2, bush_3, bush_4, bush_5, bush_6, bush_7, bush_8, bush_9, bush_10, bush_11, bush_12, bush_13;
        Bush bushY1, bushY2, bushY3, bushY4, bushY5, bushY6, bushY7, bushY8, bushY9, bushY10, bushY11, bushY12 , bush12 , bush13;    


        bool pickMelon = false;
        Rectangle melonRec;
        public Scene4()
        {
            sandbox = new Building(new Vector2(100, 100), 2f);
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(150, 480));
            npc3 = new NPC(0, 0.6f, 0.5f, new Vector2(1020, 230));

            fontaine = new material(new Vector2(560, 280), 1.2f);
            chicken = new Building(new Vector2(950,150),1f);
            player = new Player();
            bushY1 = new Bush(new Vector2(0, 90), 0.2f);
            bushY2 = new Bush(new Vector2(0, 180), 0.2f);
            bushY3 = new Bush(new Vector2(0, 270), 0.2f);
            bushY4 = new Bush(new Vector2(0, 360), 0.2f);
            bushY5 = new Bush(new Vector2(0, 450), 0.2f);
            bushY6 = new Bush(new Vector2(0, 540), 0.2f);
            bushY7 = new Bush(new Vector2(1200, 90), 0.2f);
            bushY8 = new Bush(new Vector2(1200, 180), 0.2f);
            bushY9 = new Bush(new Vector2(1200, 270), 0.2f);
            bushY10 = new Bush(new Vector2(1200, 360), 0.2f);
            bushY11 = new Bush(new Vector2(1200, 450), 0.2f);
            bushY12 = new Bush(new Vector2(1200, 540), 0.2f);
            bush1 = new Bush(new Vector2(0,0), 0.2f);
            bush2 = new Bush(new Vector2(90,0), 0.2f);
            bush3 = new Bush(new Vector2(180, 0), 0.2f);
            bush4 = new Bush(new Vector2(270, 0), 0.2f);
            bush5 = new Bush(new Vector2(360, 0), 0.2f);
            bush12 = new Bush(new Vector2(450, 0), 0.2f);
            bush13 = new Bush(new Vector2(540, 0), 0.2f);
            bush6 = new Bush(new Vector2(750, 0), 0.2f);
            bush7 = new Bush(new Vector2(840, 0), 0.2f);
            bush8 = new Bush(new Vector2(930, 0), 0.2f);
            bush9 = new Bush(new Vector2(1020, 0), 0.2f);
            bush10 = new Bush(new Vector2(1110, 0), 0.2f);
            bush11 = new Bush(new Vector2(1200, 0), 0.2f);

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

            kid = new Kid();
            dialog = new Dialog();
            inv = new Inventory();
            

            


        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            npc1.Load(Content, "NPC", 4, 4, 0);

            npc3.Load(Content, "NPC", 4, 4, 0);
            dialog.LoadContent(Content);
            fontaine.Load(Content, "fontaine");
            kid.Load(Content);
            bushY1.Load(Content);
            bushY2.Load(Content);
            bushY3.Load(Content);
            bushY4.Load(Content);
            bushY5.Load(Content);
            bushY6.Load(Content);
            bushY7.Load(Content);
            bushY8.Load(Content);
            bushY9.Load(Content);
            bushY10.Load(Content);
            bushY11.Load(Content);
            bushY12.Load(Content);
            bush1.Load(Content);
            bush2.Load(Content);
            bush3.Load(Content);
            bush4.Load(Content);
            bush5.Load(Content);    
            bush6.Load(Content);
            bush7.Load(Content);
            bush8.Load(Content);
            bush9.Load(Content);
            bush10.Load(Content);
            bush11.Load(Content);
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
            bush12.Load(Content);
            bush13.Load(Content);
            floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            sandbox.Load(Content, "sandbox");
            chicken.Load(Content, "chicken");
            Data.Watermelon.Load(Content, "watermelon");
           
            
            

        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            npc1.Update(gameTime);
            npc3.Update(gameTime);
            npc1.Npccheck(player);
            npc3.Npccheck(player);
            player.Collision(npc1.NpcRec);
            player.Collision(npc3.NpcRec);
            fontaine.CheckCollision(player);
            bush12.Bushcheck(player);
           
            bushY1.Bushcheck(player);
            bushY2.Bushcheck(player);
            bushY3.Bushcheck(player);
            bushY4.Bushcheck(player);
            bushY5.Bushcheck(player);
            bushY6.Bushcheck(player);
            bushY7.Bushcheck(player);
            bushY8.Bushcheck(player);
            bushY9.Bushcheck(player);
            bushY10.Bushcheck(player);
            bushY11.Bushcheck(player);
            bushY12.Bushcheck(player);
            bush1.Bushcheck(player);
            bush2.Bushcheck(player);
            bush3.Bushcheck(player);
            bush4.Bushcheck(player);
            bush5.Bushcheck(player);
            bush6.Bushcheck(player);
            bush7.Bushcheck(player);
            bush8.Bushcheck(player);
            bush9.Bushcheck(player);
            bush10.Bushcheck(player);
            bush11.Bushcheck(player);
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
            chicken.CheckCollision(player);
            player.Collision(chicken.ObjRecDown);
            player.Collision(kid.dekRec);
            player.Collision(kid.dekLadyRec);
            
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            if (player.PlayerRec.Intersects(kid.DekTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(kid.DekTalkRec))
            {
                kid.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    kid.row = 3;
                }
                if (player.row == 2)
                {
                    kid.row = 2;
                }
                if (player.row == 3)
                {
                    kid.row = 1;
                }
                if (player.row == 4)
                {
                    kid.row = 4;
                }
                Data.Oldms = Data.ms;
            }

            kid.Update(gameTime);
            if (player.PlayerRec.Intersects(npc1.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc1.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc3.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc3.talk = true;
                Data.CanControl = false;
            }

        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            // จุดเปลี่ยนแมพ
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 5);
            npc1.Draw(_spriteBatch, 0, 2);
            npc3.Draw(_spriteBatch, 3, 1);
            bush12.Drawbig(_spriteBatch);
            
            chicken.Draw(_spriteBatch);
            fontaine.Draw(_spriteBatch);
            bushY1.Drawbig(_spriteBatch);
            bushY2.Drawbig(_spriteBatch);
            bushY3.Drawbig(_spriteBatch);
            bushY4.Drawbig(_spriteBatch);
            bushY5.Drawbig(_spriteBatch);
            bushY6.Drawbig(_spriteBatch);
            bushY7.Drawbig(_spriteBatch);
            bushY8.Drawbig(_spriteBatch);
            bushY9.Drawbig(_spriteBatch);
            bushY10.Drawbig(_spriteBatch);
            bushY11.Drawbig(_spriteBatch);
            bushY12.Drawbig(_spriteBatch);
            bush1.Drawbig(_spriteBatch);
            bush2.Drawbig(_spriteBatch);
            bush3.Drawbig(_spriteBatch);
            bush4.Drawbig(_spriteBatch);
            bush5.Drawbig(_spriteBatch);
            bush6.Drawbig(_spriteBatch);
            bush7.Drawbig(_spriteBatch);
            bush8.Drawbig(_spriteBatch);
            bush9.Drawbig(_spriteBatch);
            bush10.Drawbig(_spriteBatch);
            bush11.Drawbig(_spriteBatch);
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


           

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j <14; j++)
                {

                    _spriteBatch.Draw(floor, new Vector2(0+80, 0+80) + Data.PosTileY*j+ Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                }
            }

           
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Data.Q1Finish = true;
            }
            // npc1.Draw(_spriteBatch);
            // npc1.Draw(_spriteBatch);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene3;
                Data.Plypos.Y = 720 - 80;
                kid.row = 1;
            }
            if (Data.Q1Finish == true)
            {
                if (player.PlayerRec.Intersects(Data.TpRec2))
                {
                    Data.CurrentState = Data.Scenes.scene5;
                    Data.Plypos.Y = 0 + 10;
                    kid.row = 1;
                }
            }
            // วาดเด็กถ้าเควสยังไม่เสด
            if (Data.Q1Finish == false)
            {
                kid.Draw(_spriteBatch);
            }
            if (kid.Talk == true)
            {
                kid.DekDialog(_spriteBatch);
            }

            // if(pickMelon == false)
            // {
            //     melonRec = new Rectangle(50, 50, Data.Watermelon.item.Width, Data.Watermelon.item.Height);
            //     _spriteBatch.Draw(Data.Watermelon.item,new Vector2(50,50), new Rectangle(0, 0, Data.Watermelon.item.Width, Data.Watermelon.item.Height), Color.White,0,Vector2.Zero,1,0,0.3f);
            //}
            sandbox.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            if (npc1.talk == true)
            {
                npc1.Dialog(_spriteBatch);
            }
            if (npc3.talk == true)
            {
                npc3.Dialog(_spriteBatch);
            }
            Data.inv.Draw(_spriteBatch);
        }
    }
}
