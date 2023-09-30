using lungpae;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LungPae.Model;
using LungPae.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LungPae.Model
{
    internal class Kid
    {
        AnimatedTexture Dek;
        Texture2D Deksad;
        Dialog dialog;
        Vector2 DekPos;

        public Rectangle dekRec;

        public int row = 1;

        private const int Frame = 1;
        private const int FramePerSec = 1;
        private const int FrameRow = 4;
        private const float Rotation = 0;
        private float Scale = 0.5f;
        private const float Depth = 0.4f;

        public bool Talk;
        public Kid() 
        {
            DekPos = new Vector2(1245,345);
            Dek = new AnimatedTexture(Vector2.Zero,Rotation,Scale,Depth);
            dialog = new Dialog();
        }

        public void Load(ContentManager content)
        {
            
            Dek.Load(content,"Kid1",Frame,FrameRow,FramePerSec);
            Deksad = content.Load<Texture2D>("Kid1_Sad");
            dialog.LoadContent(content);
        }
        public void Update(GameTime gameTime)
        {
            dekRec = new Rectangle((int)DekPos.X, (int)DekPos.Y+7, Dek.FrameWidth, Dek.FrameHeight-7);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
           
            dialog.Update(gameTime);
            
        }
        public void Draw(SpriteBatch batch) 
        {
            //if(Data.Quest1 == true||Data.Panties == true)
            //{
                Dek.DrawFrame(batch, DekPos, row);
            //}
            
            
        }
        public void DekDialog(SpriteBatch batch)
        {
            //finish quest
            if(Talk == true && Data.Panties == true)
            {
                dialog.Draw(batch);
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                { 
                    case 0:
                        dialog.ChangeDialog("Thank you B R O T H E R");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.ChangeDialog("When we meet again, I will treat you a Laab.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Talk = false;
                            Data.Quest1 = false;
                            Data.CanControl = true;
                            Data.Q1Finish = true;
                            Data.Panties = false;
                            DekPos = new Vector2(Data.ScreenW-500,Data.ScreenH);
                            Data.inv.RemoveItem(Data.Pantie);
                        }
                        Data.Oldms = Data.ms;
                        break; 
                }
            }

            // quest no finish
            if (Talk == true && Data.Quest1 == true && Data.Panties == false )
            {
                dialog.Draw(batch);
                Data.ms = Mouse.GetState();
                dialog.ChangeDialog("The villain wore a purple shirt and jeans");
                    if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                    {
                    Talk = false;
                    Data.CanControl = true;
                    }
                    Data.Oldms = Data.ms;
                    
                }
            //Give Quest
            if(Talk == true&&Data.Quest1 == false && Data.Panties == false)
            {
                dialog.Draw(batch);
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("Im sadd");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.ChangeDialog("My panties were stolen.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                            
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:
                        
                        dialog.ChangeDialog("I can't go home without my pantie");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:
                        
                        dialog.ChangeDialog("The villain wore a purple shirt and jeans");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:
                        dialog.ChangeDialog("Could you bring my panties back please");
                        dialog.Answer("Sure","Nah");
                        dialog.DrawAns(batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.Quest1 = true;
                            Data.DialogCount = 0;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.DialogCount = 0;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }




        }
    }
}
