using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.Model
{
    internal class Bush
    {
        Texture2D bushsmall, bushbig;
        float Scale;
        public float Depth = 0.4f;
        Vector2 pos;
        public Rectangle BsmallRec, BsmallRecTop, BbigRec, BbigRecTop;
        bool checkCollision = false;
        public Bush(Vector2 pos, float Scale)
        {
            this.pos = pos;
            this.Scale = Scale * 100;

        }
        internal void Load(ContentManager Content)
        {
            bushsmall = Content.Load<Texture2D>("SmallBush");
            bushbig = Content.Load<Texture2D>("BigBush");
           
        }
        internal void Update(GameTime gameTime)
        {
            if (checkCollision == true)
            {
                this.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                this.Depth = 0.4f;
            }
        }

        internal void Drawbig(SpriteBatch Batch)
        {
            Batch.Draw(bushbig, pos, null, Color.White, 0, Vector2.Zero, Scale / 100, 0, Depth);
            BbigRec = new Rectangle((int)pos.X, (int)pos.Y, bushbig.Width * (int)Scale / 100, bushbig.Height * (int)Scale / 100+70);
           
        }
        internal void Drawsmall(SpriteBatch Batch)
        {
            Batch.Draw(bushsmall, pos, null, Color.White, 0, Vector2.Zero, Scale / 100, 0, Depth);
            BsmallRec = new Rectangle((int)pos.X, (int)pos.Y , bushsmall.Width * (int)Scale / 100, bushsmall.Height * (int)Scale / 100+70);
            
        }


        internal void Bushcheck(Player player)
        {
            
            player.Collision(BbigRec);
            player.Collision(BsmallRec);
           
        }
    }
}
