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
using Microsoft.Xna.Framework.Audio;

namespace LungPae.Scenes
{
    internal class Scene11 : Component
    {
        List<SoundEffect> soundEffects = new List<SoundEffect>();
        List<SoundEffect> instance = new List<SoundEffect>();
        Texture2D Floor;
        Texture2D grass;
        Player player;
        Building house,building, h7, h8, h9, h10, h11, h12;
        MaeLek lek;
        public Scene11()
        {

            //Shed = new Building(new Vector2(350, 150), 2f);
            house = new Building(new Vector2(60, 50), 0.3f);
            lek = new MaeLek();
            player = new Player();
            player.row = 4;
            h7 = new Building(new Vector2(740, 0), 0.3f);
            h8 = new Building(new Vector2(740, 240), 0.3f);
            h9 = new Building(new Vector2(740, 480), 0.3f);
            h10 = new Building(new Vector2(1000, 0), 0.3f);
            h11 = new Building(new Vector2(1000, 240), 0.3f);
            h12 = new Building(new Vector2(1000, 480), 0.3f);
            building = new Building(new Vector2(420, 20), 0.2f);
        }
        internal override void LoadContent(ContentManager Content)
        {
            house.Load(Content, "House1");
            lek.Load(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            player.LoadContent(Content);
            h7.Load(Content, "House1");
            h8.Load(Content, "House3");
            h9.Load(Content, "House1");
            h10.Load(Content, "House3");
            h11.Load(Content, "House1");
            h12.Load(Content, "House3");
            building.Load(Content, "buliding");
            soundEffects.Add(Content.Load<SoundEffect>("MaeLek_The minced pork at the bottom"));
            soundEffects.Add(Content.Load<SoundEffect>("MaeLek_ I've got the pork"));
            for (int i = 0; i < 2; i++)
            {
                instance.Add(soundEffects[i]);
                instance[i].CreateInstance();
            }
        }
        internal override void Update(GameTime gameTime)
        {

            player.Update(gameTime);
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            h7.CheckCollision(player);
            player.Collision(h7.ObjRecDown);
            h8.CheckCollision(player);
            player.Collision(h8.ObjRecDown);
            h9.CheckCollision(player);
            player.Collision(h9.ObjRecDown);
            h10.CheckCollision(player);
            player.Collision(h10.ObjRecDown);
            h11.CheckCollision(player);
            player.Collision(h11.ObjRecDown);
            h12.CheckCollision(player);
            player.Collision(h12.ObjRecDown);
            building.CheckCollision(player);
            player.Collision(building.ObjRecDown); 

            if (player.PlayerRec.Intersects(lek.lekTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(lek.lekTalkRec))
            {
                lek.Talk = true;
                Data.CanControl = false;
                if(Data.Pork.pickup == false)
                {
                    instance[0].Play();
                }
                if (Data.Pork.pickup == true)
                {
                    instance[1].Play();
                }
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
            h7.Draw(_spriteBatch);

            h9.Draw(_spriteBatch);

            h8.Draw(_spriteBatch);

            h12.Draw(_spriteBatch);

            h11.Draw(_spriteBatch);
            h10.Draw(_spriteBatch);
            building.Draw(_spriteBatch);
            for (int i = 0; i < 9; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2-80, Data.ScreenH - Floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2-40, Data.ScreenH - Floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            for (int i = 0; i < 16; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2+40) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2+80) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH / 2) + Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
           
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
