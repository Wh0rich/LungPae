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


namespace LungPae.Scenes
{
    internal class Scene6 : Component
    {
        Player player;
        Item money;
        Texture2D Floor, grass;
        Campfire fire;
        Dialog dialog;
        Crowd crowd;
        Building shop1;
        Rectangle CrowdRec;
        float temp;
        bool Talk;
        bool mask = false;
        bool stick = false;
        public Scene6()
        {
            shop1 = new Building(new Vector2(200,50), 1);
            player = new Player();
            money = new Item(new Vector2(1200,410));
            dialog = new Dialog();
            fire = new Campfire(new Vector2(600, 375), 1);
            crowd = new Crowd();
        }
        internal override void LoadContent(ContentManager Content)
        {
            dialog.LoadContent(Content);

            player.LoadContent(Content);
            crowd.Load(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            shop1.Load(Content,"shop1");
            money.Load(Content,"cash1");
            Data.Cash.Load(Content,"cash1");
            
            fire.Load(Content);
            

        }
        internal override void Update(GameTime gameTime)
        {
            
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            if (Data.Quest2Finish == true && Data.Quest2 == true)
            {

            }
           
            if (player.PlayerRec.Intersects(crowd.CrowdRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(crowd.CrowdRec))
            {
                Talk = true;
                Data.CanControl = false;

            }
            if (player.PlayerRec.Intersects(fire.fireRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(fire.fireRec))
            {
                fire.Talk = true;
                Data.CanControl = false;
                Data.Oldms = Data.ms;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Data.Quest2Finish = true;
            }




            crowd.Update(gameTime);
            player.Update(gameTime);
            player.Collision(crowd.CrowdRec);
            player.Collision(fire.fireRec);
        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
           
           

            Data.inv.Draw(_spriteBatch);
            Data.TpRec = new Rectangle(0, Data.ScreenH / 2, 5, 40);
            Data.TpRec2 = new Rectangle(Data.ScreenW - 5, Data.ScreenH / 2, 5, 40);

            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW - Floor.Width, Data.ScreenH / 2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(0, Data.ScreenH/2), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene5;
                Data.Plypos.X = 1280 - 80;
            }
            if (player.PlayerRec.Intersects(Data.TpRec2))
            {
                Data.CurrentState = Data.Scenes.scene7;
                Data.Plypos.X = 0 + 10;
            }
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }

            if (Talk == true && Data.Quest2Finish == false)
            {

                dialog.Draw(_spriteBatch);
                dialog.ChangeDialog("The crowd was so crowded\nit seemed impossible to continue.");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec))
                {
                    Talk = false;
                    Data.CanControl = true;
                }

            }
           
            if (fire.Talk == true)
            {
                fire.Speak(_spriteBatch);
            }

            if (Data.Quest2Finish == false)
            {
                crowd.Draw(_spriteBatch);
            }
            if (Data.Quest2Finish == true && Data.OnFire == true)
            {
                
                Data.CurrentState = Data.Scenes.Blackscreen;
                Data.inv.RemoveItem(Data.Matchstick);
                Data.inv.RemoveItem(Data.RobberHAt);
               
            }

            if (Data.Quest2Finish == true)
            {
                if (money.pickup == false)
                {
                    money.Draw(_spriteBatch);
                }
            }
            if (player.PlayerRec.Intersects(money.itemRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(money.itemRec) && money.pickup == false)
            {
                Data.Money += 1;
                if (Data.Money ==  1)
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
                
                money.pickup = true;
                
            }

            fire.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
        }
    }
}