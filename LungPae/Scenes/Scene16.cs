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
    internal class Scene16 : Component
    {
        Player player;
        Texture2D Floor, grass;
        Car car;
        Wizard wizard;
        public Scene16()
        {
            player = new Player();
            car = new Car();
            wizard = new Wizard();
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            car.Load(Content);
            wizard.Load(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            player.Update(gameTime);
            car.Update(gameTime);
            wizard.Update(gameTime);
            wizard.WiCheck(player);
            if (player.PlayerRec.Intersects(wizard.wiTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(wizard.wiTalkRec))
            {

                wizard.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    wizard.row = 3;
                }
                if (player.row == 2)
                {
                    wizard.row = 2;
                }
                if (player.row == 3)
                {
                    wizard.row = 1;
                }
                if (player.row == 4)
                {
                    wizard.row = 4;
                }

            }
            player.Collision(car.CarRec);
        }

        internal override void Draw(SpriteBatch Batch)
        {
            Data.inv.Draw(Batch);
            Data.TpRec = new Rectangle(0 + 5, Data.ScreenH / 2, 5, 40);
            
            Data.TpRec2 = new Rectangle(Data.ScreenW - 5, Data.ScreenH / 2, 5, 40);

            Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            Batch.Draw(Floor, new Vector2(0, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);


            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    Batch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene14;
                Data.Plypos.X = 1280 - 60;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene17;
                Data.Plypos.X = 0 + 10;
            }

            player.Draw(Batch);
            car.Draw(Batch);
            wizard.Draw(Batch);
        }

    }

}
