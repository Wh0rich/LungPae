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
        Building b1,b2,b3,b4,b5;
        Bush bush_1, bush_2, bush_3, bush_4, bush_5, bush_6, bush_7, bush_8, bush_9, bush_10, bush_11, bush_12, bush_13, bush_14;
        public Scene16()
        {
            player = new Player();
            car = new Car();
            wizard = new Wizard();
            b1 = new Building(new Vector2(0, 0), 0.2f);
            b2 = new Building(new Vector2(250, 0), 0.2f);
            b3 = new Building(new Vector2(500, 0), 0.2f);
            b4 = new Building(new Vector2(750, 0), 0.2f);
            b5 = new Building(new Vector2(1000, 0), 0.2f);
            bush_1 = new Bush(new Vector2(0, 630), 0.2f);
            bush_2 = new Bush(new Vector2(90, 630), 0.2f);
            bush_3 = new Bush(new Vector2(180, 630), 0.2f);
            bush_4 = new Bush(new Vector2(270, 630), 0.2f);
            bush_5 = new Bush(new Vector2(360, 630), 0.2f);
            bush_6 = new Bush(new Vector2(750, 630), 0.2f);
            bush_7 = new Bush(new Vector2(840, 630), 0.2f);
            bush_8 = new Bush(new Vector2(930, 630), 0.2f);
            bush_9 = new Bush(new Vector2(1020, 630), 0.2f);
            bush_10 = new Bush(new Vector2(1110, 630), 0.2f);
            bush_11 = new Bush(new Vector2(1200, 630), 0.2f);
            bush_12 = new Bush(new Vector2(450, 630), 0.2f);
            bush_13 = new Bush(new Vector2(540, 630), 0.2f);
            bush_14 = new Bush(new Vector2(650, 630), 0.2f);



        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            b1.Load(Content, "buliding");
            b2.Load(Content, "buliding");
            b3.Load(Content, "buliding");
            b4.Load(Content, "buliding");
            b5.Load(Content, "buliding");
            bush_1.Load(Content);
            bush_2.Load(Content);
            bush_3.Load(Content);
            bush_4.Load(Content);
            bush_5.Load(Content);
            bush_6.Load(Content);
            bush_7.Load(Content);
            bush_8.Load(Content);
            bush_9.Load(Content);
            bush_10.Load(Content);
            bush_11.Load(Content);
            bush_12.Load(Content);
            bush_13.Load(Content);
            bush_14.Load(Content);

            car.Load(Content);
            wizard.Load(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            player.Update(gameTime);
            car.Update(gameTime);
            b1.CheckCollision(player);
            player.Collision(b1.ObjRecDown);
            b2.CheckCollision(player);
            player.Collision(b2.ObjRecDown);
            b3.CheckCollision(player);
            player.Collision(b3.ObjRecDown);
            b4.CheckCollision(player);
            player.Collision(b4.ObjRecDown);
            b5.CheckCollision(player);
            player.Collision(b5.ObjRecDown);
            bush_1.Bushcheck(player);
            bush_2.Bushcheck(player);
            bush_3.Bushcheck(player);
            bush_4.Bushcheck(player);
            bush_5.Bushcheck(player);
            bush_6.Bushcheck(player);
            bush_7.Bushcheck(player);
            bush_8.Bushcheck(player);
            bush_9.Bushcheck(player);
            bush_10.Bushcheck(player);
            bush_11.Bushcheck(player);
            bush_12.Bushcheck(player);
            bush_13.Bushcheck(player);
            bush_14.Bushcheck(player);
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
            b1.Draw(Batch);
            b2.Draw(Batch);
            b3.Draw(Batch);
            b4.Draw(Batch);
            b5.Draw(Batch);
            bush_1.Drawbig(Batch);
            bush_2.Drawbig(Batch);
            bush_3.Drawbig(Batch);
            bush_4.Drawbig(Batch);
            bush_5.Drawbig(Batch);
            bush_6.Drawbig(Batch);
            bush_7.Drawbig(Batch);
            bush_8.Drawbig(Batch);
            bush_9.Drawbig(Batch);
            bush_10.Drawbig(Batch);
            bush_11.Drawbig(Batch);
            bush_12.Drawbig(Batch);
            bush_13.Drawbig(Batch);
            bush_14.Drawbig(Batch);
            for (int i = 0; i < 33; i++)
            {
                Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2 + 40) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2 - 40) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }


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
