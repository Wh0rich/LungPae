using lungpae;
using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

using System.Text;
using System.Threading.Tasks;

namespace LungPae.CutScenes
{
    internal class ShotDog : Component
    {

        Texture2D Floor;
        Texture2D grass;
        Building h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12;
        AnimatedTexture dog;
        AnimatedTexture dog2;
        AnimatedTexture dog3;
        TAE tae;
        Vector2 dogpos = new Vector2(620,60);
        Vector2 dogpos3 = new Vector2(655, 30);
        Vector2 dogpos2 = new Vector2(585, 35);
        Vector2 taepos = new Vector2(620,140);
        Dialog dialog,box;
        float temp;
        int row = 2;

        bool talk1 = true;
        bool talk2 = true;
        bool tokjai = false;
        bool dogwalk = false;   
        public ShotDog()
        {
            dog = new AnimatedTexture(Vector2.Zero,0,1,0.5f);
            dog2 = new AnimatedTexture(Vector2.Zero, 0, 1, 0.5f);
            dog3= new AnimatedTexture(Vector2.Zero, 0, 1, 0.5f);
            tae = new TAE();
            dialog = new Dialog();
            box = new Dialog();
            h1 = new Building(new Vector2(0, 0), 0.3f);
            h2 = new Building(new Vector2(0, 240), 0.3f);
            h3 = new Building(new Vector2(0, 480), 0.3f);
            h4 = new Building(new Vector2(300, 0), 0.3f);
            h5 = new Building(new Vector2(300, 240), 0.3f);
            h6 = new Building(new Vector2(300, 480), 0.3f);
            h7 = new Building(new Vector2(740, 0), 0.3f);
            h8 = new Building(new Vector2(740, 240), 0.3f);
            h9 = new Building(new Vector2(740, 480), 0.3f);
            h10 = new Building(new Vector2(1000, 0), 0.3f);
            h11 = new Building(new Vector2(1000, 240), 0.3f);
            h12 = new Building(new Vector2(1000, 480), 0.3f);
        }
        internal override void LoadContent(ContentManager Content)
        {
            tae.Load(Content);
            dog.Load(Content,"Doggy1",4,5,4);
            dog2.Load(Content, "Doggy1", 4, 5, 4);
            dog3.Load(Content, "Doggy1", 4, 5, 4);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            dialog.LoadContent(Content, "TaeBox");
            box.LoadContent(Content, "TaeBox_Angry");
            h1.Load(Content, "House1");
            h2.Load(Content, "House3");
            h3.Load(Content, "House1");
            h4.Load(Content, "House3");
            h5.Load(Content, "House1");
            h6.Load(Content, "House3");
            h7.Load(Content, "House1");
            h8.Load(Content, "House3");
            h9.Load(Content, "House1");
            h10.Load(Content, "House3");
            h11.Load(Content, "House1");
            h12.Load(Content, "House3");

        }

        internal override void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            tae.Update(gameTime);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(tokjai == true)
            {
                temp += elapsed;
                
            }
            if (dogwalk == true)
            {
                dogpos.Y -= 2;
                dogpos2.Y -= 2;
                dogpos3.Y -= 2;
                dog.UpdateFrame(elapsed);
            }
         
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

            h3.Draw(spriteBatch);
            h2.Draw(spriteBatch);
            h1.Draw(spriteBatch);
            h6.Draw(spriteBatch);
            h5.Draw(spriteBatch);
            h4.Draw(spriteBatch);
            h9.Draw(spriteBatch);
            h8.Draw(spriteBatch);
            h7.Draw(spriteBatch);
            h12.Draw(spriteBatch);
            h11.Draw(spriteBatch);
            h10.Draw(spriteBatch);
            if (talk1 == true)
            {
                tae.tae.DrawFrame(spriteBatch, taepos, 3);
            }
            

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (talk1 == true)
            {
                dog.DrawFrame(spriteBatch, 0, dogpos, 1);
                dog2.DrawFrame(spriteBatch, 3, dogpos3, 3);
                dog3.DrawFrame(spriteBatch, 2, dogpos2, 3);
                box.DrawPerson(spriteBatch,"Tae");
                box.ChangeDialog("Look This !!!!");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    talk1 = false;
                    tokjai = true;
                }
                Data.Oldms = Data.ms;
            }

            if(talk1 == false)
            {
                tae.tae.DrawFrame(spriteBatch,taepos,5);
            }


            if(tokjai == true)
            {
                dog.DrawFrame(spriteBatch, 0, dogpos, 3);
                dog2.DrawFrame(spriteBatch, 3, dogpos3, 3);
                dog3.DrawFrame(spriteBatch, 2, dogpos2, 3);
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
                dog2.DrawFrame(spriteBatch, dogpos3, 4);
                dog3.DrawFrame(spriteBatch, dogpos2, 5);
            }

            if (dogpos.Y < -30 && talk2 == true)
            {
                
                switch (Data.DialogCount)
                {
                    case 0:
                        box.DrawPerson(spriteBatch,"Tae");
                        box.ChangeDialog("I'm TAE the gangster of chiangmai moat!!!");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(box.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.DrawPerson(spriteBatch,"Tae");
                        dialog.ChangeDialog("but I have to go on a mission.Good bye PaeKung");
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
