using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LungPae.Model
{
    internal class Tree
    {
        Texture2D tree;
        float Scale;
        public float Depth = 0.4f;
        Vector2 pos;
        public Rectangle treeRec, treeRecTop;
        bool checkCollision = false;
        public Tree(Vector2 pos,float Scale) 
        { 
            this.pos = pos;
            this.Scale = Scale *100;

        }
        internal void Load(ContentManager Content)
        {
            tree = Content.Load<Texture2D>("Big-Tree");
            treeRec = new Rectangle((int)pos.X, (int)pos.Y+ 150, tree.Width * (int)Scale / 100 , tree.Height * (int)Scale / 100 -80);
            treeRecTop = new Rectangle((int)pos.X, (int)pos.Y, tree.Width * (int)Scale / 100, (tree.Height * (int)Scale / 100) /2);
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

        internal void Draw(SpriteBatch Batch)
        {
            Batch.Draw(tree, pos, null, Color.White, 0, Vector2.Zero,Scale/100, 0, Depth);
        }


        internal void Treecheck(Player player)
        {
            if (treeRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;

            }
            player.Collision(treeRec);
        }
    }
}
