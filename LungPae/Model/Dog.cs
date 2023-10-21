using System;
using lungpae;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LungPae.Core;
using Microsoft.Xna.Framework.Input;

namespace LungPae.Model
{

    
    internal class Dog
    {
        public AnimatedTexture dog;
        public AnimatedTexture dogBr;
        public AnimatedTexture dogBl;
        Dialog dialog;
        Vector2 dogpos;
        Vector2 dogpos1;
        Vector2 dogpos2;
        public Rectangle dogRec,dogRecTalk;
       public bool Talk = false;
        public int row = 1;
        public Dog() 
        {
            dog = new AnimatedTexture(Vector2.Zero,0,1,0.4f);
            dogBr = new AnimatedTexture(Vector2.Zero, 0, 1, 0.4f);
            dogBl = new AnimatedTexture(Vector2.Zero, 0, 1, 0.4f);
            dialog = new Dialog();
        }

        internal void Load(ContentManager Content)
        {
            dog.Load(Content,"Doggy1",4,5,4);
            dogBr.Load(Content, "Doggy1", 4, 5, 4);
            dogBl.Load(Content, "Doggy1", 4, 5, 4);

            dogpos = new Vector2(620,60);
            dogpos1 = new Vector2(655, 30);
            dogpos2 = new Vector2(585, 35);
            dialog.LoadContent(Content);
        }
        internal void Update(GameTime gameTime)
        {

        }
        internal void Draw(SpriteBatch Batch)
        {
            if (Data.Quest3Finish == false)
            {
                dog.DrawFrame(Batch, 0, dogpos);
                dogBr.DrawFrame(Batch,3, dogpos1,3);
                dogBl.DrawFrame(Batch, 2, dogpos2,3);
                dogRec = new Rectangle((int)dogpos.X-50, (int)dogpos.Y-40, 170, 130);
                dogRecTalk = new Rectangle((int)dogpos.X-70 , (int)dogpos.Y-40, 210, 180);

                if (Talk == true)
                {
                    Data.ms = Mouse.GetState();
                    dialog.Draw(Batch);
                    switch (Data.DialogCount)
                    {
                        case 0:
                            dialog.ChangeDialog("Woof! Woof! Woof!!");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount++;
                            }
                            Data.Oldms = Data.ms;
                            break;
                        case 1:
                            dialog.ChangeDialog("It looked like a dog was blocking the next path.\nYou should find someone to help you.");
                            if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                            {
                                Data.DialogCount = 0;
                                Data.CanControl = true;

                                Talk = false;
                            }
                            Data.Oldms = Data.ms;
                            break;
                    }


                }
            }
            if(Data.Quest3Finish == true)
            {
                dogRec = new Rectangle(20000,0,1,1);
                dogRecTalk = new Rectangle(20000,0,1,1);
            }

            
             
        }
         internal void DogCheck(Player player)
        {
            player.Collision(dogRec);
        }


    }
}
