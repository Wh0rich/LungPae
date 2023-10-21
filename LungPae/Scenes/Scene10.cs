﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using LungPae.Model;
using lungpae;

namespace LungPae.Scenes
{
    internal class Scene10 : Component
    {
        Texture2D Floor;
        Texture2D grass;
        Player player;
        AyDee Dee;

        public Scene10()
        {
            
            //Shed = new Building(new Vector2(350, 150), 2f);
            Dee = new AyDee();
            player = new Player();
            player.row = 4;
        }
        internal override void LoadContent(ContentManager Content)
        {
            Dee.Load(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();

            if (player.PlayerRec.Intersects(Dee.deeTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(Dee.deeTalkRec))
            {
                Dee.Talk = true;
                Data.CanControl = false;

            }
            Dee.Deecheck(player);
            Dee.Update(gameTime);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);
           
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            
            
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene11;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene9;
                Data.Plypos.Y = 0 + 10;
            }

            player.Draw(_spriteBatch);
            if (Data.Quest4 == false && Data.QuestLaab == false)
            {
                Dee.Draw(_spriteBatch);
            }
        }
    }
}
