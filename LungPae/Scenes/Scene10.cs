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
    internal class Scene10 : Component
    {
        Texture2D Floor;
        Texture2D grass;
        Player player;
        AyDee Dee;
        Tree tree,tree2;
        NPC npc1, npc2, npc3;
        Building phar, h1, seven;
        Bush bush_1, bush_2, bush_3, bush_4;

        public Scene10()
        {
            
            //Shed = new Building(new Vector2(350, 150), 2f);
            Dee = new AyDee();
            npc1 = new NPC(0, 0.6f, 0.5f, new Vector2(950, 300));
            npc2 = new NPC(0, 0.6f, 0.5f, new Vector2(200, 520));
            npc3 = new NPC(0, 0.6f, 0.5f, new Vector2(300, 190));
            bush_1 = new Bush(new Vector2(0, 630), 0.2f);
            bush_2 = new Bush(new Vector2(90, 630), 0.2f);
            bush_3 = new Bush(new Vector2(180, 630), 0.2f);
            bush_4 = new Bush(new Vector2(270, 630), 0.2f);
            player = new Player();
            phar = new Building(new Vector2(0, 0), 0.3f);
            h1 = new Building(new Vector2(900, 360), 0.3f);
            seven = new Building(new Vector2(750, 20), 0.3f);
            tree = new Tree(new Vector2(300, 20),0.2f);
            tree2 = new Tree(new Vector2(400, 20), 0.2f);
            player.row = 4;
        }
        internal override void LoadContent(ContentManager Content)
        {
            npc1.Load(Content, "NPC", 4, 4, 0);
            npc2.Load(Content, "NPC", 4, 4, 0);
            npc3.Load(Content, "NPC", 4, 4, 0);
            bush_1.Load(Content);
            bush_2.Load(Content);
            bush_3.Load(Content);
            bush_4.Load(Content);
            Dee.Load(Content);
            phar.Load(Content, "pharmacy");
            h1.Load(Content, "House4");
            seven.Load(Content, "7-11");
            tree.Load(Content);
            tree2.Load(Content);
            Floor = Content.Load<Texture2D>("Floor");
            grass = Content.Load<Texture2D>("grass");
            player.LoadContent(Content);
        }
        internal override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            npc1.Update(gameTime);
            npc2.Update(gameTime);
            npc3.Update(gameTime);
            npc1.Npccheck(player);
            npc2.Npccheck(player);
            npc3.Npccheck(player);
            bush_1.Bushcheck(player);
            bush_2.Bushcheck(player);
            bush_3.Bushcheck(player);
            bush_4.Bushcheck(player);
            player.Collision(npc1.NpcRec);
            player.Collision(npc2.NpcRec);
            player.Collision(npc3.NpcRec);
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Data.ms = Mouse.GetState();
            tree.Treecheck(player);
            
            tree2.Treecheck(player);
            phar.CheckCollision(player);
            player.Collision(phar.ObjRecDown);
            h1.CheckCollision(player);
            player.Collision(h1.ObjRecDown);
            seven.CheckCollision(player);
            player.Collision(seven.ObjRecDown);

            if (player.PlayerRec.Intersects(Dee.deeTalkRec) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(Dee.deeTalkRec))
            {
                Dee.Talk = true;
                Data.CanControl = false;

            }
            if (player.PlayerRec.Intersects(npc1.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc1.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc2.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc2.talk = true;
                Data.CanControl = false;
            }
            if (player.PlayerRec.Intersects(npc3.NpcRecTalk) && Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(npc1.NpcRecTalk))
            {
                npc3.talk = true;
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
            for (int i = 0; i < 19; i++)
            {
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 40, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2 - 80, 0) + Data.PosTileY * i, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, Data.ScreenH - Floor.Height), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            _spriteBatch.Draw(Floor, new Vector2(Data.ScreenW / 2, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            h1.Draw(_spriteBatch);
            npc1.Draw(_spriteBatch, 0, 2);
            npc2.Draw(_spriteBatch, 2, 1);
            npc3.Draw(_spriteBatch, 3, 1);
            phar.Draw(_spriteBatch);
           
            seven.Draw(_spriteBatch);
            tree.Draw(_spriteBatch);
            tree2.Draw(_spriteBatch);
            bush_1.Drawbig(_spriteBatch);
            bush_2.Drawbig(_spriteBatch);
            bush_3.Drawbig(_spriteBatch);
            bush_4.Drawbig(_spriteBatch);

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
            if (npc1.talk == true)
            {
                npc1.Dialog(_spriteBatch);
            }
            if (npc2.talk == true)
            {
                npc2.Dialog(_spriteBatch);
            }
            if (npc3.talk == true)
            {
                npc3.Dialog(_spriteBatch);
            }
        }
    }
}
