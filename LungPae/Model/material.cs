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
    internal class material
    {
        Texture2D obj;
        Vector2 pos;
        private float Scale;
        private float Depth = 0.8f;
        public Rectangle ObjRecDown, ObjRecTop;
        public bool Talk = false;
        public material(Vector2 pos, float scale) //รับค่า posกับscaleมา
        {
            this.pos = pos;
            //newpos = pos * 2;
            this.Scale = scale;
            Scale = (Scale * 100);
        }
        internal void Load(ContentManager Content, string asset)
        {
            this.obj = Content.Load<Texture2D>(asset);
            //ObjRecTop = new Rectangle((int)pos.X, (int)pos.Y, obj.Width * (int)Scale / 100, (obj.Height * (int)Scale / 100) / 2);
            //ObjRecDown = new Rectangle((int)pos.X , (int)pos.Y+20, obj.Width * (int)Scale / 100, obj.Height * (int)Scale / 100);
            ObjRecDown = new Rectangle((int)pos.X, (int)pos.Y, obj.Width * (int)Scale / 100, obj.Height * (int)Scale / 100 + 65);
        }
        internal void CheckCollision(Player player)
        {
            player.Collision(ObjRecDown);
        }
        internal void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(obj, pos, new Rectangle(0, 0, obj.Width, obj.Height), Color.White, 0, Vector2.Zero, Scale / 100, 0, Depth);
        }
    }
}
