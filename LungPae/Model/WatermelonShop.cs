﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using LungPae.Core;
using Microsoft.Xna.Framework.Input;

namespace LungPae.Model
{
    public class WatermelonShop
    {
        Building melonShop;
        Dialog dialog;

        Vector2 pos = new Vector2(800, -35);
        float Scale = 0.3f;
        public Rectangle TalkRec;
        public bool Talk = false;
        public WatermelonShop()
        {
            melonShop = new Building(pos, Scale);
            dialog = new Dialog();
            Scale *= 100;
        }
        public void Load(ContentManager Content)
        {
            melonShop.Load(Content, "WatermelonShop");
            Data.Watermelon.Load(Content,"watermelon");
            dialog.LoadContent(Content);
            TalkRec = new Rectangle((int)pos.X + 175, (int)pos.Y + (melonShop.obj.Height * (int)Scale / 100) / 2 +80, 58, 70);
        }
        public void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
        }
        public void Draw(SpriteBatch Batch)
        {
            melonShop.Draw(Batch);
            if (Talk == true && Data.Money == 0 && Data.Watermelon.pickup == false)
            {
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                dialog.ChangeDialog("You have no money to buy anything");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                }
                Data.Oldms = Data.ms;
            }
            if (Talk == true && Data.Money > 0 && Data.Watermelon.pickup == false)
            {
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                dialog.ChangeDialog("Do you want to buy Watermelon?");
                dialog.Answer("Yes", "NO");
                dialog.DrawAns(Batch);
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    if (Data.Cash3.pickup == true)
                    {
                        Data.inv.RemoveItem(Data.Cash3);
                        Data.Cash3.pickup = false;
                    }
                    else if(Data.Cash2.pickup == true)
                    {
                        Data.inv.RemoveItem(Data.Cash2);
                        Data.Cash2.pickup = false;
                    }
                    else if (Data.Cash.pickup == true)
                    {
                        Data.inv.RemoveItem(Data.Cash);
                        Data.Cash.pickup = false;
                    }
                    Data.inv.AddItem(Data.Watermelon);
                    Talk = false;
                    Data.Watermelon.pickup = true;
                    Data.watermelon = true;
                    Data.CanControl = true;
                    Data.Money -= 1;
                }
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                }
                Data.Oldms = Data.ms;

            }
            if (Talk == true && Data.Watermelon.pickup == true)
            {
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                dialog.ChangeDialog("SOLD OUT");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                }
                Data.Oldms = Data.ms;
            }


        }

        internal void CheckCollision(Player player)
        {
            player.Collision(melonShop.ObjRecDown);
            melonShop.CheckCollision(player);

        }
    }
}
