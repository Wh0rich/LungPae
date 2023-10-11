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
    internal class Scene2 : Component
    {
        Texture2D Floor;
        Texture2D grass;
        Item hat;
        Mixer mix;
        TAE tae;
       // Building Shed;
        Player player;
        Vector2 mixPos = new Vector2(200, 350);
        
        public Scene2()
        {
            
            //Shed = new Building(new Vector2(350, 150), 2f);
            player = new Player();
            mix = new Mixer(mixPos);
            hat = new Item(new Vector2(500, 315));
            player.row = 4;
            tae = new TAE();

        }
        internal override void LoadContent(ContentManager Content)
        {
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            hat.Load(Content, "RobberHat");
            Data.RobberHAt.Load(Content, "RobberHat");
            mix.Load(Content);
            //Shed.Load(Content, "Shed");
            tae.Load(Content);

            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
           
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            tae.Update(gameTime);
            mix.Update(gameTime);
            mix.mixCheck(player);
            player.Collision(mix.mixRec);
            tae.taeCheck(player);
            
            if (player.PlayerRec.Intersects(hat.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(hat.itemRec) && hat.pickup == false)
            {
                Data.inv.AddItem(Data.RobberHAt);
                Data.mask = true;
                hat.pickup = true;

            }
            if (Data.CanControl == true)
            {
                //player.Collision(Shed.ObjRec);
                player.Update(gameTime);
            }
            if (player.PlayerRec.Intersects(mix.mixRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(mix.mixRecTalk))
            {

                mix.Talk = true;
                Data.CanControl = false;
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

            }
            if (player.PlayerRec.Intersects(tae.taeRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(tae.taeRecTalk))
            {

                tae.Talktae = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    tae.row = 3;
                }
                if (player.row == 2)
                {
                    tae.row = 2;
                }
                if (player.row == 3)
                {
                    tae.row = 1;
                }
                if (player.row == 4)
                {
                    tae.row = 4;
                }

            }
            if (player.PlayerRec.Intersects(tae.taeRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(tae.taeRecTalk))
            {
                Data.CanControl = false;
                tae.Talktae = true;
            }

                //if (player.PlayerRec.Intersects(Shed.ObjRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(Shed.ObjRec))
                //{
                //    Data.CanControl = false;

                //}
                
            }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 15);

            if (hat.pickup == false)
            {
                hat.Draw(_spriteBatch);
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
                Data.CurrentState = Data.Scenes.scene1;
                Data.Plypos.Y = 720 -80 ;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene3;
                Data.Plypos.Y = 0 + 10;
            }
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2,0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            //Shed.Draw(_spriteBatch);
            mix.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            if (Data.Quest3Finish == false)
            {
                tae.Draw(_spriteBatch);
            }
            
        }
    }
}
