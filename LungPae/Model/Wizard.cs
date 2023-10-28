using lungpae;
using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LungPae.Model
{
    internal class Wizard
    {

        AnimatedTexture wizard;
        Dialog dialog,box,smile;
        Vector2 pos = new Vector2(100,150);
        public Rectangle wiTalkRec, wiRec, wiRecTop;
        float scale = 0.6f;
        public bool Talk = false;
        bool checkCollision = false;
        bool givequest = false;
        bool magic = false;
        public int row = 1;
        float temp;
        bool loop = false;
        bool full = false;
        public Wizard() 
        
        { 
            wizard = new AnimatedTexture(Vector2.Zero,0,scale,0.4f);
            dialog = new Dialog();
            box = new Dialog();
            smile = new Dialog();
            scale *= 100;
        }

        internal void Load(ContentManager Content)
        {
            wizard.Load(Content,"Wizard",1,5,0);
            dialog.LoadContent(Content);
            box.LoadContent(Content, "WizardBox");
            smile.LoadContent(Content, "WizardBox_Smile");
        }
        internal void Update(GameTime gameTime) 
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (magic == true)
            {
                temp += elapsed;

            }

            if (checkCollision == true)
            {
                wizard.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                wizard.Depth = 0.4f;
            }


        }

        internal void Draw(SpriteBatch Batch)
        {
            if(Data.Sweater.pickup ==true&&Data.Glasses.pickup == true && Data.Joy.pickup == true)
            {
                full = true;
            }
            if (Talk == true && Data.Quest5 == false && givequest==false)
            {
                Data.ms = Mouse.GetState();
                dialog.Draw(Batch);
                dialog.ChangeDialog("I'm just a guy who cosplays.");
                dialog.Answer("Believe him", "This wizard really is a liar");
                dialog.DrawAns(Batch);

                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talk = false;
                    Data.CanControl = true;
                }
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Data.Quest5 = true;
                    givequest = true;
                }
                Data.Oldms = Data.ms;
            }
            if (Talk == true && Data.Quest5 == true && givequest == true && Data.Quest5Finish == false && loop == false )
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:

                        smile.DrawPerson(Batch, "Wizard");
                        smile.ChangeDialog("What is your name, young man?");
                        smile.Answer("I am Pae, the man who will become the King of Laab.", "My name is Pae. The world's number one laab lover.");
                        smile.DrawAns2(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("This guy is really crazy.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("What do you want me to help with?");
                        box.Answer("I think you can do something about this road problem.", "Please help me find the best laab.");
                        box.DrawAns2(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 6;
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:

                        smile.DrawPerson(Batch, "Wizard");
                        smile.ChangeDialog("This guy really likes laab.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("But I don't really like it. It's both spicy and smelly.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 5:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("What do you want me to help with?");
                        box.Answer("I think you can do something about this road problem.");
                        box.DrawAns1(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 6:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("Yes, but there is a condition that you must find 3 things.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 7:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("I have to use it to do magic.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 8:

                        box.DrawPerson(Batch, "Wizard");
                        box.ChangeDialog("I want a white sweater,Game joystick and Glasses.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.CanControl = true;
                            givequest = false;
                            Talk = false;
                            loop = true;
                        }
                        Data.Oldms = Data.ms;
                        break;

                }
            }
            
                if (Talk == true && loop == true && Data.Quest5 == true && full ==false)
                {
                    Data.ms = Mouse.GetState();
                    box.DrawPerson(Batch, "Wizard");
                    box.ChangeDialog("I want a white sweater,Game joystick and Glasses.");
                    if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                    {
                        Data.CanControl = true;
                        Talk = false;
                         
                    }
                    Data.Oldms = Data.ms;

                }
                if (Talk == true && givequest == false && Data.Quest5 == true && full == true)
                {
                    Data.ms = Mouse.GetState();
                    switch (Data.DialogCount)
                    {
                        case 0:
                            smile.DrawPerson(Batch, "Wizard");
                            smile.ChangeDialog("Thanks");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount++;
                                Data.inv.RemoveItem(Data.Sweater);
                                Data.inv.RemoveItem(Data.Glasses);
                            }
                            Data.Oldms = Data.ms;
                            break;
                        case 1:
                            smile.DrawPerson(Batch, "Wizard");
                            smile.ChangeDialog("Actually, I only use glasses to cast spells.\nThe rest I keep for myself.");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(smile.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount++;
                            }
                            Data.Oldms = Data.ms;
                            break;
                        case 2:

                            box.DrawPerson(Batch, "Wizard");
                            box.ChangeDialog("This guy is really stupid and easy to trick.");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount++;
                            }
                            Data.Oldms = Data.ms;
                            break;
                        case 3:

                            box.DrawPerson(Batch, "Wizard");
                            box.ChangeDialog("But I keep my promise");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount=0;
                                magic = true;
                                Talk = false;
                            }
                            Data.Oldms = Data.ms;
                            break;

                    }

                   

                }

                if (magic == false)
                {
                    wizard.DrawFrame(Batch, pos, row);
                }
                if (magic == true)
                {
                    wizard.DrawFrame(Batch, pos, 5);
                    if (temp > 2)
                    {
                        Data.Quest5Finish = true;
                        Data.CanControl = true;
                    }
                }
                if (Data.Quest5Finish == false)
                {
                    wiRec = new Rectangle((int)pos.X, (int)pos.Y + 30, wizard.FrameWidth * (int)scale / 100, wizard.FrameHeight * (int)scale / 100 + 20);
                    wiRecTop = new Rectangle((int)pos.X, (int)pos.Y, wizard.FrameWidth * (int)scale / 100, (wizard.FrameHeight * (int)scale / 100) - 40);
                    wiTalkRec = new Rectangle((int)pos.X - 20, (int)pos.Y - 20, wizard.FrameWidth * (int)scale / 100 + 40, wizard.FrameHeight * (int)scale / 100 + 40);
                }
                if (Data.Quest5Finish == true)
                {
                    pos = new Vector2(50000,-20000);
                    wiRec = new Rectangle(-20000, 0, 1, 1);
                    wiRecTop = new Rectangle(-20000, 0, 1, 1);
                    wiTalkRec = new Rectangle(-20000, 0, 1, 1);
                }
            
        }

        internal void WiCheck(Player player)
        {
            if (wiRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;

            }
            player.Collision(wiRec);
        }


    }
}
