using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.Model
{
    internal class Campfire
    {
        Texture2D fire, fire2;
        Vector2 pos;
        Dialog dialog;
        private float Scale;
        private float Depth = 0.4f;
        public Rectangle fireRec;
        public bool Talk = false;
        public bool mord = false;

        public Campfire(Vector2 pos, float scale) //รับค่า posกับscaleมา
        {
            dialog = new Dialog();
            this.pos = pos;

            this.Scale = scale;
            Scale = (Scale * 100);
        }
        internal void Load(ContentManager Content)
        {
            fire = Content.Load<Texture2D>("Campfire");
            fire2 = Content.Load<Texture2D>("Campfire2");
            dialog.LoadContent(Content);
        }

        internal void Draw(SpriteBatch _spriteBatch)
        {
            if (mord == false)
            {
                _spriteBatch.Draw(fire, pos, null, Color.White, 0, Vector2.Zero, Scale / 100, 0, Depth);
                fireRec = new Rectangle((int)pos.X + 26, (int)pos.Y + 30, fire.Width * (int)Scale / 100 - 14, fire.Height * (int)Scale / 100 + 16);
            }
            if (mord == true)
            {
                _spriteBatch.Draw(fire2, pos, null, Color.White, 0, Vector2.Zero, Scale / 100, 0, Depth);
                fireRec = new Rectangle((int)pos.X + 26, (int)pos.Y + 30, fire.Width * (int)Scale / 100 - 14, fire.Height * (int)Scale / 100 + 16);
            }
        }
        internal void Speak(SpriteBatch _spriteBatch)
        {
            if (mord == false && Data.mask == false && Talk == true && Data.stick == true)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.Draw(_spriteBatch);
                        dialog.ChangeDialog("Are you going to set fire to chase away the crowd?");
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Data.DialogCount++;
                        }
                        Data.Oldms = Data.ms;
                        break;
                    case 1:
                        dialog.Draw(_spriteBatch);
                        dialog.ChangeDialog("you need to find something to hide your face.");
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

            if (mord == false && Data.stick == false && Talk == true || Data.mask == true)
            {
                Data.ms = Mouse.GetState();
                switch (Data.DialogCount)
                {
                    case 0:
                        dialog.Draw(_spriteBatch);
                        dialog.ChangeDialog("This is an Old Campfire");
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
            if (mord == false && Data.stick == true && Talk == true && Data.mask == true)
            {
                mord = true;
                Data.Quest2Finish =true;
            }
        }

    }
}

