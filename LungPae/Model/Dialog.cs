using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.Model
{
    internal class Dialog
    {
        Texture2D DialogBox;
        String msg = " ",ans1,ans2,ans3;
        SpriteFont Myfont, Name;
        Vector2 DialogPos;
        Vector2 Ans1Pos, Ans2Pos,Ans3Pos;
        public Rectangle Ans1Rec, Ans2Rec,Ans3Rec;
        public Rectangle DialogRec;
        
        
        
        public Dialog() 
        {
            DialogPos = new Vector2(400,400);

        } 
        internal void LoadContent(ContentManager content)
        {
            DialogBox = content.Load<Texture2D>("DialogBox");
            Myfont = content.Load<SpriteFont>("Font");
            
        }
        internal void LoadContent(ContentManager content,string asset)
        {
            DialogBox = content.Load<Texture2D>(asset);
            Myfont = content.Load<SpriteFont>("Font");
            Name = content.Load<SpriteFont>("Name");
            


        }

        

        internal void DrawPerson(SpriteBatch spriteBatch,string name) 
        {
            DialogRec = new Rectangle((int)DialogPos.X-150, (int)DialogPos.Y, DialogBox.Width, DialogBox.Height+60);
            spriteBatch.Draw(DialogBox, new Vector2(DialogPos.X-150,DialogPos.Y ),null, Color.White,0,Vector2.Zero,1,SpriteEffects.None,0.8f);
            spriteBatch.DrawString(Myfont, msg, new Vector2(DialogPos.X -100 ,DialogPos.Y + 50), Color.Black,0,Vector2.Zero,1,SpriteEffects.None,0.9f);
            spriteBatch.DrawString(Name, name, new Vector2(DialogPos.X+530, DialogPos.Y+240), Color.BlueViolet, 0, Vector2.Zero, 1, 0, 0.9f);
        }
        internal void Draw(SpriteBatch spriteBatch)
        {
            DialogRec = new Rectangle((int)DialogPos.X, (int)DialogPos.Y, DialogBox.Width, DialogBox.Height);
            spriteBatch.Draw(DialogBox, DialogPos, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.8f);
            spriteBatch.DrawString(Myfont, msg, new Vector2(DialogPos.X + 50, DialogPos.Y + 50), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
        }
        internal void DrawAns2(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(Myfont, ans1, Ans1Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(Myfont, ans2, Ans2Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
            
            Ans1Pos = new Vector2(DialogPos.X - 100, DialogPos.Y + 200);
            Ans2Pos = new Vector2(DialogPos.X - 100, DialogPos.Y + 230);
            
            Ans1Rec = new Rectangle((int)Ans1Pos.X, (int)Ans1Pos.Y, 80, 30);
            Ans2Rec = new Rectangle((int)Ans2Pos.X, (int)Ans2Pos.Y, 80, 30);
        }
        internal void DrawAns(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(Myfont, ans1, Ans1Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(Myfont, ans2, Ans2Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);

            Ans1Pos = new Vector2(DialogPos.X+50 , DialogPos.Y + 200);
            Ans2Pos = new Vector2(DialogPos.X+50, DialogPos.Y + 230);

            Ans1Rec = new Rectangle((int)Ans1Pos.X, (int)Ans1Pos.Y, 30, 30);
            Ans2Rec = new Rectangle((int)Ans2Pos.X, (int)Ans2Pos.Y, 30, 30);
        }
        internal void DrawAns3(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(Myfont, ans1, Ans1Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(Myfont, ans2, Ans2Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
            spriteBatch.DrawString(Myfont, ans3, Ans3Pos, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
            Ans1Pos = new Vector2(DialogPos.X - 100, DialogPos.Y + 200);
            Ans2Pos = new Vector2(DialogPos.X - 100, DialogPos.Y + 230);
            Ans3Pos = new Vector2(DialogPos.X - 100, DialogPos.Y + 260);
            Ans1Rec = new Rectangle((int)Ans1Pos.X, (int)Ans1Pos.Y, 30, 30);
            Ans2Rec = new Rectangle((int)Ans2Pos.X, (int)Ans2Pos.Y, 30, 30);
            Ans3Rec = new Rectangle((int)Ans3Pos.X, (int)Ans3Pos.Y, 30, 30);
        }
        internal void ChangeDialog( String msg) //รับstringมาเปลี่ยนข้อความ
        {
            this.msg = msg; 
        }
        internal void Answer(string ans1, string ans2)
        {
            this.ans1 = ans1;
            this.ans2 = ans2;
            
        }
        internal void Answer(string ans1, string ans2,string ans3)
        {
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
        }
    }
}
