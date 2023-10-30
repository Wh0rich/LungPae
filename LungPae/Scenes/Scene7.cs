using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace LungPae.Scenes
{
    internal class Scene7 : Component
    {
        Player player;
        Item money1;
        SlingShotShop shop;
        Bush bush_1, bush_2, bush_3, bush_4, bush_5, bush_6, bush_7, bush_8, bush_9, bush_10, bush_11, bush_12, bush_13, bush_14;
        Building shop1, shop2;
        Texture2D grass, Floor;


        public Scene7()
        {
            player = new Player();
            shop = new SlingShotShop();
            shop1 = new Building(new Vector2(100, 0), 0.7f);
            shop2 = new Building(new Vector2(350, 0), 0.7f);
            money1 = new Item(new Vector2(100,550));
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
            shop1.Load(Content, "shop3");
            shop2.Load(Content, "shop2");
            shop.Load(Content);
            money1.Load(Content,"cash2");
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

            Data.Cash2.Load(Content, "cash2");
           
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
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
            shop.Update(gameTime);
            shop.CheckCollision(player);
            if (player.PlayerRec.Intersects(shop.TalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(shop.TalkRec))
            {
                shop.Talk = true;
                Data.CanControl = false;
            }
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(0, Data.ScreenH /2, 5, 40);
            Data.TpRec2 = new Rectangle(Data.ScreenW/2, 0, 40, 5);
            Data.TpRec3 = new Rectangle(Data.ScreenW, Data.ScreenH / 2, 5, 40);
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
            for (int i = 0; i < 33; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2 + 40) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2 - 40) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            for (int i = 0; i < 11; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 80, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW -Floor.Width, Data.ScreenH/2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }




            if (money1.pickup == false)
            {
                money1.Draw(_spriteBatch);
            }
           

            if (player.PlayerRec.Intersects(money1.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(money1.itemRec) && money1.pickup == false)
            {
                Data.Money += 1;
                if (Data.Money == 1)
                {
                    Data.inv.AddItem(Data.Cash);
                    Data.Cash.pickup = true;
                }
                if (Data.Money == 2)
                {
                    Data.inv.AddItem(Data.Cash2);
                    Data.Cash2.pickup = true;
                }
                
                money1.pickup = true;
                
            }

           





            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene6;
                Data.Plypos.X = Data.ScreenW - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene9;
                Data.Plypos.Y = 720 -80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene8;
                Data.Plypos.X = 0 + 10;
            }
            player.Draw(_spriteBatch);
            shop.Draw(_spriteBatch);
        }
    }
}
