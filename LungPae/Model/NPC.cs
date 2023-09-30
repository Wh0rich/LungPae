using lungpae;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LungPae.Core;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Xna.Framework.Input;

namespace LungPae.Model
{
    internal class NPC
    {
        AnimatedTexture npc;
        Chin chin;
        Dialog dialog;
        public Rectangle NpcRec, NpcRecTop, NpcRecTalk;
        public Vector2 Pos;
        public int row=2;
        float scale, depth;
        public bool talk = false;
        public bool checkCollision = false;
        
        public NPC(float Rotation,float Scale, float Depth,Vector2 Pos)
        {
            npc = new AnimatedTexture(Vector2.Zero,Rotation,Scale,Depth);
            this.Pos = Pos;
            this.scale = Scale;
            
            scale = scale * 100;
            chin = new Chin();
            dialog = new Dialog();
        }

        internal void Load(ContentManager content,string name,int Frame ,int FrameRow,int FramePerSec)
        {
            npc.Load(content, name, Frame, FrameRow, FramePerSec);
            dialog.LoadContent(content);
            
        }
        internal void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            npc.UpdateFrame(elapsed);  
            NpcRec = new Rectangle((int)Pos.X, (int)Pos.Y + 40, npc.FrameWidth*(int)scale / 100 , npc.FrameHeight*(int)scale / 100);
            NpcRecTop = new Rectangle((int)Pos.X, (int)Pos.Y, npc.FrameWidth * (int)scale / 100, (npc.FrameHeight * (int)scale / 100) - 75);
            NpcRecTalk = new Rectangle((int)Pos.X, (int)Pos.Y, npc.FrameWidth * (int)scale / 100, (npc.FrameHeight * (int)scale / 100));

            if (talk == true )
            {
                dialog.Update(gameTime);
            }
            if (checkCollision == true)
            {
                npc.Depth = 0.6f;

                checkCollision = false;
            }
            else
            {
                npc.Depth = 0.4f;
            }

        }
        internal void Npccheck(Player player)
        {
            if (NpcRecTop.Intersects(player.PlayerRec))
            {
                checkCollision = true;
            }
        }

        internal void DrawFrame(SpriteBatch spriteBatch,int Frame)
        {
            npc.DrawFrame(spriteBatch, Frame, Pos);
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            npc.DrawFrame(spriteBatch, Pos, row);
        }
        public void Dialog(SpriteBatch Batch)
        {
            if (talk == true )
            {
                dialog.Draw(Batch);
                dialog.ChangeDialog("Hello");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    talk = false;
                    Data.CanControl = true;
                    
                }
                Data.Oldms = Data.ms;
            }
        }
    }
}
