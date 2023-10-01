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
using System.Reflection.Metadata;



namespace LungPae.Scenes
{
    internal class Scene4 : Component
    {
        Player player;
        Kid kid;
        Dialog dialog;
        Inventory inv;
        Texture2D floor, grass;
        Building sandbox;


        bool pickMelon = false;
        Rectangle melonRec;
        public Scene4()
        {
            sandbox = new Building(new Vector2(100, 100), 1);
            player = new Player();
            kid = new Kid();
            dialog = new Dialog();
            inv = new Inventory();
        }
        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            dialog.LoadContent(Content);
            kid.Load(Content);
            floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            sandbox.Load(Content, "sandbox");
            Data.Watermelon.Load(Content, "watermelon");
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            player.Collision(kid.dekRec);
            
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            if (player.PlayerRec.Intersects(kid.dekRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(kid.dekRec))
            {
                kid.Talk = true;
                Data.CanControl = false;
                if (player.row == 1)
                {
                    kid.row = 3;
                }
                if (player.row == 2)
                {
                    kid.row = 2;
                }
                if (player.row == 3)
                {
                    kid.row = 1;
                }
                if (player.row == 4)
                {
                    kid.row = 4;
                }

            }



        }
        internal override void Draw(SpriteBatch _spriteBatch)
        {
            // จุดเปลี่ยนแมพ
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);
            Data.TpRec2 = new Rectangle(Data.ScreenW / 2, Data.ScreenH - 5, 40, 5);


            _spriteBatch.Draw(floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    _spriteBatch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            // npc1.Draw(_spriteBatch);
            // npc1.Draw(_spriteBatch);
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene3;
                Data.Plypos.Y = 720 - 80;
            }
            if (Data.Q1Finish == true)
            {
                if (player.PlayerRec.Intersects(Data.TpRec2))
                {
                    Data.CurrentState = Data.Scenes.scene5;
                    Data.Plypos.X = 0 + 10;
                }
            }
            // วาดเด็กถ้าเควสยังไม่เสด
            if (Data.Q1Finish == false)
            {
                kid.Draw(_spriteBatch);
            }
            if (kid.Talk == true)
            {
                kid.DekDialog(_spriteBatch);
            }

            // if(pickMelon == false)
            // {
            //     melonRec = new Rectangle(50, 50, Data.Watermelon.item.Width, Data.Watermelon.item.Height);
            //     _spriteBatch.Draw(Data.Watermelon.item,new Vector2(50,50), new Rectangle(0, 0, Data.Watermelon.item.Width, Data.Watermelon.item.Height), Color.White,0,Vector2.Zero,1,0,0.3f);
            //}
            sandbox.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            Data.inv.Draw(_spriteBatch);
        }
    }
}
