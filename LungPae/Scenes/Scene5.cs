using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using Microsoft.Xna.Framework.Content;
using LungPae.Model;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace LungPae.Scenes
{
    internal class Scene5 : Component
    {
        Player player;
        Texture2D grass, Floor;
        Item matchstick;
        Building shop1,shop2;
        Dialog dialog;
        PorkShop porkShop;
        material bin;
        Bush bush_1, bush_2, bush_3, bush_4, bush_5, bush_6, bush_7, bush_8, bush_9, bush_10, bush_11, bush_12, bush_13,bush_14;
        
        public Scene5()
        {
            player = new Player();
            shop1 = new Building(new Vector2(780, 0), 0.7f);
            shop2 = new Building(new Vector2(1020, 0), 0.7f);

            matchstick = new Item(new Vector2(400, 80));
            porkShop = new PorkShop();
            dialog = new Dialog();
            bin = new material(new Vector2(420, 80),1f);
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
            grass = Content.Load<Texture2D>("grass");
            Floor = Content.Load<Texture2D>("Floor");
            shop1.Load(Content, "shop1");
            shop2.Load(Content, "shop2");
            bin.Load(Content, "recyclebin");
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
            porkShop.Load(Content);
            matchstick.Load(Content, "matchstick");
            Data.Matchstick.Load(Content, "matchstick");
            dialog.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            bin.CheckCollision(player);
            shop1.CheckCollision(player);
            shop2.CheckCollision(player);
            player.Collision(shop1.ObjRecDown);
            player.Collision(shop2.ObjRecDown);
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

            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            if (player.PlayerRec.Intersects(matchstick.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(matchstick.itemRec) && matchstick.pickup == false)
            {
                Data.inv.AddItem(Data.Matchstick);
                matchstick.pickup = true;
                matchstick.Talk = true;
                Data.CanControl = false;
                Data.stick = true;
            }
            porkShop.CheckCollision(player);
            Console.WriteLine(porkShop.TalkRec);
            if (player.PlayerRec.Intersects(porkShop.TalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(porkShop.TalkRec))
            {
                porkShop.Talk = true;
                Data.CanControl = false;
            }
           
            Console.WriteLine(player.PlayerRec);
            Console.WriteLine(porkShop.TalkRec);
            Console.WriteLine(player.PlayerRec.Intersects(porkShop.TalkRec));
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec3 = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec4 = new Rectangle(Data.ScreenW-5, Data.ScreenH / 2, 5, 40);
            bin.Draw(_spriteBatch);
            shop1.Draw(_spriteBatch);
            shop2.Draw(_spriteBatch);
            bush_1.Drawbig(_spriteBatch);
            bush_2.Drawbig(_spriteBatch);
            bush_3.Drawbig(_spriteBatch);
            bush_4.Drawbig(_spriteBatch);
            bush_5.Drawbig(_spriteBatch);
            bush_6.Drawbig(_spriteBatch);
            bush_7.Drawbig(_spriteBatch);
            bush_8.Drawbig(_spriteBatch);
            bush_9.Drawbig(_spriteBatch);
            bush_10.Drawbig(_spriteBatch);
            bush_11.Drawbig(_spriteBatch);
            bush_12.Drawbig(_spriteBatch);
            bush_13.Drawbig(_spriteBatch);
            bush_14.Drawbig(_spriteBatch);
            for (int i = 0; i < 16; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2 -40)-Data.PosTileX*i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2 +40) - Data.PosTileX *i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2) - Data.PosTileX *i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            for (int i = 0; i < 11; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2-40, 0)+Data.PosTileY*i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2-80, 0) + Data.PosTileY*i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY*i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }

            if (matchstick.pickup == false)
            {
                matchstick.Draw(_spriteBatch);
            }

            if (matchstick.Talk == true)
            {

                dialog.Draw(_spriteBatch);
                dialog.ChangeDialog("It must definitely do something.");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec))
                {
                    matchstick.Talk = false;
                    Data.CanControl = true;
                }
            }

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene4;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec4))
            {
                Data.CurrentState = Data.Scenes.scene6;
                Data.Plypos.X = 0 + 10;
            }
            player.Draw(_spriteBatch);
            porkShop.Draw(_spriteBatch);
        }
    }
}
