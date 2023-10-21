using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.CutScenes
{
    public class BlackScreen : Component
    {
        Texture2D bg;
        Dialog dialog;
        float temp;
        bool Add = false;
        bool eatlaab = false;
        bool fire = true;

        float i = 0.1f;
        
        public BlackScreen() 
        { 
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager Content)
        {
            bg = Content.Load<Texture2D>("Blackbg");
            dialog.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Add == false)
            {
                temp += elapsed;
                if(temp > 0.08f) 
                {
                    Add = true;
                    temp = 0;
                }
            }
            if(i<0)
            {

                loop = false ;
            }
            Console.WriteLine(i);
        }
        bool loop = true;

        internal void Drawfade(SpriteBatch spriteBatch)
        {
            if (loop == true)
            {
                if (Add == true)
                {
                    i += 0.1f;
                    Add = false;
                }
            }
            spriteBatch.Draw(bg, Vector2.Zero, Color.Black * i );
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
          

            spriteBatch.Draw(bg, Vector2.Zero, Color.Black );

            if (Data.Quest2Finish == true && fire ==false)
            {
                dialog.Draw(spriteBatch);
                dialog.ChangeDialog("Fire in the hole");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec)&&Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Data.OnFire = false;
                    Data.CurrentState = Data.Scenes.scene6;
                    Data.CanControl = true;
                    fire = false;
                }
                Data.Oldms = Data.ms;
            }
            if ( eatlaab == false)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:

                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("waited for her to cook for a while\nDee suddenly regained consciousness.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:

                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("Cooked Laap is finished cooking");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:

                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("Finally!\nYou come and eat together and thank you for helping.Pe.");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:

                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("You get to eat laab and have fun");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:

                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("E kar Moh Kaa Nard!!!");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.CanControl = true;
                            Data.Quest4Finish = true;
                            Data.Plypos = new Vector2(85,290);

                            Data.CurrentState = Data.Scenes.scene11;
                            eatlaab = true;
                        }
                        Data.Oldms = Data.ms;
                        break;

                }
            }




        }
    }
}
