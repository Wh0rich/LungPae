using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LungPae.CutScenes
{
    internal class BlackScreen : Component
    {
        Texture2D bg;
        Dialog dialog;
        
        public BlackScreen() 
        { 
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager Content)
        {
            bg = Content.Load<Texture2D>("Blackbg");
            dialog.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg,Vector2.Zero, Color.White);
            if(Data.Quest2Finish == true )
            {
                dialog.Draw(spriteBatch);
                dialog.ChangeDialog("Fire in the hole");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec))
                {
                    Data.OnFire = false;
                    Data.CurrentState = Data.Scenes.scene5;
                    Data.CanControl = true;
                }
            }
        }
    }
}
