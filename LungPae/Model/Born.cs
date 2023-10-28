using lungpae;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LungPae.Core;
using System.Runtime.CompilerServices;

namespace LungPae.Model
{
    internal class Born
    {
        AnimatedTexture born;
        Dialog dialog,smile, noglasses;
        public Rectangle bornTalkRec, bornRec, bornRecTop;
        Vector2 bornpos;
        public int speed;
        public int row = 3;
        public bool Talk = false;
        float Scale = 0.6f;
        bool checkCollision = false;
        bool give = false;
        int prvrow;

        public Born()
        {
            born = new AnimatedTexture(Vector2.Zero,0,Scale,0.4f);
            dialog = new Dialog();
            smile = new Dialog();
            noglasses = new Dialog();
            Scale *= 100;
        }

        internal void Load(ContentManager Content)
        {
            born.Load(Content, "Born", 4, 6, 4);
            Data.Glasses.Load(Content,"glasses");
            dialog.LoadContent(Content,"BornBox");
            smile.LoadContent(Content, "BornBox_Smile");
            noglasses.LoadContent(Content, "BornBox_noglasses");
            bornpos = new Vector2(140, 200);
            speed = 1;
        }
        internal void Update(GameTime gameTime)
        {
            
            if (give == false)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                
                bornRec = new Rectangle((int)bornpos.X, (int)bornpos.Y + 30, born.FrameWidth * (int)Scale / 100, born.FrameHeight * (int)Scale / 100+10);
                bornRecTop = new Rectangle((int)bornpos.X, (int)bornpos.Y, born.FrameWidth * (int)Scale / 100, (born.FrameHeight * (int)Scale / 100) - 60);
                bornTalkRec = new Rectangle((int)bornpos.X-10, (int)bornpos.Y, born.FrameWidth * (int)Scale / 100+20, (born.FrameHeight * (int)Scale / 100)+10);
                if (Data.CanControl == true)
                { 
                    bornpos.X += speed;
                    
                    born.UpdateFrame(elapsed);
                    prvrow = row;
                    if (bornpos.X < 70)
                    {
                        speed = 1;
                        row = 3;

                    }
                    if (bornpos.X > 210)
                    {
                        speed = -1;
                        row = 4;

                    }
                    if (checkCollision == true)
                    {
                        born.Depth = 0.6f;

                        checkCollision = false;
                    }
                    else
                    {
                        born.Depth = 0.4f;
                    }
                    if (Data.CanControl == false)
                    {
                        speed = 0;
                        born.Stop();
                        born.UpdateFrame(0);
                    }
                }
            }


            if (give == true)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

                bornRec = new Rectangle((int)bornpos.X, (int)bornpos.Y + 30, born.FrameWidth * (int)Scale / 100, born.FrameHeight * (int)Scale / 100 + 10);
                bornRecTop = new Rectangle((int)bornpos.X, (int)bornpos.Y, born.FrameWidth * (int)Scale / 100, (born.FrameHeight * (int)Scale / 100) - 60);
                bornTalkRec = new Rectangle((int)bornpos.X - 10, (int)bornpos.Y, born.FrameWidth * (int)Scale / 100 + 20, (born.FrameHeight * (int)Scale / 100) + 10);
                if (Data.CanControl == true)
                {
                    
                    if (row == 3)
                    {
                        row = 5;
                    }
                    if (row == 4)
                    {
                        row = 6;
                    }
                    bornpos.X += speed;
                    born.UpdateFrame(elapsed);
                    prvrow = row;
                    
                    if (bornpos.X < 70)
                    {
                        speed = 1;
                        row = 5;

                    }
                    if (bornpos.X > 210)
                    {
                        speed = -1;
                       row = 6;

                    }
                    if (checkCollision == true)
                    {
                        born.Depth = 0.6f;

                        checkCollision = false;
                    }
                    else
                    {
                        born.Depth = 0.4f;
                    }
                    if (Data.CanControl == false)
                    {
                        if (row == 3)
                        {
                            row = 5;
                        }
                        if (row == 4)
                        {
                            row = 6;
                        }
                        speed = 0;
                        born.Stop();
                        if(row == 1)
                        {
                         born.UpdateFrame(1);
                        }
                        else
                        {
                            born.UpdateFrame(0);
                        }
                        
                    }
                }
            }


        }
        internal void Draw(SpriteBatch Batch )
        {
            if(Talk == true && give==false)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.DrawPerson(Batch,"Born");
                        dialog.ChangeDialog("I'm Born,Mathematician Olympiad");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("You want my glasses?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                        
                    case 2:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Please answer these questions\nIf you answer correctly,take my glasses");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:
                        smile.DrawPerson(Batch, "Born");
                        smile.ChangeDialog("But if it's wrong, your mother will see me tonight");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Pythagoras' formula is ?");
                        dialog.Answer("c^2 = (a^2) + (b^2)", "s = ut + 1/2a(t^2)", "2*PI*r");
                        dialog.DrawAns3(Batch);
                        
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 14;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 14;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 5:
                        smile.DrawPerson(Batch, "Born");
                        smile.ChangeDialog("That's right.You're Teacher Jaew's disciple?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 6:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Next question.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 7:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("What is a Bezier Curve?");
                        dialog.Answer("Speaking northern language", "Computer graphics curves", "Techniques for lifting motorcycle wheels");
                        dialog.DrawAns3(Batch);

                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount =14;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 14;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 8:
                        smile.DrawPerson(Batch, "Born");
                        smile.ChangeDialog("Guessed the correct answer again?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 9:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Why don't you take a math class?");
                        dialog.Answer("Because I want to be Hogake", "Because I want to be Sala-Laab King", "Because it's mathematics I think you understand");
                        dialog.DrawAns3(Batch);

                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount = 14;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 14;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 10:
                        smile.DrawPerson(Batch, "Born");
                        smile.ChangeDialog("Your mother almost met me.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 11:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Last Question. Which teacher is the most handsome?");
                        dialog.Answer("Teacher Tan PixelProfessional", "Teacher M MonHunt Proplayer", "Teacher Noi Sacred hand Amen!");
                        dialog.DrawAns3(Batch);

                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount ++;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans3Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 12:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Your mother survived.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 13:
                        noglasses.DrawPerson(Batch, "Born");
                        noglasses.ChangeDialog("These are the glasses you want.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(noglasses.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.inv.AddItem(Data.Glasses);
                            Data.Glasses.pickup = true;
                            Data.Joy.pickup = true;
                            give = true;
                            Data.DialogCount = 0;
                            row = prvrow;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 14:
                        dialog.DrawPerson(Batch, "Born");
                        dialog.ChangeDialog("Don't forget to lock your door tonight");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
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

            if (Talk == true && give == true)
            {
                noglasses.DrawPerson(Batch, "Born");
                noglasses.ChangeDialog("Hello");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(noglasses.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                    row = prvrow;
                }
                Data.Oldms = Data.ms;
            }

            if (give == true)
            {
                if (row == 3)
                {
                    row = 5;
                }
                if (row == 4)
                {
                    row = 6;
                }
                if(row == 1)
                {
                    born.DrawFrame(Batch, 1 ,bornpos, row);
                }
            }

            born.DrawFrame(Batch,bornpos,row);
        }
        internal void Borncheck(Player player)
        {
            if (bornRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;
            }
            player.Collision(bornRec);
        }

        public void Play()
        {
            born.Play();
        }
        public void Stop()
        {
            born.Stop();
        }



    }
}
