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
    internal class Scene14 : Component
    {
        Player player;
        Texture2D Floor, grass;
        Mixer mix;
        Vector2 mixPos = new Vector2(200, 350);
        public Scene14()
        {
            player = new Player();
            mix = new Mixer(mixPos);
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            mix.Load(Content);


        }

        internal override void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            player.Update(gameTime);
            mix.Update(gameTime);
            mix.mixCheck(player);
            if (player.PlayerRec.Intersects(mix.mixRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(mix.mixRecTalk))
            {

                mix.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    mix.row = 3;
                }
                if (player.row == 2)
                {
                    mix.row = 2;
                }
                if (player.row == 3)
                {
                    mix.row = 1;
                }
                if (player.row == 4)
                {
                    mix.row = 4;
                }

            }
            Data.Oldms = Data.ms;
        }

        internal override void Draw(SpriteBatch Batch)
        {
            Data.inv.Draw(Batch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);
            Data.TpRec3 = new Rectangle(Data.ScreenW - 5, Data.ScreenH / 2, 5, 40);

            Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    Batch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene15;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene12;
                Data.Plypos.Y = 0 + 10;
            }
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene16;
                Data.Plypos.X = 0 + 10;
            }

            player.Draw(Batch);
            mix.Draw(Batch);
        }

    }

}
