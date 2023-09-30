using lungpae;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using System.Data;
using LungPae.Scenes;

namespace LungPae.Model
{
    internal class Player 
    {
        public AnimatedTexture player;
        private const int Frame = 6;
        private const int FramePerSec = 10;
        private const int FrameRow = 4;
        private const float Rotation = 0;
        private const float Scale = 0.6f;
        private  float Depth = 0.5f;
        
        public Rectangle PlayerRec;
       
        public int speed = 5,  row = 1;

        public Player(float rotation, float scale, float depth)
        {
            player = new AnimatedTexture(Vector2.Zero, rotation, scale, depth);
        }
            public Player()
        {
            player = new AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
        }
        public  void LoadContent(ContentManager Content)
        {
            
            player.Load(Content,"Lungpae",Frame,FrameRow,FramePerSec);
        }
        public void Update(GameTime gameTime)
        {


            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState ks;
            ks = Keyboard.GetState();
            if (Data.CanControl == true)
            {
                if (ks.IsKeyDown(Keys.D))
                {

                    Data.Plypos.X += speed;
                    row = 4;
                }
                if (ks.IsKeyDown(Keys.A))
                {
                    Data.Plypos.X -= speed;
                    row = 2;
                }
                if (ks.IsKeyDown(Keys.W))
                {
                    Data.Plypos.Y -= speed;
                    row = 3;
                }
                if (ks.IsKeyDown(Keys.S))
                {
                    Data.Plypos.Y += speed;
                    row = 1;
                }
                if (ks.IsKeyDown(Keys.D) || ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.S))
                {
                    player.UpdateFrame(elapsed);
                }
                if (ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.A) && ks.IsKeyUp(Keys.W) && ks.IsKeyUp(Keys.S))
                {
                    player.Frame = 0;
                }
                PlayerRec = new Rectangle((int)Data.Plypos.X, (int)Data.Plypos.Y, 64 * 6 / 10, 119 * 6 / 10);
            }

            if (PlayerRec.Left < 0)
            {
                Data.Plypos.X += speed;
            }
            else if (PlayerRec.Right > Data.ScreenW)
            {
                Data.Plypos.X -= speed;
            }
            else if (PlayerRec.Bottom > Data.ScreenH)
            {
                Data.Plypos.Y -= speed;
            }
            else if (PlayerRec.Top < 0)
            {
                Data.Plypos.Y += speed;
            }
            if (Data.CanControl == false)
            {
                player.Frame = 0;
            }
        }
        internal void Draw(SpriteBatch _spriteBatch)
        {
            player.DrawFrame(_spriteBatch,Data.Plypos,row);
            
        }
        internal void Drawmini(SpriteBatch _spriteBatch,Vector2 Playerpos) // Drawสำหรับminigame
        {
            player.DrawFrame(_spriteBatch, Playerpos , row);

        }

        public void Collision( Rectangle ObjRec) //เช็คชน
        {
            if (Data.CanControl == true)
            {
                if (PlayerRec.Intersects(ObjRec) && ObjRec.Left - PlayerRec.Right >= -speed && PlayerRec.Bottom < ObjRec.Bottom)
                {
                    Data.Plypos.X -= speed;
                }
                else if (PlayerRec.Intersects(ObjRec) && PlayerRec.Right >= ObjRec.Right + PlayerRec.Width - speed && ObjRec.Right - PlayerRec.Left >= -speed && PlayerRec.Bottom < ObjRec.Bottom)
                {
                    Data.Plypos.X += speed;
                }
                else if (PlayerRec.Intersects(ObjRec) && PlayerRec.Top < ObjRec.Top)
                {
                    Data.Plypos.Y -= speed;
                    
                }
                else if (PlayerRec.Intersects(ObjRec) && PlayerRec.Bottom < ObjRec.Bottom)
                {
                    Data.Plypos.Y += speed;
                }
            }
            
        }

       
       

    }
}