using lungpae;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LungPae.Core;

namespace LungPae.Model
{
    internal class Car
    {

        AnimatedTexture car;
        float scale = 1f;
        Vector2 pos = new Vector2(1050,250);
        public Rectangle CarRec;
        public Car() 
        {
            car = new AnimatedTexture(Vector2.Zero,0,scale,0.6f);
        }
        internal void Load(ContentManager Content)
        {
            car.Load(Content, "Car-all-frame",3,1,3);
        }
        internal void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(Data.Quest5Finish == false)
            {
                car.UpdateFrame(elapsed);   
            }
        }
        internal void Draw(SpriteBatch Batch)
        {
            if (Data.Quest5Finish == false)
            {
                car.DrawFrame(Batch, pos);
                CarRec = new Rectangle((int)pos.X-30, (int)pos.Y+80,car.FrameWidth+30,car.FrameHeight-80);
            }
            if(Data.Quest5Finish == true) 
            {
                CarRec = new Rectangle(20000,-20000,1,1);
            }
        }

    }
}
