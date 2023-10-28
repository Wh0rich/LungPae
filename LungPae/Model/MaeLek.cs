using lungpae;
using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LungPae.Model
{
    internal class MaeLek
    {
        AnimatedTexture lek;
        Dialog dialog,box,sad;
        public Rectangle lekTalkRec, lekRec, lekRecTop;

        Vector2 lekpos;
        int row = 1;
        public bool Talk = false;
        bool checkCollision = false;
        float Scale = 0.6f;
        public MaeLek()
        {
            lek = new AnimatedTexture(Vector2.Zero, 0, Scale, 0.4f);
            dialog = new Dialog();
            box = new Dialog();
            sad = new Dialog();
            Scale *= 100;
        }

        internal void Load(ContentManager Content)
        {
            lek.Load(Content, "MaeLek", 1, 4, 0);
            Data.Cash3.Load(Content, "cash3");
            dialog.LoadContent(Content);
            box.LoadContent(Content, "MaeLekBox");
            sad.LoadContent(Content, "MaeLekBox_Sad");
            lekpos = new Vector2(80, 290);
        }
        internal void Update(GameTime gameTime)
        {
            if (checkCollision == true)
            {
                lek.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                lek.Depth = 0.4f;
            }
        }

        internal void Draw(SpriteBatch Batch)
        {
            
            if (Talk == true && Data.Quest4== false)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:

                        box.DrawPerson(Batch,"Maelek");
                        box.ChangeDialog("Thank you for bringing my son here");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:

                        sad.DrawPerson(Batch, "Maelek");
                        sad.ChangeDialog("It looks like he passed out from food poisoning by\nlaab he bought yesterday");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(sad.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:

                        box.DrawPerson(Batch, "Maelek");
                        box.ChangeDialog("I think I'll make him some cooked laab to eat\nin case his symptoms get better");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:

                        box.DrawPerson(Batch, "Maelek");
                        box.ChangeDialog("Of course I will do it for you in return for\nbringing my son here");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                            
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:

                        box.DrawPerson(Batch, "Maelek");
                        box.ChangeDialog("Could you please help me buy Minched pork?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount ++;
                           
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 5:

                        dialog.Draw(Batch);
                        dialog.ChangeDialog("You're still confused. But you quickly agreed");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.CanControl = true;
                            Data.inv.AddItem(Data.Cash3);
                            Data.Money += 1;
                            Data.Cash3.pickup = true;
                            Data.Quest4 = true;
                            Talk = false;
                        }
                        Data.Oldms = Data.ms;
                        break;

                }
            }
            if (Talk == true && Data.Quest4 == true&&Data.Quest4Finish == false && Data.Pork.pickup == false)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:

                        box.DrawPerson(Batch, "Maelek");
                        box.ChangeDialog("The pork at the bottom of the chiang mai moat\nis very good quality");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount=0;
                            Talk = false;
                            Data.CanControl = true;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }
            if(Talk == true && Data.Quest4 == true && Data.Pork.pickup == true && Data.Quest4Finish == false)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:

                        box.DrawPerson(Batch, "Maelek");
                        box.ChangeDialog("I've got the pork. I'm going to start cooking now");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Talk = false;
                            Data.CurrentState = Data.Scenes.Blackscreen;
                            Data.inv.RemoveItem(Data.Pork);
                        }
                        Data.Oldms = Data.ms;
                        break;

                }
            }

            if (Data.QuestLaab == true&&Data.Quest4Finish == false)
            {
                lek.DrawFrame(Batch, lekpos, row);
                lekRec = new Rectangle((int)lekpos.X, (int)lekpos.Y + 30, lek.FrameWidth * (int)Scale / 100, lek.FrameHeight * (int)Scale / 100 + 20);
                lekRecTop = new Rectangle((int)lekpos.X, (int)lekpos.Y, lek.FrameWidth * (int)Scale / 100, (lek.FrameHeight * (int)Scale / 100) - 40);
                lekTalkRec = new Rectangle((int)lekpos.X-20, (int)lekpos.Y-20, lek.FrameWidth * (int)Scale / 100+40, lek.FrameHeight * (int)Scale / 100+40);
            }
            if(Data.Quest4Finish == true)
            {
                
                lekRec = new Rectangle(-20000,0,1,1);
                lekRecTop = new Rectangle(-20000, 0, 1, 1);
                lekTalkRec = new Rectangle(-20000, 0, 1, 1);
            }

        }
        internal void MaeLekCheck(Player player)
        {
            if (lekRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;

            }
            player.Collision(lekRec);
        }

    }
}
