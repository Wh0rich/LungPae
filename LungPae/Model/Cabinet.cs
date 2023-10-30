using LungPae.Core;
using Microsoft.Xna.Framework;
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
    internal class Cabinet
    {
        Texture2D cabinet;
        Dialog dialog;
        Vector2 pos;
        public Rectangle cabinetRec, cabinetRecTop, cabinetRecTalk;
        bool checkCollision = false;
        public bool Talk = false;
        float Depth = 0.1f;
        float scale = 0.7f;
        public Cabinet(Vector2 pos)
        {
            this.pos = pos;
            dialog = new Dialog();
            scale *= 100;
        }

        internal void Load(ContentManager Content)
        {
            cabinet = Content.Load<Texture2D>("game-cabinet");
            dialog.LoadContent(Content);
        }
        internal void Update(GameTime gameTime)
        {
            cabinetRec = new Rectangle((int)pos.X, (int)pos.Y + 35, cabinet.Width * (int)scale / 100, cabinet.Height * (int)scale / 100 - 15);
            cabinetRecTop = new Rectangle((int)pos.X, (int)pos.Y, cabinet.Width * (int)scale / 100, (cabinet.Height * (int)scale / 100) - 80);
            cabinetRecTalk = new Rectangle((int)pos.X + 10, (int)pos.Y + 45, cabinet.Width * (int)scale / 100 - 20, cabinet.Height * (int)scale / 100 - 60);

            if (checkCollision == true)
            {
                Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                Depth = 0.1f;
            }

        }

        internal void Draw(SpriteBatch Batch)
        {
            Batch.Draw(cabinet, pos, null, Color.White, 0, Vector2.Zero, scale / 100, 0, Depth);

            if (Talk == true)
            {
                Data.ms = Mouse.GetState();

                dialog.Draw(Batch);
                dialog.ChangeDialog("Welcome to Northern Cowboy.\nOnly one winner will receive the prize.");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    
                    Data.CurrentState = Data.Scenes.Cowboy;

                }
               
            }
            Data.Oldms = Data.ms;
        }
        internal void Gamecheck(Player player)
        {
            if (cabinetRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;

            }
            player.Collision(cabinetRec);
            Console.WriteLine(player.PlayerRec.Intersects(cabinetRecTalk));
        }

    }
    
}


    

