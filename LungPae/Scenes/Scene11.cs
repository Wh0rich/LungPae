using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.Scenes
{
    internal class Scene11 : Component
    {
        Texture2D Floor;
        Texture2D grass;
        Player player;
        Building house;
        MaeLek lek;
        public Scene11()
        {

            //Shed = new Building(new Vector2(350, 150), 2f);
            house = new Building(new Vector2(60, 50), 0.3f);
            lek = new MaeLek();
            player = new Player();
            player.row = 4;
        }
        internal override void LoadContent(ContentManager Content)
        {
            house.Load(Content, "House1");
            lek.Load(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {

            player.Update(gameTime);
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();

            if (player.PlayerRec.Intersects(lek.lekTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(lek.lekTalkRec))
            {
                lek.Talk = true;
                Data.CanControl = false;

            }

            lek.Update(gameTime);
            house.CheckCollision(player);
            player.Collision(house.ObjRecDown);
            lek.MaeLekCheck(player);
            Console.WriteLine("pos"+Data.Plypos);
            Console.WriteLine("Rec"+player.PlayerRec);
            
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(0,Data.ScreenH / 2, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);

            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(0,Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

           
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene12;
                Data.Plypos.X = Data.ScreenW - 70;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene10;
                Data.Plypos.Y = 0 + 10;
            }
           
            player.Draw(_spriteBatch);
            house.Draw(_spriteBatch);
           
            lek.Draw(_spriteBatch);
            if (Data.Quest4Finish == true &&Data.leave == true)
            {
                player.row = 1;
                Data.leave = false;
            }

            if (Data.QuestLaab == true && Data.Quest4 == false)
            {
                player.row = 3;
                lek.Talk = true;
                Data.CurrentState = Data.Scenes.scene11;

            }
        }
    }
}
