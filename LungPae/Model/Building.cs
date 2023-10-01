using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;


namespace LungPae.Model
{
    internal class Building
    {
        Texture2D obj;
        Vector2 pos;
        private float Scale;
        private float Depth = 0.5f;
        public Rectangle ObjRecDown, ObjRecTop;
        public Building(Vector2 pos, float scale) //รับค่า posกับscaleมา
        {
            this.pos = pos;
            //newpos = pos * 2;
            this.Scale = scale;
            Scale= (Scale * 100);
        }
        internal void Load(ContentManager Content, string asset)
        {
            this.obj = Content.Load<Texture2D>(asset);
            ObjRecTop = new Rectangle((int)pos.X, (int)pos.Y , obj.Width * (int)Scale / 100, (obj.Height * (int)Scale / 100) / 2);
            ObjRecDown = new Rectangle((int)pos.X, (int)pos.Y + (obj.Height * (int)Scale / 100)/2 + 10, obj.Width * (int)Scale / 100, (obj.Height * (int)Scale / 100)/2); 
        }
        internal void CheckCollision(Player player)
        {
            if (ObjRecTop.Intersects(player.PlayerRec))
            {
                Depth = 0.6f;
            }
            if (ObjRecDown.Intersects(player.PlayerRec))
            {
                Depth = 0.4f;
                if (player.PlayerRec.Intersects(ObjRecDown) && player.PlayerRec.Top < ObjRecDown.Top)
                {
                    Depth = 0.6f;
                }
            }
        }
        internal void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(obj, pos, new Rectangle(0, 0, obj.Width, obj.Height), Color.White, 0, Vector2.Zero, Scale / 100, 0,Depth);
        }

    }
}
