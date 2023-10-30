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
    internal class Scene15 : Component
    {
        Player player;
        Texture2D Floor, grass;
        Cabinet cabinet;

        public Scene15()
        {
            player = new Player();
            
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            
        }

        internal override void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            player.Update(gameTime);

            if (player.PlayerRec.Intersects(cabinet.cabinetRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(cabinet.cabinetRecTalk))
            {
                cabinet.Talk = true;
                Data.CanControl = false;

            }


               
        }

        internal override void Draw(SpriteBatch Batch)
        {
            Data.inv.Draw(Batch);
            
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);
           

           // Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    Batch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene14;
                Data.Plypos.Y = 0 + 10;
            }

            player.Draw(Batch);
            cabinet.Draw(Batch);
        }

    }

}
