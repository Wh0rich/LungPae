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
        AnimatedTexture DekLady;
       
        Dialog dialogsad,dialoghappy,dialogPae;
        Dialog LadyBox, LadyHappy;
        Vector2 DekPos,DekLadyPos;

        public Rectangle dekRec,dekLadyRec,DekTalkRec;

        public int row = 1;

        private const int Frame = 1;
        private const int FramePerSec = 1;
        private const int FrameRow = 4;
        private const float Rotation = 0;
        private float Scale = 0.5f;
        private const float Depth = 0.4f;
        
        public bool Talk,TalkLady;
        public Kid() 
        {
            DekPos = new Vector2(Data.ScreenW/2,Data.ScreenH-60);
            DekLadyPos = new Vector2(Data.ScreenW / 2+45, Data.ScreenH-55);
            Dek = new AnimatedTexture(Vector2.Zero,Rotation,Scale,Depth);
            DekLady = new AnimatedTexture(Vector2.Zero,Rotation,Scale,Depth);
            dialogsad = new Dialog();
            dialoghappy = new Dialog();
            dialogPae = new Dialog();
            LadyBox = new Dialog();
            LadyHappy = new Dialog();
        }

        public void Load(ContentManager content)
        {
            
            Dek.Load(content,"Kid1",Frame,FrameRow,FramePerSec);
            DekLady.Load(content, "Kid2",Frame,FrameRow,FramePerSec);
            dialogsad.LoadContent(content,"Kid1Box_Sad");
            dialoghappy.LoadContent(content, "Kid1Box_Happy");
            LadyBox.LoadContent(content, "Kid2Box_Sad");
            LadyHappy.LoadContent(content, "Kid2Box_Happy");
            dialogPae.LoadContent(content);
            Scale = Scale * 100;
        }
        public void Update(GameTime gameTime)
        {
            if (Data.Q1Finish == true)
            {
                dekRec = new Rectangle(-20000, 0, 1, 1);
                dekLadyRec = new Rectangle(-20000, 0, 1, 1);
            }
        }
       
        public void Draw(SpriteBatch batch) 
        {
            //if(Data.Quest1 == true||Data.Panties == true)
            //{
           
                Dek.DrawFrame(batch, DekPos, row);
                DekLady.DrawFrame(batch, DekLadyPos, row);
                dekRec = new Rectangle((int)DekPos.X, (int)DekPos.Y + 15, (Dek.FrameWidth * (int)Scale) / 100, (Dek.FrameHeight * (int)Scale) / 100);
                dekLadyRec = new Rectangle((int)DekLadyPos.X, (int)DekLadyPos.Y + 11, (Dek.FrameWidth * (int)Scale) / 100 + 10, (Dek.FrameHeight * (int)Scale) / 100);
               DekTalkRec = new Rectangle((int)DekPos.X-30, (int)DekPos.Y - 30,120,80);


            //}
        }
      
        public void DekDialog(SpriteBatch batch)
        {
            //finish quest
            if (Talk == true && Data.Panties == true)
            {
                dialoghappy.DrawPerson(batch, "DekNoi");
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialoghappy.ChangeDialog("you really got it back.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialoghappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialoghappy.ChangeDialog("Thank you very much, Uncle.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialoghappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Talk = false;
                            Data.Quest1 = false;
                            Data.CanControl = true;
                            Data.Q1Finish = true;
                            Data.Panties = false;
                            DekPos = new Vector2(Data.ScreenW - 500, Data.ScreenH);
                            dekRec = new Rectangle(10000, 10000, 0, 0);
                            dekLadyRec = new Rectangle(10000, 10000, 0, 0);
                            Data.inv.RemoveItem(Data.Pantie);
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }

            // quest no finish
            if (Talk == true && Data.Quest1 == true && Data.Panties == false)
            {
                
                Data.ms = Mouse.GetState();
              
                switch (Data.DialogCount)
                {
                    case 0:
                        dialogsad.DrawPerson(batch, "DekNoi");
                        dialogsad.ChangeDialog("I had my pantie stolen by a stranger.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogsad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialogPae.Draw(batch);
                        dialogPae.ChangeDialog("What does that person look like?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogsad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:
                        dialogsad.DrawPerson(batch, "DekNoi");
                        dialogsad.ChangeDialog("Tall, wearing a purple shirt");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogsad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.DialogCount=0;
                        }
                        Data.Oldms = Data.ms;
                        break;

                }
                

            }

            //Give Quest
            if(Talk == true&&Data.Quest1 == false && Data.Panties == false)
            {
               
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        
                        LadyBox.DrawPerson(batch, "DekYing");
                        LadyBox.ChangeDialog("My friend's stuff was stolen by a stranger.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(LadyBox.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        LadyBox.DrawPerson(batch, "DekYing");
                        LadyBox.ChangeDialog("Will you help my friend?");
                        LadyBox.Answer("Definitely helps.", "No, I'm busy.");
                        LadyBox.DrawAns2(batch);
                        LadyBox.DrawAns2(batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(LadyBox.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(LadyBox.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                           
                            
                            Data.DialogCount = 7;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:
                        LadyHappy.DrawPerson(batch, "DekYing");
                        LadyHappy.ChangeDialog("Thanks, try talking to my friend.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(LadyHappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:
                        dialogPae.Draw(batch);
                        dialogPae.ChangeDialog("You went and talked to the boy.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogPae.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                   
                    case 4:
                        dialogsad.DrawPerson(batch, "DekNoi");
                        dialogsad.ChangeDialog("I had my pantie stolen by a stranger.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogsad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 5:
                        dialogPae.Draw(batch);
                        dialogPae.ChangeDialog("What does that person look like?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogsad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 6:
                        dialogsad.DrawPerson(batch, "DekNoi");
                        dialogsad.ChangeDialog("Tall, wearing a purple shirt");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogsad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.Quest1 = true;
                            Data.DialogCount = 0;
                        }
                        Data.Oldms = Data.ms;
                        break;
                     case 7:
                        LadyBox.DrawPerson(batch,"DekYing");
                        LadyBox.ChangeDialog("Heartless, this brother is not a real man.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(LadyBox.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount=0;
                            Talk = false;
                            Data.CanControl = true;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }

            }




        }
    }
}
