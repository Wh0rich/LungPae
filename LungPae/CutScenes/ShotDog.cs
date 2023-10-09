﻿using lungpae;
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
    internal class ShotDog : Component
    {

        Texture2D Floor;
        Texture2D grass;
        AnimatedTexture dog;
        Vector2 dogpos = new Vector2(700, 100);
        Dialog dialog;
        float temp;
        int row = 2;

        bool talk1 = true;
        bool talk2 = true;
        bool tokjai = false;
        bool dogwalk = false;   
        public ShotDog()
        {
            dog = new AnimatedTexture(Vector2.Zero,0,1,0.5f);
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager Content)
        {
            dog.Load(Content,"Doggy1",4,5,4);   
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            dialog.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(tokjai == true)
            {
                temp += elapsed;
                
            }
            if (dogwalk == true)
            {
                dogpos.Y -= 2;
                dog.UpdateFrame(elapsed);
            }
            
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (talk1 == true)
            {
                dog.DrawFrame(spriteBatch, 1, dogpos, 1);
                dialog.Draw(spriteBatch);
                dialog.ChangeDialog("Look This !!!!");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    talk1 = false;
                    tokjai = true;
                }
                Data.Oldms = Data.ms;
            }
            if(tokjai == true)
            {
                dog.DrawFrame(spriteBatch, 0, dogpos, 3);
                if (temp > 2.5)
                {
                    tokjai = false;
                    dogwalk = true;
                    temp = 0;
                }
            }
            if(dogwalk == true)
            {
                dog.DrawFrame(spriteBatch,dogpos,row);
            }

            if (dogpos.Y < -30 && talk2 == true)
            {
                
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("I'm TAE the gangster of chiangmai moat!!!");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.Draw(spriteBatch);
                        dialog.ChangeDialog("but I have to go on a mission.Good bye PeaKung");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0 ;
                            talk2 = false;
                            Data.CurrentState = Data.Scenes.scene2;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
                



                

            }
            
        }
    }
}