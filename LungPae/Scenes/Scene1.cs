﻿using Microsoft.Xna.Framework;
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
using Microsoft.Xna.Framework.Audio;


namespace LungPae.Scenes
{
    internal class Scene1 : Component
    {
        List<SoundEffect> soundEffects = new List<SoundEffect>();
        List<SoundEffect> instance = new List<SoundEffect>();
        Texture2D grass,floor;
        Chin chin;
        NPC npc1,npc3;
        Player player;
        SpriteFont Font;
        Building obj,seven,house2,house3;
        Dialog dialog;
        material bin,bin2,bin3,bin4;
        Tree tree1, tree2;
        Bush Bigbush1, Bigbush2, Smallbush1, Smallbush2, Smallbush3, Smallbush4;


        bool talk = false;
        int speed = 1;
        public Scene1()
        {
            chin = new Chin();
            
            Data.Plypos = new Vector2(0, 450);
            obj = new Building(new Vector2(40,20), 0.3f);
            house2 = new Building(new Vector2(0, 480), 0.5f);
            house3 = new Building(new Vector2(1020, 450), 0.3f);
            seven = new Building(new Vector2(700,30),0.3f);
            tree1 = new Tree(new Vector2(1050, 20), 0.2f);
            tree2 = new Tree(new Vector2(552, 20), 0.2f);
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(490, 200));
            
            npc3 = new NPC(0, 0.6f, 0.5f, new Vector2(800, 400));
            dialog = new Dialog();
            player = new Player();
            bin = new material(new Vector2 (1200,125),1f);
            bin2 = new material(new Vector2(220,305), 1f);
            bin3 = new material(new Vector2(1000, 320), 1f);
            bin4 = new material(new Vector2(320, 135), 1f);
            Bigbush1 = new Bush(new Vector2(0, 370), 0.25f);
            Bigbush2 = new Bush(new Vector2(1150, 300),0.25f);
            Smallbush1 = new Bush(new Vector2(300,655),0.25f);
            Smallbush2 = new Bush(new Vector2(400,655),0.25f);
            Smallbush3 = new Bush(new Vector2(800,655),0.25f);
            Smallbush4 = new Bush(new Vector2(900,655),0.25f);

        }
        internal override void LoadContent(ContentManager Content)
        {

            soundEffects.Add(Content.Load<SoundEffect>("Chin_Do you have something with me"));

            for (int i = 0; i < 1; i++)
            {
                instance.Add(soundEffects[i]);
                instance[i].CreateInstance();
            }
            chin.Load(Content);
            obj.Load(Content, "House1");
            seven.Load(Content, "7-11");
            tree1.Load(Content);
            tree2.Load(Content);
            house2.Load(Content, "house-2");
            house3.Load(Content, "House3 (1)");
            npc1.Load(Content, "NPC", 4, 4, 0);
            
            npc3.Load(Content, "NPC", 4, 4, 0);
            bin.Load(Content, "recycleBin");
            bin2.Load(Content, "recycleBin");
            bin3.Load(Content, "recycleBin");
            bin4.Load(Content, "recycleBin");

            Smallbush1.Load(Content);
            Smallbush2.Load(Content);
            Smallbush3.Load(Content);
            Smallbush4.Load(Content);

            Bigbush1.Load(Content);
            Bigbush2.Load(Content);
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
            
            npc3.Update(gameTime);
            player.Update(gameTime);
            chin.Update(gameTime);
            player.Collision(house2.ObjRecDown);
            player.Collision(house3.ObjRecDown);

            Bigbush1.Bushcheck(player);
            Bigbush2.Bushcheck(player);
            Smallbush1.Bushcheck(player);
            Smallbush2.Bushcheck(player);
            Smallbush3.Bushcheck(player);
            Smallbush4.Bushcheck(player);
            seven.CheckCollision(player);
            house2.CheckCollision(player);
            house3.CheckCollision(player);

            tree1.Treecheck(player);
            tree2.Treecheck(player);

            obj.CheckCollision(player);
            player.Collision(obj.ObjRecDown);
            player.Collision(seven.ObjRecDown);
            player.Collision(npc1.NpcRec);
            
            player.Collision(npc3.NpcRec);

            player.Collision(chin.chinRec);
            chin.Chincheck(player);
            npc1.Npccheck(player);
            
            npc3.Npccheck(player);
            bin.CheckCollision(player);
            bin2.CheckCollision(player);
            bin3.CheckCollision(player);
            bin4.CheckCollision(player);
            
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
           
            if (player.PlayerRec.Intersects(npc3.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc3.NpcRecTalk))
            {
                npc3.talk = true;
                Data.CanControl = false;
            }


            //ให้ชินหันหน้ามาหาตอนพูด
            if (player.PlayerRec.Intersects(chin.chinRecTalk) &&Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(chin.chinRecTalk))
              {
                
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
                instance[0].Play();
            } 
            if(chin.give == true)
            {
                Data.inv.AddItem(Data.Pantie);
                chin.give = false;
            }
            Console.WriteLine(Bigbush1.BbigRecTop);
           
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
            bin.Draw(_spriteBatch);
            bin2.Draw(_spriteBatch);
            bin3.Draw(_spriteBatch);
            bin4.Draw(_spriteBatch);
            for (int i = 0; i < 10; i++)
            {
                _spriteBatch.Draw(floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(floor, new Vector2(Data.ScreenW / 2 - 80, Data.ScreenH - floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(floor, new Vector2(Data.ScreenW / 2 - 40, Data.ScreenH - floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            npc1.DrawFrame(_spriteBatch,1);
            
            npc3.DrawFrame(_spriteBatch, 3);


            obj.Draw(_spriteBatch);
            Smallbush1.Drawsmall(_spriteBatch);
            Smallbush2.Drawsmall(_spriteBatch);
            Smallbush3.Drawsmall(_spriteBatch);
            Smallbush4.Drawsmall(_spriteBatch);

            Bigbush2.Drawbig(_spriteBatch);
            Bigbush1.Drawbig(_spriteBatch);
            house2.Draw(_spriteBatch);
            
            house3.Draw(_spriteBatch);
            tree1.Draw(_spriteBatch);
            tree2.Draw(_spriteBatch);
            seven.Draw(_spriteBatch);
            chin.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2-80, Data.ScreenH - 5, 100, 5);
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
           
            if (npc3.talk == true)
            {
                npc3.Dialog(_spriteBatch);
            }
        }
    }
}