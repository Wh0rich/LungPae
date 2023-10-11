using lungpae;
using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LungPae.Model
{
    internal class TAE
    {
        public AnimatedTexture tae;
        Dialog dialog;
        Vector2 Pos;
        public Rectangle taeRec, taeRecTop, taeRecTalk;
        public bool Talktae = false;
        public bool checkCollision = false;
        float Scale = 0.8f;
        public int row = 1;
        public TAE()
        {
            tae = new AnimatedTexture(Vector2.Zero,0,Scale,0.4f);
            dialog = new Dialog();
        }
        internal void Load(ContentManager Content)
        {
            tae.Load(Content, "TAE", 1, 5, 1);
            Scale *= 100;
            Pos = new Vector2(300,50);
            dialog.LoadContent(Content);
        }
        internal void Update (GameTime gameTime)
        {
            taeRec = new Rectangle((int)Pos.X, (int)Pos.Y + 50, tae.FrameWidth * (int)Scale / 100, tae.FrameHeight * (int)Scale / 100 );
            taeRecTop = new Rectangle((int)Pos.X, (int)Pos.Y, tae.FrameWidth * (int)Scale / 100, (tae.FrameHeight * (int)Scale / 100) - 50);
            taeRecTalk = new Rectangle((int)Pos.X, (int)Pos.Y, tae.FrameWidth * (int)Scale / 100, tae.FrameHeight * (int)Scale / 100+20);
            if (checkCollision == true)
            {
                tae.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                tae.Depth = 0.4f;
            }

            if (Data.Quest3Finish ==true)
            {
                taeRec = new Rectangle(-20000,1,1,1);
                taeRecTop = new Rectangle(-20000, 1, 1, 1);
                taeRecTalk = new Rectangle(-20000, 1, 1, 1);
            }

        }
        internal void Draw(SpriteBatch Batch)
        {
            tae.DrawFrame(Batch,Pos,row);
            if (Talktae == true && Data.Quest3 == false && Data.Quest2Finish == false)
            {
                dialog.Draw(Batch);
                dialog.ChangeDialog("Hello");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Talktae = false;
                    Data.CanControl = true;

                }
                Data.Oldms = Data.ms;
            }


            if (Talktae == true &&  Data.watermelon == false && Data.Quest2Finish == true)
            {
                dialog.Draw(Batch);
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("What do you want?\nI'm a gangster in this area");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.ChangeDialog("If you want to talk to me, go get me a watermelon");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.CanControl = true;
                            Talktae = false;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }

            if (Talktae == true && Data.watermelon == true&& Data.slingshot == false)
            {
                dialog.Draw(Batch);
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("Really brought watermelon?");
                        
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.inv.RemoveItem(Data.Watermelon);
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.ChangeDialog("Ok.What do you want me to help you with?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                        //Pae
                    case 2:
                        dialog.ChangeDialog("Please help drive the dog away");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                        //Tae
                    case 3:
                        dialog.ChangeDialog("Fine, but you'll have to get me a weapon.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.CanControl = true;
                            Data.Quest3 = true;
                            Talktae = false;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }

            if (Talktae == true && Data.Quest3 == true && Data.watermelon == true && Data.slingshot == true)
            {
                dialog.Draw(Batch);
                dialog.Draw(Batch);
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("Is this a weapon?\nHaHa! You can rest assured.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.ChangeDialog("You were confused about what he would do next.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.CanControl = true;
                            Data.Quest3Finish = true;
                            Data.inv.RemoveItem(Data.Slingshot);
                            
                            Data.CurrentState = Data.Scenes.ShotDog;
                            Talktae = false;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }



        }
        internal void taeCheck(Player player)
        {
            if (taeRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;
            }
            player.Collision(taeRec);
        }
}
}
