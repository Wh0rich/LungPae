using Microsoft.Xna.Framework.Content;
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
    public class PorkShop
    {
        Building porkshop;
        Dialog dialog;
        
        Vector2 pos = new Vector2(0, 0);
        float Scale = 0.3f;
        public Rectangle TalkRec;
        public bool Talk = false;
        public PorkShop()
        {
            porkshop = new Building(pos,Scale);
            dialog = new Dialog();
            Scale *= 100;
        }
        public void Load(ContentManager Content)
        {
            porkshop.Load(Content,"PorkShop");
            Data.Pork.Load(Content,"Pork");
            dialog.LoadContent(Content);    
            TalkRec = new Rectangle((int)pos.X + 160, (int)pos.Y + (porkshop.obj.Height * (int)Scale / 100) / 2 - 40 + 50, 55,90);
        }
       public void Draw(SpriteBatch Batch)
       {
            porkshop.Draw(Batch);


            if (Talk == true && Data.QuestLaab == false)
            {
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                dialog.ChangeDialog("Closed, Please come back later");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                }
                Data.Oldms = Data.ms;
            }


            if (Talk == true && Data.Money == 0 && Data.QuestLaab == true && Data.Pork.pickup == false)
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
            if (Talk == true && Data.Money > 0&& Data.Pork.pickup == false &&Data.QuestLaab == true)
            {
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                dialog.ChangeDialog("Do you want to buy Pork?");
                dialog.Answer("Yes","NO");
                dialog.DrawAns(Batch);
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    if (Data.Cash3.pickup == true)
                    {
                        Data.inv.RemoveItem(Data.Cash3);
                        Data.Cash3.pickup = false;
                    }
                    
                    Data.inv.AddItem(Data.Pork);
                    Talk = false;
                    Data.Pork.pickup = true;
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
            if (Talk == true && Data.Pork.pickup == true)
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
            player.Collision(porkshop.ObjRecDown);
            porkshop.CheckCollision(player);
           
        }
    }
}
