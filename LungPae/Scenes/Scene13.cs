using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.Scenes
{
    internal class Scene13 : Component
    {
        Player player;
        Texture2D Floor, grass;
        Born born;

        public Scene13() 
        {
            player = new Player();
            born = new Born();
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            born.Load(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            player.Update(gameTime);
            born.Update(gameTime);
            born.Borncheck(player);

            if (player.PlayerRec.Intersects(born.bornTalkRec) || player.PlayerRec.Intersects(born.bornRecTop))
            {
                born.Stop();
                born.speed = 0;

            }
            else
            {
                born.speed = 1;
                if (born.row == 4)
                {
                    born.speed = -1;
                }
                if (born.row == 6)
                {
                    born.speed = -1;
                }
                born.Play();
            }

            if (player.PlayerRec.Intersects(born.bornTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(born.bornTalkRec))
            {
                born.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    born.row = 2;
                }
                if (player.row == 2)
                {
                    born.row = 3;
                }
                if (player.row == 3)
                {
                    born.row = 1;
                }
                if (player.row == 4)
                {
                    born.row = 4;
                }

            }
        }

        internal override void Draw(SpriteBatch Batch)
        {
            Data.inv.Draw(Batch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            

           
            Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);


            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    Batch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene12;
                Data.Plypos.Y = 720 - 80;
            }
            

            player.Draw(Batch);
            born.Draw(Batch);
        }

    }

}
