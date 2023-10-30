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
    internal class Scene13 : Component
    {
        List<SoundEffect> soundEffects = new List<SoundEffect>();
        List<SoundEffect> instance = new List<SoundEffect>();
        Player player;
        Texture2D Floor, grass;
        material bin1, bin2, bin3;
        Building h1, b1, b2, b3, b4;
        Bush bush1, bush2, bush3;


        Born born;

        public Scene13() 
        {
            h1 = new Building(new Vector2(900, 0), 0.3f);
            b1 = new Building(new Vector2(0, 400), 0.2f);
            b2 = new Building(new Vector2(350, 400), 0.2f);
            b3 = new Building(new Vector2(700, 400), 0.2f);
            b4 = new Building(new Vector2(1050, 400), 0.2f);
            bin1 = new material(new Vector2(290,600),1);
            bin2 = new material(new Vector2(640, 600), 1);
            bin3 = new material(new Vector2(990, 600), 1);
            player = new Player();
            born = new Born();
            bush1 = new Bush(new Vector2(0, 0), 0.2f);
            bush2 = new Bush(new Vector2(90, 0), 0.2f);
            bush3 = new Bush(new Vector2(180, 0), 0.2f);
        }

        internal override void LoadContent(ContentManager Content)
        {
            player.LoadContent(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            h1.Load(Content,"House4");
            b1.Load(Content, "buliding");
            b2.Load(Content, "buliding");
            b3.Load(Content, "buliding");
            b4.Load(Content, "buliding");
            bin1.Load(Content, "recyclebin");
            bin2.Load(Content, "recyclebin");
            bin3.Load(Content, "recyclebin");
            bush1.Load(Content);
            bush2.Load(Content);
            bush3.Load(Content);
            soundEffects.Add(Content.Load<SoundEffect>("Born_Im Born,Mathematician Olympiad"));
            instance.Add(soundEffects[0]);
            instance[0].CreateInstance();
            born.Load(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            h1.CheckCollision(player);
            player.Collision(h1.ObjRecDown);
            b1.CheckCollision(player);
            player.Collision(b1.ObjRecDown);
            b2.CheckCollision(player);
            player.Collision(b2.ObjRecDown);
            b3.CheckCollision(player);
            player.Collision(b3.ObjRecDown);
            b4.CheckCollision(player);
            player.Collision(b4.ObjRecDown);
            bin1.CheckCollision(player);
            bin2.CheckCollision(player);
            bin3.CheckCollision(player);
            bush1.Bushcheck(player);
            bush2.Bushcheck(player);
            bush3.Bushcheck(player);

            player.Collision(b4.ObjRecDown);
            player.Update(gameTime);
            born.Update(gameTime);
            born.Borncheck(player);

            if (player.PlayerRec.Intersects(born.bornTalkRec) || player.PlayerRec.Intersects(born.bornRecTop))
            {
                born.Stop();
                born.speed = 0;

            }
            else
            {
                born.speed = 1;
                if (born.row == 4)
                {
                    born.speed = -1;
                }
                if (born.row == 6)
                {
                    born.speed = -1;
                }
                born.Play();
            }

            if (player.PlayerRec.Intersects(born.bornTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(born.bornTalkRec))
            {
                born.Talk = true;
                Data.CanControl = false;
                if(Data.Glasses.pickup == false)
                {
                    instance[0].Play();
                }
                
                if (player.row == 1)
                {
                    born.row = 2;
                }
                if (player.row == 2)
                {
                    born.row = 3;
                }
                if (player.row == 3)
                {
                    born.row = 1;
                }
                if (player.row == 4)
                {
                    born.row = 4;
                }

            }
        }

        internal override void Draw(SpriteBatch Batch)
        {
            Data.inv.Draw(Batch);
            Data.TpRec = new Rectangle(Data.ScreenW / 2, 0, 40, 5);



            for (int i = 0; i < 9; i++)
            {
                Batch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW / 2 + 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                Batch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }


            for (int i = 0; i < Data.ScreenW / grass.Width; i++)
            {
                for (int j = 0; j < Data.ScreenH / grass.Height; j++)
                {
                    Batch.Draw(grass, Vector2.Zero + new Vector2(grass.Width * i, grass.Height * j), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (player.PlayerRec.Intersects(Data.TpRec))
            {
                Data.CurrentState = Data.Scenes.scene12;
                Data.Plypos.Y = 720 - 80;
            }
            

            player.Draw(Batch);
            born.Draw(Batch);
            h1.Draw(Batch);
            b1.Draw(Batch);
            b2.Draw(Batch);
            b3.Draw(Batch);
            b4.Draw(Batch);
            bin1.Draw(Batch);
            bin2.Draw(Batch);
            bin3.Draw(Batch);
            bush1.Drawbig(Batch);
            bush2.Drawbig(Batch);
            bush3.Drawbig(Batch);

        }

    }

}
