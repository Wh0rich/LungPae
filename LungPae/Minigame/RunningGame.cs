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
        Texture2D bg1,bg2,bg3,wall,logo,grass;
        Vector2 bgpos = new Vector2(0,230);
        Vector2 Tile = new Vector2(280, 0);
        KeyboardState ks,oldks;
        Vector2 playerpos = new Vector2(0, 200); // ตำแหน่งที่ใช้ในminigame
        Vector2 Mixpos = new Vector2(0,350);
        Vector2 Finish = new Vector2(5000, 0);
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        float speedMix, speedPlayer;
        float temp;

        bool finish = false;
        bool A_isPressed = false;
        bool D_isPressed = false;
        bool teach = true   ;

        public RunningGame()
        {
            npcMan = new AnimatedTexture(Vector2.Zero,0,1,0.2f);
            npcLady = new AnimatedTexture(Vector2.Zero, 0, 1, 0.3f);
            player = new Player(0,1,0.5f);
            mixer = new Mixer(0,1,0.5f);
            dialog = new Dialog();
        }
        internal override void LoadContent(ContentManager content)
        {
            mixer.Load(content);
            player.LoadContent(content);
            dialog.LoadContent(content);
            bg1 = content.Load<Texture2D>("StartLuwing");
            bg2 = content.Load<Texture2D>("Luwing");
            bg3 = content.Load<Texture2D>("FinishLuwing");
            wall = content.Load<Texture2D>("StadiumWall");
            logo = content.Load<Texture2D>("ResultLOGO");
            grass = content.Load<Texture2D>("grass");
            npcMan.Load(content, "NPCMan",2,1,4);
            npcLady.Load(content, "NPCLady", 2, 1, 3);
            speedMix =4f ;
            speedPlayer = 1f;
            player.row = 4;
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
                if(finish == false)
                {
                    mixer.Mixani.UpdateFrame(elapsed);
                    player.player.UpdateFrame(elapsed);
                }
               
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
            for (int i = 0; i < 5000 / grass.Width + 560; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Batch.Draw(grass, (new Vector2(0, 510) + new Vector2(grass.Width * i, grass.Height * j) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            for (int i = 0; i < 5000 / grass.Width + 560; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Batch.Draw(grass, (new Vector2(0, 0) + new Vector2(grass.Width * i, grass.Height * j) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0f);
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                Mixpos.X = 4990;
                cameraPos.X = 4500;
            }
            for (int i = 0; i < 5000 / wall.Width + 560; i++)
            {
                Batch.Draw(wall, (new Vector2(0 + wall.Width * i, 230 - wall.Height) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.4f);
            }
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
                finish = true;
                Batch.Draw(logo, new Vector2(Data.ScreenW / 2 -250, Data.ScreenH / 2-240), new Rectangle(0,0,logo.Width,logo.Height/2), Color.White, 0, Vector2.Zero, 1, 0, 0.9f);
                player.player.Frame = 1;
                dialog.Draw(Batch);
                dialog.ChangeDialog("press Enter");
                if  (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Data.CurrentState = Data.Scenes.scene2;
                    Data.CanControl = true;
                    
                } 
            }
           if(Mixpos.X > Finish.X)
            {
                speedMix = 0;
                speedPlayer = 0;
                finish = true;
                Batch.Draw(logo, new Vector2(Data.ScreenW / 2 - 250, Data.ScreenH / 2 - 240), new Rectangle(0, logo.Width/2, logo.Width, logo.Height / 2), Color.White, 0, Vector2.Zero, 1, 0, 0.9f);
                dialog.Draw(Batch);
                dialog.ChangeDialog("press Enter");
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Data.CurrentState = Data.Scenes.scene2;
                    Data.CanControl = true;
                    
                }
            }
            mixer.Drawmini(Batch,Mixpos - cameraPos);
            player.Drawmini(Batch,playerpos - cameraPos);
            Batch.Draw(bg1, (bgpos - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
            for (int i = 1; i < 5000 / 280; i++)
            {
                Batch.Draw(bg2, (bgpos + (Tile * i) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
            }
            Batch.Draw(bg3, (bgpos + (Tile * 17) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
            Batch.Draw(bg2, (bgpos + (Tile * 18) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
            Batch.Draw(bg2, (bgpos + (Tile * 19) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
            Batch.Draw(bg2, (bgpos + (Tile * 20) - cameraPos) * scroll_factor, null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);


        }
    }
}
