using Microsoft.Xna.Framework.Graphics;
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
    internal class Scene9 : Component
    {
        Texture2D Floor;
        Texture2D grass;
        Player player;
        Building h1, h2, h3,h4,h5,h6,h7,h8,h9,h10,h11,h12;
        Dog dog;

        public Scene9()
        {
            dog = new Dog();
            h1 = new Building(new Vector2(0, 0), 0.3f);
            h2 = new Building(new Vector2(0, 240), 0.3f);
            h3 = new Building(new Vector2(0, 480), 0.3f);
            h4 = new Building(new Vector2(300, 0), 0.3f);
            h5 = new Building(new Vector2(300, 240), 0.3f);
            h6 = new Building(new Vector2(300, 480), 0.3f);
            h7 = new Building(new Vector2(740, 0), 0.3f);
            h8 = new Building(new Vector2(740, 240), 0.3f);
            h9 = new Building(new Vector2(740, 480), 0.3f);
            h10 = new Building(new Vector2(1000, 0), 0.3f);
            h11 = new Building(new Vector2(1000, 240), 0.3f);
            h12 = new Building(new Vector2(1000, 480), 0.3f);

            //Shed = new Building(new Vector2(350, 150), 2f);
            player = new Player();
            player.row = 4;
        }
        internal override void LoadContent(ContentManager Content)
        {
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            h1.Load(Content, "House1");
            h2.Load(Content, "House3");
            h3.Load(Content, "House1");
            h4.Load(Content, "House3");
            h5.Load(Content, "House1");
            h6.Load(Content, "House3");
            h7.Load(Content, "House1");
            h8.Load(Content, "House3");
            h9.Load(Content, "House1");
            h10.Load(Content, "House3");
            h11.Load(Content, "House1");
            h12.Load(Content, "House3");
            dog.Load(Content);

            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            dog.DogCheck(player);
            if (player.PlayerRec.Intersects(dog.dogRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dog.dogRecTalk))
            {
                dog.Talk = true;
                Data.CanControl = false;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Data.Quest3Finish = true;
            }
            h1.CheckCollision(player);
            player.Collision(h1.ObjRecDown);
            h2.CheckCollision(player);
            player.Collision(h2.ObjRecDown);
            h3.CheckCollision(player);
            player.Collision(h3.ObjRecDown);
            h4.CheckCollision(player);
            player.Collision(h4.ObjRecDown);
            h5.CheckCollision(player);
            player.Collision(h5.ObjRecDown);
            h6.CheckCollision(player);
            player.Collision(h6.ObjRecDown);
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

        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);
            dog.Draw(_spriteBatch);
            h3.Draw(_spriteBatch);
            h2.Draw(_spriteBatch);
            h1.Draw(_spriteBatch);
            h6.Draw(_spriteBatch);
            h5.Draw(_spriteBatch);
            h4.Draw(_spriteBatch);
            h9.Draw(_spriteBatch);
            h8.Draw(_spriteBatch);
            h7.Draw(_spriteBatch);
            h12.Draw(_spriteBatch);
            
            h10.Draw(_spriteBatch);
            h11.Draw(_spriteBatch);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);


            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(Floor, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene10;
                Data.Plypos.Y = 720 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene7;
                Data.Plypos.Y = 0 + 10;
            }
           
            player.Draw(_spriteBatch);
            
        }
    }
}
