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
        Dialog dialog;
        Vector2 dogpos;
       public Rectangle dogRec,dogRecTalk;
       public bool Talk = false;
        public int row = 1;
        public Dog() 
        {
            dog = new AnimatedTexture(Vector2.Zero,0,1,0.4f);
            dialog = new Dialog();
        }

        internal void Load(ContentManager Content)
        {
            dog.Load(Content,"Doggy1",4,5,4);
            dogpos = new Vector2(700,100);
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
                dogRec = new Rectangle((int)dogpos.X, (int)dogpos.Y, 100, 120);
                dogRecTalk = new Rectangle((int)dogpos.X - 30, 0, 150, 180);

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

            
             
        }
         internal void DogCheck(Player player)
        {
            player.Collision(dogRec);
        }


    }
}
