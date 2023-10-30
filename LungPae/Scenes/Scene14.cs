using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
    internal class Scene14 : Component
    {
        Cabinet cabinet;
        Player player;
        Texture2D Floor, grass;
        Mixer mix;
        Building h1,h3, h4, h6, h7,h9, h10, h12;
        Vector2 mixPos = new Vector2(200, 350);

        public Scene14()
        {
            player = new Player();
            mix = new Mixer(mixPos);
            h1 = new Building(new Vector2(0, 0), 0.3f);
            
            h3 = new Building(new Vector2(0, 480), 0.3f);
            h4 = new Building(new Vector2(300, 0), 0.3f);
           
            h6 = new Building(new Vector2(300, 480), 0.3f);
            h7 = new Building(new Vector2(740, 0), 0.3f);
            
            h9 = new Building(new Vector2(740, 480), 0.3f);
            h10 = new Building(new Vector2(1000, 0), 0.3f);
           
            h12 = new Building(new Vector2(1000, 480), 0.3f);

            cabinet = new Cabinet(new Vector2(600, 220));
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            cabinet.Load(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            mix.Load(Content);
            h1.Load(Content, "House1");
           
            h3.Load(Content, "House3");
            h4.Load(Content, "House1");
        
            h6.Load(Content, "House3");
            h7.Load(Content, "House3");
            
            h9.Load(Content, "House3");
            h10.Load(Content, "House1");
         
            h12.Load(Content, "House1");

        }

        internal override void Update(GameTime gameTime)
        {
            Console.WriteLine(mix.mixRecTalk);
            


            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Console.WriteLine(Data.MRec);
            Data.ms = Mouse.GetState();
            h1.CheckCollision2(player);
            player.Collision(h1.ObjRecDown);
          
            h3.CheckCollision2(player);
            player.Collision(h3.ObjRecDown);
            h4.CheckCollision(player);
            player.Collision(h4.ObjRecDown);
           
            h6.CheckCollision2(player);
            player.Collision(h6.ObjRecDown);
            h7.CheckCollision(player);
            player.Collision(h7.ObjRecDown);
        
            h9.CheckCollision2(player);
            player.Collision(h9.ObjRecDown);
            h10.CheckCollision(player);
            player.Collision(h10.ObjRecDown);
         
            h12.CheckCollision2(player);
            player.Collision(h12.ObjRecDown);

            cabinet.Update(gameTime);
            cabinet.Gamecheck(player);

            player.Update(gameTime);
            mix.Update(gameTime);
            mix.mixCheck(player);
            if (player.PlayerRec.Intersects(cabinet.cabinetRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(cabinet.cabinetRecTalk))
            {
                cabinet.Talk = true;
                Data.CanControl = false;
              
            }
            if (player.PlayerRec.Intersects(mix.mixRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(mix.mixRecTalk))
            {

                
                if (player.row == 1)
                {
                    mix.row = 3;
                }
                if (player.row == 2)
                {
                    mix.row = 2;
                }
                if (player.row == 3)
                {
                    mix.row = 1;
                }
                if (player.row == 4)
                {
                    mix.row = 4;
                }
                mix.Talk = true;
                Data.CanControl = false;
                Data.Oldms = Data.ms;
            }
           
        }

        internal override void Draw(SpriteBatch Batch)
        {
            Data.inv.Draw(Batch);
            
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);
            Data.TpRec3 = new Rectangle(Data.ScreenW - 5, Data.ScreenH / 2, 5, 40);

            for (int i = 0; i < 10; i++)
            {
                Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height) - Data.PosTileY *i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW / 2+40, Data.ScreenH - Floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 40, Data.ScreenH - Floor.Height) - Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            //Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            for (int i = 0; i < 15; i++)
            {
                Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2+40) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2-40) - Data.PosTileX * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }

            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    Batch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene12;
                Data.Plypos.Y = 0 + 10;
            }
            if (player.PlayerRec.Intersects(Data.TpRec3))
            {
                Data.CurrentState = Data.Scenes.scene16;
                Data.Plypos.X = 0 + 10;
            }
            h3.Draw(Batch);
          
            h1.Draw(Batch);
            h6.Draw(Batch);
          
            h4.Draw(Batch);
            h9.Draw(Batch);
         
            h7.Draw(Batch);
            h10.Draw(Batch);
            h12.Draw(Batch);

            player.Draw(Batch);
            mix.Draw(Batch);
            cabinet.Draw(Batch);
        }

    }

}
