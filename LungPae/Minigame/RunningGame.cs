using lungpae;
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
using System.Threading;
using System.Threading.Tasks;

namespace LungPae.Minigame
{
    internal class RunningGame : Component
    {
        Player player;
        AnimatedTexture npcMan,npcLady;
        Mixer mixer;
        Dialog dialog;
        Texture2D bg1,bg2,bg3;
        Vector2 bgpos;
        KeyboardState ks,oldks;
        Vector2 playerpos = new Vector2(0, 200); // ตำแหน่งที่ใช้ในminigame
        Vector2 Mixpos = new Vector2(0,350);
        Vector2 Finish = new Vector2(3000, 0);
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        float speedMix, speedPlayer;
        float temp;

        bool A_isPressed = false;
        bool D_isPressed = false;
        bool teach = true   ;

        public RunningGame()
        {
            npcMan = new AnimatedTexture(Vector2.Zero,0,1,0.4f);
            npcLady = new AnimatedTexture(Vector2.Zero, 0, 1, 0.4f);
            player = new Player(0,1,0.5f);
            mixer = new Mixer(0,1,0.5f);
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager content)
        {
            mixer.Load(content);
            player.LoadContent(content);
            dialog.LoadContent(content);
            bg1 = content.Load<Texture2D>("Luwing");
            npcMan.Load(content, "NPCMan",2,1,4);
            npcLady.Load(content, "NPCLady", 2, 1, 3);
            speedMix =3f ;
            speedPlayer = 1f;
        }
        internal override void Update(GameTime gameTime)
        {
            Console.WriteLine(speedPlayer);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ks = Keyboard.GetState();
            if (teach == false)
            {

                if (speedPlayer > 1 && A_isPressed == false || speedPlayer > 1 && D_isPressed == false || speedPlayer > 5)
                {
                    temp += elapsed;
                    player.player.UpdateFrame(elapsed);
                    player.row = 4;
                    if (temp > 0.5)
                    {
                        speedPlayer -= 0.5f;
                        cameraPos.X -= 0.5f;
                        temp = 0;
                    }
                }
                if (ks.IsKeyDown(Keys.D) && oldks.IsKeyUp(Keys.D))
                {
                    D_isPressed = true;
                }

                if (D_isPressed == true)
                {
                    if (ks.IsKeyDown(Keys.A) && oldks.IsKeyUp(Keys.A))
                    {
                        A_isPressed = true;
                    }
                }
                if (ks.IsKeyDown(Keys.A) && oldks.IsKeyUp(Keys.A))
                {
                    A_isPressed = true;
                }

                if (A_isPressed == true)
                {
                    if (ks.IsKeyDown(Keys.D) && oldks.IsKeyUp(Keys.D))
                    {
                        D_isPressed = true;
                    }
                }
                oldks = ks;
                if (A_isPressed == true && D_isPressed == true && speedPlayer < 5)
                {
                    speedPlayer += 0.4f;
                    A_isPressed = false;
                    D_isPressed = false;
                }
                if (playerpos.X - cameraPos.X > Data.ScreenW / 2 - player.player.FrameWidth)
                {
                    cameraPos.X += speedPlayer;
                }
                playerpos.X += speedPlayer;
                Mixpos.X += speedMix;
                Console.WriteLine("Player Pos (x,y ) " + playerpos);
                Console.WriteLine("Mix Pos (x,y ) " + Mixpos);
                Console.WriteLine("Cam Pos (x,y ) " + cameraPos);
            }
            npcMan.UpdateFrame(elapsed);
            npcLady.UpdateFrame(elapsed);
            
        }
        internal override void Draw(SpriteBatch Batch)
        {
            npcMan.DrawFrame(Batch,(new Vector2 (0,20) - cameraPos)* scroll_factor);
            npcLady.DrawFrame(Batch,(new Vector2 (15,80) - cameraPos) * scroll_factor);
            if (teach == true)
            {
                dialog.Draw(Batch);
                dialog.ChangeDialog("Press the A and D buttons alternately to increase speed\n\n\n press Enter to start");
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                   teach = false;
                }
            }
            if (playerpos.X > Finish.X)
            {
                speedMix = 0;
                speedPlayer = 0;
                dialog.Draw(Batch);
                dialog.ChangeDialog("Pae Win");
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Data.CurrentState = Data.Scenes.scene2;
                    Data.CanControl = true;
                } 
            }
           if(Mixpos.X > Finish.X)
            {
                speedMix = 0;
                speedPlayer = 0;
                dialog.Draw(Batch);
                dialog.ChangeDialog("Mixer Win");
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Data.CurrentState = Data.Scenes.scene2;
                    Data.CanControl = true;
                }
            }
            mixer.Drawmini(Batch,Mixpos - cameraPos);
            player.Drawmini(Batch,playerpos - cameraPos);
           //Batch.Draw(bg1, (bgpos - cameraPos) * scroll_factor , Color.White);
           //Batch.Draw(bg1, (bgpos - cameraPos) * scroll_factor + new Vector2(Data.ScreenW,0), Color.White);
        }
    }
}
