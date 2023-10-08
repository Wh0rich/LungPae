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
        Item money1,money2;


        Texture2D grass, Floor;


        public Scene7()
        {
            player = new Player();
            money1 = new Item(new Vector2(100,200));
            money2 = new Item(new Vector2(100, 400));
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            grass = Content.Load<Texture2D>("grass");
            Floor = Content.Load<Texture2D>("Floor");
            money1.Load(Content,"cash2");
           money2.Load(Content, "cash3");
            Data.Cash2.Load(Content, "cash2");
            Data.Cash3.Load(Content, "cash3");
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(0, Data.ScreenH /2, 5, 40);
            Data.TpRec2 = new Rectangle(Data.ScreenW/2, 0, 40, 5);
            Data.TpRec3 = new Rectangle(Data.ScreenW, Data.ScreenH / 2, 5, 40);
            _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW -Floor.Width, Data.ScreenH/2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

            if (money1.pickup == false)
            {
                money1.Draw(_spriteBatch);
            }
            if (money2.pickup == false)
            {
                money2.Draw(_spriteBatch);
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
                if (Data.Money == 3)
                {
                    Data.inv.AddItem(Data.Cash3);
                    Data.Cash3.pickup = true;
                }
                money1.pickup = true;
                
            }

            if (player.PlayerRec.Intersects(money2.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(money2.itemRec) && money2.pickup == false)
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
                if (Data.Money == 3)
                {
                    Data.inv.AddItem(Data.Cash3);
                    Data.Cash3.pickup = true;
                }
                money2.pickup = true;
                
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

        }
    }
}
