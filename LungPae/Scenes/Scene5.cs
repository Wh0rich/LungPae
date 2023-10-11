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

namespace LungPae.Scenes
{
    internal class Scene5 : Component
    {
        Player player;
        Texture2D grass, Floor;
        Item matchstick;
        Dialog dialog;
        PorkShop porkShop;
        public Scene5()
        {
            player = new Player();
            matchstick = new Item(new Vector2(300, 500));
            porkShop = new PorkShop();
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            grass = Content.Load<Texture2D>("grass");
            Floor = Content.Load<Texture2D>("Floor");
            porkShop.Load(Content);
            matchstick.Load(Content, "matchstick");
            Data.Matchstick.Load(Content, "matchstick");
            dialog.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            porkShop.Update(gameTime);
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
            Data.Oldms = Data.ms;
            Console.WriteLine(player.PlayerRec);
            Console.WriteLine(porkShop.TalkRec);
            Console.WriteLine(player.PlayerRec.Intersects(porkShop.TalkRec));
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec3 = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec4 = new Rectangle(Data.ScreenW-5, Data.ScreenH / 2, 5, 40);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

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
