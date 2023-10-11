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
    internal class Mixer
    {
        AnimatedTexture mixer;
        public AnimatedTexture Mixani;
        Dialog dialog;
        Vector2 mixPos;


       public Rectangle mixRec, mixRecTop, mixRecTalk;
        public bool Talk = false , checkCollision = false;
        public int row = 1;
        float Scale = 0.6f;
        public Mixer(float rotation, float scale, float depth) 
        {
            mixer = new AnimatedTexture(Vector2.Zero, rotation, scale, depth);
            Mixani = new AnimatedTexture(Vector2.Zero, rotation, scale, depth);
            dialog = new Dialog();
        }
        public Mixer(Vector2 mixpos)
        {
            mixer = new AnimatedTexture(Vector2.Zero, 0, Scale, 0.4f);
            Mixani = new AnimatedTexture(Vector2.Zero, 0, Scale, 0.4f);
            dialog = new Dialog();
            this.mixPos = mixpos;
            Scale = Scale * 100;
        }
        internal void Load(ContentManager content)
        {
            mixer.Load(content, "MixerReal", 1, 4, 10);
            Mixani.Load(content, "MixerAni", 6, 1, 18);
            dialog.LoadContent(content,"MixerBox");
        }
        internal void Update(GameTime gameTime)
        {
            mixRec = new Rectangle((int)mixPos.X, (int)mixPos.Y +30, mixer.FrameWidth * (int)Scale / 100, mixer.FrameHeight * (int)Scale / 100+10);
            mixRecTop = new Rectangle((int)mixPos.X, (int)mixPos.Y, mixer.FrameWidth * (int)Scale / 100, (mixer.FrameHeight * (int)Scale / 100) -40 );
            mixRecTalk = new Rectangle((int)mixPos.X, (int)mixPos.Y , mixer.FrameWidth * (int)Scale / 100, mixer.FrameHeight * (int)Scale / 100);
            
            if (checkCollision == true)
            {
                mixer.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                mixer.Depth = 0.4f;
            }




        }
        internal void Draw(SpriteBatch batch)
        {
            mixer.DrawFrame(batch, mixPos, row);
            
            if (Talk == true && Data.Minigame1 == false)
            {
                dialog.DrawPerson(batch,"Mixer");
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("Hi");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;

                    case 1:
                        dialog.ChangeDialog("Ma runing gunn");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount = 0;
                            Data.Minigame1 = true;
                            Data.CurrentState = Data.Scenes.minigame1;
                            Talk = false;
                        }
                        Data.Oldms = Data.ms;
                        break;
                }
            }
            if (Talk == true && Data.Minigame1 == true)
            {
                dialog.Draw(batch);
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.ChangeDialog("Hi");
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

        internal void Drawmini(SpriteBatch batch,Vector2 Posmix) // Drawสำหรับminigame
        {
            Mixani.DrawFrame(batch, Posmix);
        }

            
            internal void mixCheck(Player player)
        {
            if (mixRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;
            }
        }
    }
}
