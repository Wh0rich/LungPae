using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;

using LungPae.Model;
using System.Threading;
using System.Reflection.Metadata;

namespace LungPae.Scenes
{
    internal class Scene1 : Component
    {
        Texture2D grass,floor;
        Chin chin;
        NPC npc1,npc2,npc3;
        Player player;
        SpriteFont Font;
        Building obj,seven;
        Dialog dialog;
        

        
        
        bool talk = false;
        int speed = 1;
        public Scene1()
        {
            chin = new Chin();
            
            Data.Plypos = new Vector2(0, 450);
            obj = new Building(new Vector2(60, 50), 0.3f);
            seven = new Building(new Vector2(700,100),1);
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(490, 200));
            npc2 = new NPC(0, 0.6f, 0.5f, new Vector2(1200, 250));
            npc3 = new NPC(0, 0.6f, 0.5f, new Vector2(800, 400));
            dialog = new Dialog();
            player = new Player();
            

        }
        internal override void LoadContent(ContentManager Content)
        {
            chin.Load(Content);
            obj.Load(Content, "House1");
            seven.Load(Content, "7-11");
            npc1.Load(Content, "NPC", 4, 4, 0);
            npc2.Load(Content,"NPC",4,4, 0);
            npc3.Load(Content, "NPC", 4, 4, 0);
            dialog.LoadContent(Content);
            grass = Content.Load<Texture2D>("grass");
            floor = Content.Load<Texture2D>("Floor");
            player.LoadContent(Content);
            Data.Pantie.Load(Content, "Pantie");

        }
        internal override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            npc1.Update(gameTime);
            npc2.Update(gameTime);
            npc3.Update(gameTime);
            player.Update(gameTime);
            chin.Update(gameTime);
            dialog.Update(gameTime);
            seven.CheckCollision(player);
            obj.CheckCollision(player);
            player.Collision(obj.ObjRecDown);
            player.Collision(seven.ObjRecDown);
            player.Collision(npc1.NpcRec);
            player.Collision(npc2.NpcRec);
            player.Collision(npc3.NpcRec);
            player.Collision(chin.chinRec);
            chin.Chincheck(player);
            npc1.Npccheck(player);
            npc2.Npccheck(player);
            npc3.Npccheck(player);

            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);

            //ชนชินแล้วหยุด
           if(player.PlayerRec.Intersects(chin.chinRec)|| player.PlayerRec.Intersects(chin.chinRecTop))
            {
                chin.Stop();
                chin.speed = 0;
               
            }
            else
            {
                chin.speed = 1;
                if (chin.row == 3)
                {
                    chin.speed = -1;
                }
                chin.Play();
            }
            if (player.PlayerRec.Intersects(npc1.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            { 
                npc1.talk = true;
                Data.CanControl= false;
            }
            if (player.PlayerRec.Intersects(npc2.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc2.NpcRecTalk))
            {
                npc2.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc3.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc3.NpcRecTalk))
            {
                npc3.talk = true;
                Data.CanControl = false;
            }


            //ให้ชินหันหน้ามาหาตอนพูด
            if (player.PlayerRec.Intersects(chin.chinRecTalk) &&Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(chin.chinRecTalk))
              {
                dialog.Update(gameTime);
                chin.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    chin.row = 3;
                }
                if (player.row == 2)
                {
                    chin.row = 2;
                }
                if (player.row == 3)
                {
                    chin.row = 1;
                }
                if (player.row == 4)
                {
                    chin.row = 4;
                }
                
            } 
            if(chin.give == true)
            {
                Data.inv.AddItem(Data.Pantie);
                chin.give = false;
            }
           
           
        }
       
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            for(int i = 0;i<Data.ScreenW/grass.Width;i++)
            {
                for(int j =0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i,grass.Height * j),null, Color.White,0,Vector2.Zero,1,SpriteEffects.None,0f);
                }
                
            }
            
            _spriteBatch.Draw(floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - floor.Height),null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);

            npc1.DrawFrame(_spriteBatch,1);
            npc2.DrawFrame(_spriteBatch, 2);
            npc3.DrawFrame(_spriteBatch, 3);


            obj.Draw(_spriteBatch);
            seven.Draw(_spriteBatch);
            chin.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 5);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene2;
                Data.Plypos.Y = 0 + 10;
            }
            if (chin.Talk == true && Data.Quest1 == true)
            {
                chin.ChinDialog(_spriteBatch);
               
            }
             if (chin.Talk == true && Data.Quest1 == false)
             {
               chin.ChinDialog(_spriteBatch); 
             }
            if(npc1.talk == true)
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