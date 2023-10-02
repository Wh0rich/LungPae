using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;

namespace LungPae.Model
{
    internal class Crowd
    {
        Texture2D npc;
        public Rectangle CrowdRec;
        public Crowd() 
        {

        }  
        public void Load(ContentManager Content)
        {
            npc = Content.Load<Texture2D>("NPC");

        }
        public void Update(GameTime gameTime)
        {
            if (Data.Quest2Finish == false)
            {
                CrowdRec = new Rectangle(1080, 275, 200, 250);
            }
            if (Data.Quest2Finish == true)
            {
                CrowdRec = new Rectangle(-20000, -10000, 200, 250);
            }
        }
        public void Draw(SpriteBatch _spriteBatch) 
        {
            //_spriteBatch.Draw(npc, new Vector2(1165 - 100, 330-60), new Rectangle(64 * 0, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.2f);
            //_spriteBatch.Draw(npc, new Vector2(1190 - 100, 305-60), new Rectangle(64 * 3, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.3f);
            //_spriteBatch.Draw(npc, new Vector2(1220 - 100, 320 - 60), new Rectangle(64 * 3, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.4f);
            //_spriteBatch.Draw(npc, new Vector2(1200 - 100, 350-60), new Rectangle(64, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.5f);
            //_spriteBatch.Draw(npc, new Vector2(1120 - 100, 300 - 60), new Rectangle(64 * 2, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.55f);
            //_spriteBatch.Draw(npc, new Vector2(1100 - 100, 345-60), new Rectangle(64 * 1, 128 * 2, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.6f);
            //_spriteBatch.Draw(npc, new Vector2(1130 - 100, 360 - 60), new Rectangle(64 * 1, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.7f);
            //_spriteBatch.Draw(npc, new Vector2(1155 - 100, 375- 60), new Rectangle(64 * 2, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.8f);
            //_spriteBatch.Draw(npc, new Vector2(1240 - 100, 345 - 60), new Rectangle(64 * 1, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.9f);
            //_spriteBatch.Draw(npc, new Vector2(1240 - 100, 275 - 60), new Rectangle(64 * 3, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 1f);

            //_spriteBatch.Draw(npc, new Vector2(1165, 330-100), new Rectangle(64 * 0, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.2f);
            //_spriteBatch.Draw(npc, new Vector2(1190, 305-100), new Rectangle(64 * 3, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.3f);
            //_spriteBatch.Draw(npc, new Vector2(1220, 320 - 100), new Rectangle(64 * 3, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.4f);
            //_spriteBatch.Draw(npc, new Vector2(1200, 350-100), new Rectangle(64, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.5f);
            //_spriteBatch.Draw(npc, new Vector2(1120, 300 - 100), new Rectangle(64 * 2, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.6f);
            //_spriteBatch.Draw(npc, new Vector2(1100, 345-100), new Rectangle(64 * 1, 128 * 2, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.7f);
            //_spriteBatch.Draw(npc, new Vector2(1130, 360-100), new Rectangle(64 * 1, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.8f);
            //_spriteBatch.Draw(npc, new Vector2(1155, 375 - 100), new Rectangle(64 * 2, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.9f);
            //_spriteBatch.Draw(npc, new Vector2(1240, 345-100), new Rectangle(64 * 1, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.95f);
            //_spriteBatch.Draw(npc, new Vector2(1240, 275 - 100), new Rectangle(64 * 3, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 1f);

            //_spriteBatch.Draw(npc, new Vector2(1165 - 100, 330), new Rectangle(64 * 0, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.2f);
            //_spriteBatch.Draw(npc, new Vector2(1190 - 100, 305), new Rectangle(64 * 3, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.3f);
            //_spriteBatch.Draw(npc, new Vector2(1220 - 100, 320), new Rectangle(64 * 3, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.4f);
            //_spriteBatch.Draw(npc, new Vector2(1200 - 100, 350), new Rectangle(64, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.5f);
            //_spriteBatch.Draw(npc, new Vector2(1120 - 100, 300), new Rectangle(64 * 2, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.6f);
            //_spriteBatch.Draw(npc, new Vector2(1100 - 100, 345), new Rectangle(64 * 1, 128 * 2, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.7f);
            //_spriteBatch.Draw(npc, new Vector2(1130 - 100, 360), new Rectangle(64 * 1, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.8f);
            //_spriteBatch.Draw(npc, new Vector2(1155 - 100, 375), new Rectangle(64 * 2, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.9f);
            //_spriteBatch.Draw(npc, new Vector2(1240 - 100, 345), new Rectangle(64 * 1, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.95f);
            //_spriteBatch.Draw(npc, new Vector2(1240 - 100, 275), new Rectangle(64 * 3, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 1f);
           


                _spriteBatch.Draw(npc, new Vector2(1165, 330), new Rectangle(64 * 0, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.2f);
                _spriteBatch.Draw(npc, new Vector2(1190, 305), new Rectangle(64 * 3, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.3f);
                _spriteBatch.Draw(npc, new Vector2(1220, 320), new Rectangle(64 * 3, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.4f);
                _spriteBatch.Draw(npc, new Vector2(1200, 350), new Rectangle(64, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.5f);
                _spriteBatch.Draw(npc, new Vector2(1120, 300), new Rectangle(64 * 2, 0, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.6f);
                _spriteBatch.Draw(npc, new Vector2(1100, 345), new Rectangle(64 * 1, 128 * 2, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.7f);
                _spriteBatch.Draw(npc, new Vector2(1130, 360), new Rectangle(64 * 1, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.8f);
                _spriteBatch.Draw(npc, new Vector2(1155, 375), new Rectangle(64 * 2, 128, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.9f);
                _spriteBatch.Draw(npc, new Vector2(1240, 345), new Rectangle(64 * 1, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 0.95f);
                _spriteBatch.Draw(npc, new Vector2(1240, 275), new Rectangle(64 * 3, 128 * 3, 64, 128), Color.White, 0, Vector2.Zero, 0.6f, SpriteEffects.None, 1f);
               
            
           
        }
    }
}
