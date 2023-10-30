using lungpae;
using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LungPae.Model
{
    internal class AyDee
    {
        List<SoundEffect> soundEffects;
        List<SoundEffect> instance;

        AnimatedTexture Dee;
        Texture2D sleep;
        Dialog dialog,faint;
       public Rectangle deeTalkRec, deeRec, deeRecTop;

        Vector2 Deepos;
        int row = 1;
        public  bool Talk = false;
        bool tooktomom = false;
        bool checkCollision = false;
        float Scale = 0.6f;
        public AyDee() 
        {
            Dee = new AnimatedTexture(Vector2.Zero,0,Scale,0.4f);
            dialog = new Dialog();
            faint = new Dialog();
            soundEffects = new List<SoundEffect>();
            instance = new List<SoundEffect>();
            Scale *= 100;
        }

        internal void Load(ContentManager Content)
        {
            Dee.Load(Content,"AyDee",1,4,0);
            sleep = Content.Load<Texture2D>("Dee_knock");
            faint.LoadContent(Content, "DeeBox_faint");

            soundEffects.Add(Content.Load<SoundEffect>("Dee_buhhhh"));
            soundEffects.Add(Content.Load<SoundEffect>("Dee_I don't know how many hours I slept"));
            soundEffects.Add(Content.Load<SoundEffect>("Dee_What time is it now"));

            for(int i = 0;i<3;i++)
            {
                instance.Add(soundEffects[i]);
                instance[i].CreateInstance();
            }

            dialog.LoadContent(Content);
            Deepos = new Vector2(640,540);
        }
        internal void Update(GameTime gameTime) 
        {
            if (checkCollision == true)
            {
                Dee.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                Dee.Depth = 0.4f;
            }
        }

        internal void Draw(SpriteBatch Batch)
        {

            if (Talk == true && Data.QuestLaab == false)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.Draw(Batch);
                        dialog.ChangeDialog("The man seemed to be lying on the ground.\nDo you want to help him?");
                        dialog.Answer("Definitely helps.", "No, I'm busy.");
                        dialog.DrawAns(Batch);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans1Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {

                            Data.DialogCount++;
                            instance[2].Play();
                        }
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.Ans2Rec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Talk = false;
                            Data.CanControl = true;
                            Data.DialogCount = 0;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:

                        faint.DrawPerson(Batch,"Dee");
                        faint.ChangeDialog("What time is it now?");
                        
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(faint.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                            instance[1].Play();
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 2:

                        faint.DrawPerson(Batch, "Dee");
                        faint.ChangeDialog("I don't know how many hours I slept");
                        
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(faint.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                            instance[0].Play();
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 3:

                        faint.DrawPerson(Batch, "Dee");
                        faint.ChangeDialog("bruhhhh");
                        
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(faint.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 4:

                        dialog.Draw(Batch);
                        dialog.ChangeDialog("You searched his bag. Looks like I've found his address.\nSo I tried to bring him to his house");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount=0;
                            Data.QuestLaab = true;
                            Data.CurrentState = Data.Scenes.scene11;
                            Data.Plypos.X = 80;
                            Data.Plypos.Y = 340; 
                            tooktomom = true;
                        }
                        Data.Oldms = Data.ms;
                        break;

                }
            }
            if (tooktomom == false)
            {
                Batch.Draw(sleep,Deepos,null,Color.White,0,Vector2.Zero,Scale/100,0,0.4f);
                deeRec = new Rectangle((int)Deepos.X, (int)Deepos.Y , sleep.Width * (int)Scale / 100+5, sleep.Height * (int)Scale / 100+20);
                deeRecTop = new Rectangle((int)Deepos.X, (int)Deepos.Y, sleep.Width * (int)Scale / 100, (sleep.Height * (int)Scale / 100) - 50);
                deeTalkRec = new Rectangle((int)Deepos.X-10, (int)Deepos.Y-10, sleep.Width * (int)Scale / 100+20, sleep.Height * (int)Scale / 100 + 20);
            }
            if(tooktomom == true)
            {
                
                deeRec = new Rectangle(-20000,0,1,1);
                deeRecTop = new Rectangle(-20000, 0, 1, 1);
                deeTalkRec = new Rectangle(-20000, 0, 1, 1);
            }
        }


        internal void Deecheck(Player player)
        {
            if (deeRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;
                
            }
            player.Collision(deeRec);
        }

    }
}
