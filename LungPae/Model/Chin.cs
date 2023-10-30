using lungpae;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using System.Runtime.CompilerServices;
using LungPae.Model;
using Microsoft.Xna.Framework.Audio;


namespace LungPae.Model
{
    internal class Chin 
    {
        List<SoundEffect> soundEffects = new List<SoundEffect>() ;
        List<SoundEffect> instance = new List<SoundEffect>();

        AnimatedTexture chin;
        Dialog dialog,dialoghappy,dialogBox;
        


        public Rectangle chinRec, chinRecTop,chinRecTalk;
        public Vector2 chinPos;
        public int speed;
        public int row = 1;
        int prvrow;
        bool checkCollision = false;


        private const int Frame = 4;
        private const int FramePerSec = 3;
        private const int FrameRow = 4;
        private const float Rotation = 0;
        private  float Scale = 0.6f;
        private float Depth = 0.5f; 

        public bool Talk = false;
        public bool give = false;
        

        public Chin()
        {
            
            chinPos = new Vector2(400,150);
            chin = new AnimatedTexture(Vector2.Zero ,Rotation,Scale,Depth);
            Scale = Scale * 100;
            dialog = new Dialog();
            dialoghappy = new Dialog();
            dialogBox = new Dialog();
        }

        internal void Load(ContentManager content)
        {
          chin.Load(content, "ChinPantiesThief", 4, 4, 3);
            dialoghappy.LoadContent(content, "ChinBox_Happy");
            dialogBox.LoadContent(content, "ChinBox");
            dialog.LoadContent(content);

            
            
            speed = 1;
            
        }
        internal void Update(GameTime gameTime)
        {
            
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            chinRec = new Rectangle((int)chinPos.X, (int)chinPos.Y + 30, chin.FrameWidth * (int)Scale / 100, chin.FrameHeight * (int)Scale / 100  );
            chinRecTop = new Rectangle((int)chinPos.X, (int)chinPos.Y, chin.FrameWidth * (int)Scale / 100, (chin.FrameHeight * (int)Scale / 100)-60);
            chinRecTalk = new Rectangle((int)chinPos.X, (int)chinPos.Y, chin.FrameWidth * (int)Scale / 100, (chin.FrameHeight * (int)Scale / 100));

            if (Talk == true)
            {
                speed = 0;
                chin.Stop();
                chin.UpdateFrame(0);
                
            }

            if (Data.CanControl == true)
            {
                chinPos.Y += speed;
                chin.Play();
                chin.UpdateFrame(elapsed);
                prvrow = row;
                if (chinPos.Y < 64)
                {
                    speed = 1;
                    row = 1;
                    
                }
                if (chinPos.Y > 299 )
                {
                    speed = -1;
                    row = 3;
                    
                }
                if (checkCollision == true)
                {
                    chin.Depth = 0.6f;
                   
                    checkCollision = false;
                }
                else
                {
                    chin.Depth = 0.4f;
                }
               
                

            }
            if(Data.CanControl == false)
            {
                speed = 0;
                chin.Stop();
                chin.UpdateFrame(0);
            }

            




        }
        internal void Chincheck(Player player)
        {
            if (chinRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;
            }
        }
        internal void Draw(SpriteBatch Batch)
        {
            chin.DrawFrame(Batch, chinPos,row);
           
        }
        //ขึ้นตอนพูด
        public void ChinDialog(SpriteBatch Batch)
        {
            // พูดแบบมีเควส
            if (Talk == true && Data.Quest1 == true&&Data.Panties == false) 
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("Do you have something with me?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("You said I stole panties?.\nIf it's right, will you come and take it back?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:
                        dialoghappy.DrawPerson(Batch, "Chin");
                        dialoghappy.ChangeDialog("So answer the question correctly");
                       
                       
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialoghappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                           Data.DialogCount++;

                        }
                        Data.Oldms = Data.ms;
                        break;
                   
                    case 3:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("Which province are we in now?");
                        dialogBox.Answer("Chiangrai", "Chiangmai", "Lampang");
                        dialogBox.DrawAns3(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                          Data.DialogCount=11;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount = 11;

                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:
                        dialoghappy.DrawPerson(Batch, "Chin");
                        dialoghappy.ChangeDialog("The answer to this question is still simple.\nThe next question will be more difficult.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialoghappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 5:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("What is the shape of the Chiangmai moat?");
                        dialogBox.Answer("Rectangle", "Triangle ", "Circle");
                        dialogBox.DrawAns3(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount = 11;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount = 11;

                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 6:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("Did you answer correctly again? How lucky?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 7:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("How about this question?\nHow many trash cans are there in the park?");
                        dialogBox.Answer("2", "3 ", "4");
                        dialogBox.DrawAns3(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount=11;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount = 11;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;

                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 8:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("Did you randomly answer correctly again?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 9:
                        dialogBox.DrawPerson(Batch, "Chin");
                        dialogBox.ChangeDialog("Who teaches the subject 958221?");
                        dialogBox.Answer("Teacher Tan PixelProfessional ", "Teacher M MonHunt Proplayer", "Teacher Noi Sacred hand Amen!");
                        dialogBox.DrawAns3(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount=11;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount = 11;

                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialogBox.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount ++;

                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 10:
                        dialoghappy.DrawPerson(Batch, "Chin");
                        dialoghappy.ChangeDialog("You're really talented. I'll give it back to you.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialoghappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.Panties = true;
                            Data.CanControl = true;
                            Data.DialogCount = 0;
                            give = true;
                            Data.Panties = true;
                            prvrow = row;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 11:
                        dialoghappy.DrawPerson(Batch, "Chin");
                        dialoghappy.ChangeDialog("This guy is really stupid. Go find a new answer.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialoghappy.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.DialogCount = 0;
                            row = prvrow;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }

            }
            //คุยตอนไม่มีเควส
            if(Talk == true && Data.Quest1 == false|| Data.Panties == true) 
            {
                dialog.Draw(Batch);
                dialog.ChangeDialog("Hello");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                    row = prvrow;
                }
                Data.Oldms = Data.ms;
            }
        }

        public void Play()
        {
            chin.Play();
        }
        public void Stop()
        {
            chin.Stop();
        }

        
    }
}
