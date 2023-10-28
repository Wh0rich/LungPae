using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Core;
using LungPae.Model;
using LungPae.Scenes;
using LungPae.Minigame;
using LungPae.CutScenes;

namespace LungPae.Manager
{

    internal partial class GameStateManager : Component // เรียกใช้แต่ละscene
    {

        private Scene1 s1 = new Scene1();
        private Scene2 s2 = new Scene2();
        private Scene3 s3 = new Scene3();
        private Scene4 s4 = new Scene4();
        private Scene5 s5 = new Scene5();
        private Scene6 s6 = new Scene6();
        private Scene7 s7 = new Scene7();
        private Scene8 s8 = new Scene8();
        private Scene9 s9 = new Scene9();
        private Scene10 s10 = new Scene10();
        private Scene11 s11 = new Scene11();
        private Scene12 s12 = new Scene12();
        private Scene13 s13 = new Scene13();
        private Scene14 s14 = new Scene14();
        private Scene15 s15 = new Scene15();
        private Scene16 s16 = new Scene16();
        private Cowboy c1 = new Cowboy();
        private RunningGame m1 = new RunningGame();
        private BlackScreen b = new BlackScreen();
        private ShotDog shot = new ShotDog();
    
        
        internal override void LoadContent(ContentManager Content)
        {
           s1.LoadContent( Content);
           s2.LoadContent( Content);
           s3.LoadContent( Content);
           s4.LoadContent( Content);
           s5.LoadContent( Content);
           s6.LoadContent( Content);
           s7.LoadContent( Content);
           s8.LoadContent( Content);
           s9.LoadContent( Content);
           s10.LoadContent(Content);
           s11.LoadContent(Content);
           s12.LoadContent(Content);
           s13.LoadContent( Content);
           s14.LoadContent( Content);
           s15.LoadContent( Content);
           s16.LoadContent(Content);
           c1.LoadContent(Content);
           m1.LoadContent( Content);
           b.LoadContent( Content);
           shot.LoadContent( Content); 
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.scene1:

                    s1.Update(gameTime);
                    
                    break;
                case Data.Scenes.scene2: 
                    s2.Update(gameTime);
                    break;
                case Data.Scenes.scene3:
                    s3.Update(gameTime);
                    break;
                case Data.Scenes.scene4:
                    s4.Update(gameTime);
                    break;
                case Data.Scenes.scene5:
                    s5.Update(gameTime);
                    break;
                case Data.Scenes.scene6:
                    s6.Update(gameTime);
                    break;
                case Data.Scenes.scene7:
                    s7.Update(gameTime);
                    break;
                case Data.Scenes.scene8:
                    s8.Update(gameTime);
                    break;
                case Data.Scenes.scene9:
                    s9.Update(gameTime);
                    break;
                case Data.Scenes.scene10:
                    s10.Update(gameTime);
                    break;
                case Data.Scenes.scene11:
                    s11.Update(gameTime);
                    break;
                case Data.Scenes.scene12:
                    s12.Update(gameTime);
                    break;
                case Data.Scenes.scene13:
                    s13.Update(gameTime);
                    break;
                case Data.Scenes.scene14:
                    s14.Update(gameTime);
                    break;
                case Data.Scenes.scene15:
                    s15.Update(gameTime);
                    break;
                case Data.Scenes.scene16:
                    s16.Update(gameTime);
                    break;
                case Data.Scenes.Cowboy:
                    c1.Update(gameTime);
                    break;
                case Data.Scenes.minigame1:
                    m1.Update(gameTime);
                    break;
                case Data.Scenes.Blackscreen:
                    b.Update(gameTime);
                    break;
                case Data.Scenes.ShotDog:
                    shot.Update(gameTime);
                    break;
            }
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.scene1:
                    s1.Draw(spriteBatch);

                    break;
                case Data.Scenes.scene2:
                    s2.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene3:
                    s3.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene4:
                    s4.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene5:
                    s5.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene6:
                    s6.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene7:
                    s7.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene8:
                     s8.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene9:
                    s9.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene10:
                    s10.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene11:
                    s11.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene12:
                    s12.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene13:
                    s13.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene14:
                    s14.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene15:
                    s15.Draw(spriteBatch);
                    break;
                case Data.Scenes.scene16:
                    s16.Draw(spriteBatch);
                    break;
                case Data.Scenes.Cowboy:
                    c1.Draw(spriteBatch);
                    break;
                case Data.Scenes.minigame1:
                    m1.Draw(spriteBatch);
                    break;
                case Data.Scenes.Blackscreen:
                    b.Draw(spriteBatch);
                    break;
                 case Data.Scenes.ShotDog:
                    shot.Draw(spriteBatch);
                    break;

            }
        }

    }
}
