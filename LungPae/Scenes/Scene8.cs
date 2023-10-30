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
    internal class Scene8 : Component
    {
        Player player;
        Texture2D Floor,grass;
        WatermelonShop melonshop;
        Building house;
        Tree tree1, tree2,tree3;
        Bush bush_1, bush_2, bush_3, bush_4, bush_5, bush_6, bush_7, bush_8, bush_9, bush_10, bush_11, bush_12, bush_13, bush_14;
        public Scene8()
        {
            player = new Player();
            melonshop = new WatermelonShop();
            tree1 = new Tree(new Vector2(10, 20), 0.2f);
            tree2 = new Tree(new Vector2(520, 20), 0.2f);
            tree3 = new Tree(new Vector2(1180, 20), 0.2f);
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
            house = new Building(new Vector2(200, 30), 0.3f);
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            melonshop.Load(Content);
            house.Load(Content, "House3");
            tree1.Load(Content);
            tree2.Load(Content);
            tree3.Load(Content);
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
            grass = Content.Load<Texture2D>("grass");
            Floor = Content.Load<Texture2D>("Floor");
        }
        internal override void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);

            player.Update(gameTime);
            melonshop?.Update(gameTime);
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
            tree1.Treecheck(player);
            tree2.Treecheck(player);
            tree3.Treecheck(player);
            house.CheckCollision(player);
            player.Collision(house.ObjRecDown);

            melonshop.CheckCollision(player);
            if (player.PlayerRec.Intersects(melonshop.TalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(melonshop.TalkRec))
            {
                melonshop.Talk = true;
                Data.CanControl = false;
            }
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            for (int i = 0; i < 30; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2 + 40) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2 - 40) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }

            Data.TpRec = new Rectangle(0+5, Data.ScreenH / 2, 5, 40);
            _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene7;
                Data.Plypos.X = 1280-60;
            }
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
            house.Draw(_spriteBatch);
            tree1.Draw(_spriteBatch);
            tree2.Draw(_spriteBatch);
            tree3.Draw(_spriteBatch);
            melonshop.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
        }
    }
}
