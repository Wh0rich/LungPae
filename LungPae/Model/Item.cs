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
        public Texture2D item;
        public Item()
        {

        }
        public void Load(ContentManager Content, string asset)
        {
            item = Content.Load<Texture2D>(asset);
        }
        








     }
}
