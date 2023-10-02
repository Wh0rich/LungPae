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
    public class Item
    {
        Vector2 itempos;
        public Rectangle itemRec;
        public Texture2D item;
        public bool pickup = false;
        public bool Talk = false;
        public Item(Vector2 itempos)
        {
            this.itempos = itempos;
            
        }
        public Item()
        {
           
        }

        public void Load(ContentManager Content, string asset)
        {
            item = Content.Load<Texture2D>(asset);
        }
        public void Draw(SpriteBatch batch)
        {
            if (pickup==false)
            {


                batch.Draw(item, itempos, null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0.4f);
                itemRec = new Rectangle((int)itempos.X, (int)itempos.Y, item.Width * 50 / 100, item.Height * 50 / 100);
            }
           
        }








     }
}
