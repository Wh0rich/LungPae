using LungPae.Core;
using LungPae.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace LungPae.Scenes
{
    internal class Scene17 : Component
    {
        Game1 game1;
        Texture2D bg;
        Dialog dialog;
        public Scene17()
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
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            Console.WriteLine(Data.MRec);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, Vector2.Zero, Color.Black);
            switch (Data.DialogCount)
            {
                case 0:

                    dialog.Draw(spriteBatch);
                    dialog.ChangeDialog("The game has developed to this point.");
                    if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                    {
                        Data.DialogCount++;
                    }
                    Data.Oldms = Data.ms;
                    break;
                case 1:

                    dialog.DrawPerson(spriteBatch, "Maelek");
                    dialog.ChangeDialog("Thanks for traveling with Pae");
                    if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                    {
                        game1.Exit();

                    }
                    Data.Oldms = Data.ms;
                    break;
            }
        }
    }
}

