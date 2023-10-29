using LungPae.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Data;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel.Design;
using System.Timers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using LungPae.Model;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace LungPae.Minigame
{
    internal class Cowboy : Component
    {
        Song shoot;
        Song sound;


        Dialog dialog;
        Texture2D cowboy;
        Texture2D Hostage;
        Texture2D bg,floor;
        List<Vector2> Hospos = new List<Vector2>();
        List<Rectangle> HosRec = new List<Rectangle>();
        Texture2D Gun, FireGun;
        Texture2D wall;
        SpriteFont font,score;
        Vector2 wallpos = new Vector2(0,0);
        Vector2 Gunpos = new Vector2(750,374);
        List<Vector2> Cbpos = new List<Vector2>();
        List<Rectangle>CbRec = new List<Rectangle>();
        
        bool Add = false, Click =false;

        bool IsFinish = false, teach = true;
        bool count = false;
        bool Wave1 = false, Wave2 = false, Wave3 = false, Wave4 = false, Wave5 = false, Wave6 = false;
        int enermy;
        int Max_enermy = 6;
        int point, time;
        float temp , timer;
        int h, spawn;


        Random r = new Random();
        public Cowboy() 
        {
            
            dialog = new Dialog();
        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume = 0.3f;

        }
        internal override void LoadContent(ContentManager Content)
        {
            cowboy = Content.Load<Texture2D>("Cowboy");
            Gun = Content.Load<Texture2D>("Gun");
            FireGun = Content.Load<Texture2D>("GunFire");
            Hostage = Content.Load<Texture2D>("Hostage");
            wall = Content.Load<Texture2D>("StadiumWall");
            font = Content.Load<SpriteFont>("Wave");
            score = Content.Load<SpriteFont>("Font");
            bg = Content.Load<Texture2D>("cowboy-backgroud");
            floor = Content.Load<Texture2D>("floor");
            dialog.LoadContent(Content);

            this.sound = Content.Load<Song>("Cowboy_Standoff");
            this.shoot = Content.Load<Song>("Shoot");
            

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

        }
       
        internal override void Update(GameTime gameTime)
        {
            Data.ms = Mouse.GetState();
            Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;


            Console.WriteLine(timer);
            Console.WriteLine("enermy" + enermy);
            if (teach == false)
            {
                if (timer < 1)
                {
                    timer += elapsed;

                }
                if (timer > 1)
                {
                    timer = 1.0f;
                }



                //wave 1
                if (Wave1 == true&&Add == true)
                {
                    
                    time = 8;
                    enermy = 3;

                    for (int i = 0; i < enermy; i++)
                    {
                        Cbpos.Add(new Vector2(r.Next(0, 1100) + cowboy.Width, 220));
                        if (i != 0)
                        {
                            for (int j = 0; j < i;)
                            {
                                if ((int)Cbpos[i].X - (int)Cbpos[j].X <= 68 && (int)Cbpos[i].X - (int)Cbpos[j].X! > -69)
                                {
                                    Cbpos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }
                        }
                        CbRec.Add(new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height));
                    }
                    Add = false;
                }

                if (Wave1 == true)
                {

                    if (timer == 1)
                    {
                        time -= (int)timer;
                        timer = 0;
                    }
                    for (int i = 0; i < enermy;)
                    {
                        CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(CbRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Cbpos.Remove(Cbpos[i]);
                            CbRec.Remove(CbRec[i]);
                            enermy--;
                            point++;
                            
                        }

                        i++;
                       

                    }
                    if (enermy == 0 || time == 0)
                    {
                        time = 0;
                        if (enermy > 0)
                        {
                            for (int i = 0; i < enermy;)
                            {
                                CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                                Cbpos.Remove(Cbpos[i]);
                                CbRec.Remove(CbRec[i]);
                                enermy--;
                            }
                        }
                        temp += elapsed;
                        if (temp > 9)
                        {
                            
                            Wave1 = false;
                            Wave2 = true;
                            Add = true;
                            temp = 0;
                        }
                    }
                }

                //wave 2


                if (Wave2 == true && Add == true)
                {
                       
                    enermy = 4;
                    time = 7;
                    for (int i = 0; i < enermy; i++)
                    {
                        Cbpos.Add(new Vector2(r.Next(0, 1100) + cowboy.Width, 220));
                        if (i != 0)
                        {
                            for (int j = 0; j < i;)
                            {
                                if ((int)Cbpos[i].X - (int)Cbpos[j].X <= 68 && (int)Cbpos[i].X - (int)Cbpos[j].X! > -69)
                                {

                                    Cbpos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }


                        }
                        CbRec.Add(new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height));
                    }
                    Add = false;
                }

                if (Wave2 == true)
                {
                    if (timer == 1)
                    {
                        time -= (int)timer;
                        timer = 0;
                    }
                    for (int i = 0; i < enermy;)
                    {
                        CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(CbRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Cbpos.Remove(Cbpos[i]);
                            CbRec.Remove(CbRec[i]);
                            enermy--;
                            point++;
                        }

                        i++;


                    }
                    if (enermy == 0 || time == 0)
                    {
                        time = 0;
                        if (enermy > 0)
                        {
                            for (int i = 0; i < enermy;)
                            {
                                CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                                Cbpos.Remove(Cbpos[i]);
                                CbRec.Remove(CbRec[i]);
                                enermy--;
                            }
                        }
                        temp += elapsed;
                        if (temp > 9)
                        {
                            count = true;
                            Wave2 = false;
                            Wave3 = true;
                            Add = true;
                            temp = 0;
                        }

                    }
                }
                //wave 3
                if (Wave3 == true && Add == true)
                {
                    enermy = 7;
                    time = 6;
                    for (int i = 0; i < enermy; i++)
                    {
                        Cbpos.Add(new Vector2(r.Next(0, 1100) + cowboy.Width, 220));
                        if (i != 0)
                        {
                            for (int j = 0; j < i;)
                            {
                                if ((int)Cbpos[i].X - (int)Cbpos[j].X <= 68 && (int)Cbpos[i].X - (int)Cbpos[j].X! > -69)
                                {

                                    Cbpos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }


                        }
                        CbRec.Add(new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height));
                    }
                    Add = false;
                }

                if (Wave3 == true)
                {
                    if (timer == 1)
                    {
                        time -= (int)timer;
                        timer = 0;
                    }
                    for (int i = 0; i < enermy;)
                    {
                        CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(CbRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Cbpos.Remove(Cbpos[i]);
                            CbRec.Remove(CbRec[i]);
                            enermy--;
                            point++;
                        }

                        i++;


                    }
                    if (enermy == 0 || time == 0)
                    {
                        time = 0;
                        if (enermy > 0)
                        {
                            for (int i = 0; i < enermy;)
                            {
                                CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                                Cbpos.Remove(Cbpos[i]);
                                CbRec.Remove(CbRec[i]);
                                enermy--;
                            }
                        }
                        temp += elapsed;
                        if (temp > 9)
                        {
                            
                            Wave3 = false;
                            Wave4 = true;
                            Add = true;
                            temp = 0;
                        }

                    }
                }

                //Wave
                //4
                if (Wave4 == true && Add == true)
                {
                   
                    enermy = 8;
                    time = 5;

                    h = 2;
                    spawn = r.Next(5, enermy);

                    for (int i = 0; i < enermy; i++)
                    {
                        Cbpos.Add(new Vector2(r.Next(0, 1100) + cowboy.Width, 220));
                        if (i != 0)
                        {
                            for (int j = 0; j < i;)
                            {
                                if ((int)Cbpos[i].X - (int)Cbpos[j].X <= 68 && (int)Cbpos[i].X - (int)Cbpos[j].X! > -69)
                                {

                                    Cbpos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }


                        }
                        CbRec.Add(new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height));
                    }

                    for (int i = 0; i < h; i++)
                    {
                        Hospos.Add(new Vector2(r.Next(0, 1100) + Hostage.Width, 220));
                        if (i <= 0)
                        {
                            for (int j = 0; j < enermy;)
                            {
                                if ((int)Hospos[i].X - (int)Cbpos[j].X <= 68 && (int)Hospos[i].X - (int)Cbpos[j].X! > -68)
                                {

                                    Hospos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }

                        }
                        HosRec.Add(new Rectangle((int)Hospos[i].X, (int)Hospos[i].Y, Hostage.Width, Hostage.Height));
                    }


                    Add = false;
                }

                if (Wave4 == true)
                {
                    if (timer == 1)
                    {
                        time -= (int)timer;
                        timer = 0;
                    }
                    for (int i = 0; i < enermy;)
                    {
                        CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(CbRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Cbpos.Remove(Cbpos[i]);
                            CbRec.Remove(CbRec[i]);
                            enermy--;
                            point++;
                        }

                        i++;
                    }

                    for (int i = 0; i < h;)
                    {
                        HosRec[i] = new Rectangle((int)Hospos[i].X, (int)Hospos[i].Y, Hostage.Width, Hostage.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(HosRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Hospos.Remove(Hospos[i]);
                            HosRec.Remove(HosRec[i]);
                            h--;
                            point -= 5;
                        }

                        i++;
                    }

                    if (h > 0 && time < 1)
                    {
                        for (int i = 0; i < h;)
                        {
                            Hospos.Remove(Hospos[i]);
                            HosRec.Remove(HosRec[i]);
                            h--;
                        }
                    }


                    if (enermy == 0 || time == 0)
                    {
                        time = 0;
                        if (enermy > 0)
                        {
                            for (int i = 0; i < enermy;)
                            {
                                CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                                Cbpos.Remove(Cbpos[i]);
                                CbRec.Remove(CbRec[i]);
                                enermy--;
                            }
                        }
                        temp += elapsed;
                        if (temp > 9)
                        {
                            
                            Wave4 = false;
                            Wave5 = true;
                            Add = true;
                            temp = 0;
                        }

                    }
                }
                // Wave 5
                if (Wave5 == true && Add == true)
                {
                    
                    enermy = 10;
                    time = 5;

                    h = r.Next(2, 3);
                    spawn = r.Next(7, enermy);

                    for (int i = 0; i < enermy; i++)
                    {
                        Cbpos.Add(new Vector2(r.Next(0, 1100) + cowboy.Width, 220));
                        if (i != 0)
                        {
                            for (int j = 0; j < i;)
                            {
                                if ((int)Cbpos[i].X - (int)Cbpos[j].X <= 68 && (int)Cbpos[i].X - (int)Cbpos[j].X! > -69)
                                {

                                    Cbpos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }


                        }
                        CbRec.Add(new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height));
                    }

                    for (int i = 0; i < h; i++)
                    {
                        Hospos.Add(new Vector2(r.Next(0, 1100) + Hostage.Width, 220));
                        if (i <= 0)
                        {
                            for (int j = 0; j < enermy;)
                            {
                                if ((int)Hospos[i].X - (int)Cbpos[j].X <= 68 && (int)Hospos[i].X - (int)Cbpos[j].X! > -68)
                                {

                                    Hospos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }

                        }
                        HosRec.Add(new Rectangle((int)Hospos[i].X, (int)Hospos[i].Y, Hostage.Width, Hostage.Height));
                    }


                    Add = false;
                }

                if (Wave5 == true)
                {
                    if (timer == 1)
                    {
                        time -= (int)timer;
                        timer = 0;
                    }
                    for (int i = 0; i < enermy;)
                    {
                        CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(CbRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Cbpos.Remove(Cbpos[i]);
                            CbRec.Remove(CbRec[i]);
                            enermy--;
                            point++;
                        }

                        i++;
                    }

                    for (int i = 0; i < h;)
                    {
                        HosRec[i] = new Rectangle((int)Hospos[i].X, (int)Hospos[i].Y, Hostage.Width, Hostage.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(HosRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Hospos.Remove(Hospos[i]);
                            HosRec.Remove(HosRec[i]);
                            h--;
                            point -= 5;
                        }

                        i++;
                    }

                    if (h > 0 && time < 1)
                    {
                        for (int i = 0; i < h;)
                        {
                            Hospos.Remove(Hospos[i]);
                            HosRec.Remove(HosRec[i]);
                            h--;
                        }
                    }


                    if (enermy == 0 || time == 0)
                    {
                        time = 0;
                        if (enermy > 0)
                        {
                            for (int i = 0; i < enermy;)
                            {
                                CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                                Cbpos.Remove(Cbpos[i]);
                                CbRec.Remove(CbRec[i]);
                                enermy--;
                            }
                        }
                        temp += elapsed;
                        if (temp > 9)
                        {
                            
                            Wave5 = false;
                            Wave6 = true;
                            Add = true;
                            temp = 0;
                        }

                    }
                }
                //Wave 6
                if (Wave6 == true && Add == true)
                {
                    
                    enermy = 10;
                    time = 5;

                    h = r.Next(3, 5);
                    spawn = r.Next(7, enermy);

                    for (int i = 0; i < enermy; i++)
                    {
                        Cbpos.Add(new Vector2(r.Next(0, 1100) + cowboy.Width, 220));
                        if (i != 0)
                        {
                            for (int j = 0; j < i;)
                            {
                                if ((int)Cbpos[i].X - (int)Cbpos[j].X <= 68 && (int)Cbpos[i].X - (int)Cbpos[j].X! > -69)
                                {

                                    Cbpos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }


                        }
                        CbRec.Add(new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height));
                    }

                    for (int i = 0; i < h; i++)
                    {
                        Hospos.Add(new Vector2(r.Next(0, 1100) + Hostage.Width, 220));
                        if (i <= 0)
                        {
                            for (int j = 0; j < enermy;)
                            {
                                if ((int)Hospos[i].X - (int)Cbpos[j].X <= 68 && (int)Hospos[i].X - (int)Cbpos[j].X! > -68)
                                {

                                    Hospos[i] = new Vector2(r.Next(0, 1100) + cowboy.Width, 220);
                                    j = -1;
                                }
                                j++;
                            }

                        }
                        HosRec.Add(new Rectangle((int)Hospos[i].X, (int)Hospos[i].Y, Hostage.Width, Hostage.Height));
                    }


                    Add = false;
                }

                if (Wave6 == true)
                {

                    if (timer == 1)
                    {
                        time -= (int)timer;
                        timer = 0;
                    }
                    for (int i = 0; i < enermy;)
                    {
                        CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(CbRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Cbpos.Remove(Cbpos[i]);
                            CbRec.Remove(CbRec[i]);
                            enermy--;
                            point++;
                        }

                        i++;
                    }

                    for (int i = 0; i < h;)
                    {
                        HosRec[i] = new Rectangle((int)Hospos[i].X, (int)Hospos[i].Y, Hostage.Width, Hostage.Height);
                        if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(HosRec[i]) == true && Data.Oldms.LeftButton == ButtonState.Released)
                        {
                            Hospos.Remove(Hospos[i]);
                            HosRec.Remove(HosRec[i]);
                            h--;
                            point -= 5;
                        }

                        i++;
                    }

                    if (h > 0 && time < 1)
                    {
                        for (int i = 0; i < h;)
                        {
                            Hospos.Remove(Hospos[i]);
                            HosRec.Remove(HosRec[i]);
                            h--;
                        }
                    }


                    if (enermy == 0 || time == 0)
                    {
                        time = 0;
                        if (enermy > 0)
                        {
                            for (int i = 0; i < enermy;)
                            {
                                CbRec[i] = new Rectangle((int)Cbpos[i].X, (int)Cbpos[i].Y, cowboy.Width, cowboy.Height);
                                Cbpos.Remove(Cbpos[i]);
                                CbRec.Remove(CbRec[i]);
                                enermy--;
                            }
                        }
                        temp += elapsed;
                        if (temp > 9)
                        {
                            
                            IsFinish = true;
                        }

                    }
                }

                if (Data.ms.LeftButton == ButtonState.Pressed && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Click = true;
                }
                Data.Oldms = Data.ms;
                if (Data.ms.LeftButton == ButtonState.Released &&Data.Oldms.LeftButton == ButtonState.Released)
                {
                        Click = false;
                }

                Data.Oldms = Data.ms;
            }
            if(teach == true)
            {
                Data.ms = Mouse.GetState();
                Data.MRec = new Rectangle(Data.ms.X, Data.ms.Y, 1, 1);
            }

            

        }
        
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(score, "Score : " + point.ToString(), new Vector2(0, 20), Color.White, 0, Vector2.Zero, 1, 0, 0.9f);
            
            if (teach == true)
            {
                
                dialog.Draw(spriteBatch);
                dialog.ChangeDialog("There are 6 Waves\nUse Mouse to Aim \nKill Cowboy 1 point\nKill Hostage -5 point\nCollect 30 points to receive rewards.");
                if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                {
                    Wave1 = true;
                    Add = true;
                    teach = false;

                }
                Data.Oldms = Data.ms;
            }
            if (enermy <= Max_enermy)
            {
                for (int i = 0; i < enermy; i++)
                {
                    spriteBatch.Draw(cowboy, Cbpos[i], null, Color.White, 0, Vector2.Zero, 1, 0, 0.4f);
                    if (enermy < spawn)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            spriteBatch.Draw(Hostage, Hospos[j], null, Color.White, 0, Vector2.Zero, 1, 0, 0.4f);
                        }
                        
                    }

                }
            }
            if(enermy > Max_enermy)
            {
                for (int i = 0; i < Max_enermy; i++)
                {
                    spriteBatch.Draw(cowboy, Cbpos[i], null, Color.White, 0, Vector2.Zero, 1, 0, 0.4f);
                    if (enermy < spawn)
                    {
                        for (int j = 0; j < h; j++)
                        {
                            spriteBatch.Draw(Hostage, Hospos[j], null, Color.White, 0, Vector2.Zero, 1, 0, 0.4f);
                            
                        }

                    }
                }
            }
            if (time>0)
            {
                spriteBatch.DrawString(score, "Time : " + time.ToString(), new Vector2(640, 20), Color.White, 0, Vector2.Zero, 1, 0, 0.9f);
            }

            if (Wave1 ==true && temp >0 )
            {
               
                if (temp > 0&& temp !<6)
                {
                   
                    
                    spriteBatch.DrawString(font, "Wave 2", new Vector2(520, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                    
                }
                
                if( temp >6 && temp !< 7)
                {
                    
                    spriteBatch.DrawString(font, "3", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 7 && temp!< 8)
                {
                    spriteBatch.DrawString(font, "2", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 8 && temp!< 9)
                {
                    spriteBatch.DrawString(font, "1", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                    
                }
            }

            if (Wave2 == true && temp > 0)
            {
                if (temp > 0 && temp! < 6)
                {
                    count = true;
                    spriteBatch.DrawString(font, "Wave 3", new Vector2(520, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }

                if (temp > 6 && temp! < 7)
                {
                    spriteBatch.DrawString(font, "3", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 7 && temp! < 8)
                {
                    spriteBatch.DrawString(font, "2", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 8 && temp! < 9)
                {
                    spriteBatch.DrawString(font, "1", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                    count = false;
                }
            }
            if (Wave3 == true && temp > 0)
            {
                if (temp > 0 && temp! < 6)
                {
                    spriteBatch.DrawString(font, "Wave 4", new Vector2(520, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }

                if (temp > 6 && temp! < 7)
                {
                    spriteBatch.DrawString(font, "3", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 7 && temp! < 8)
                {
                    spriteBatch.DrawString(font, "2", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 8 && temp! < 9)
                {
                    spriteBatch.DrawString(font, "1", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
            }
            if (Wave4 == true && temp > 0)
            {
                if (temp > 0 && temp! < 6)
                {
                    spriteBatch.DrawString(font, "Wave 5", new Vector2(520, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }

                if (temp > 6 && temp! < 7)
                {
                    spriteBatch.DrawString(font, "3", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 7 && temp! < 8)
                {
                    spriteBatch.DrawString(font, "2", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 8 && temp! < 9)
                {
                    spriteBatch.DrawString(font, "1", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
            }
            if (Wave5 == true && temp > 0)
            {
                if (temp > 0 && temp! < 6)
                {
                    spriteBatch.DrawString(font, "Last Wave ", new Vector2(520, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }

                if (temp > 6 && temp! < 7)
                {
                    spriteBatch.DrawString(font, "3", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 7 && temp! < 8)
                {
                    spriteBatch.DrawString(font, "2", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                if (temp > 8 && temp! < 9)
                {
                    spriteBatch.DrawString(font, "1", new Vector2(620, 50), Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
            }
            if(IsFinish == true)
            {
                if (point > 30)
                {
                    dialog.Draw(spriteBatch);
                    dialog.ChangeDialog("Congratulations,you are one of the world.");
                    if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                    {
                        Data.CurrentState = Data.Scenes.scene15;
                        Data.CanControl = true;
                        
                    }
                    Data.Oldms = Data.ms;
                }
                if (point < 30)
                {
                    dialog.Draw(spriteBatch);
                    dialog.ChangeDialog("Try Again.");
                    if (Data.ms.LeftButton == ButtonState.Pressed && Data.MRec.Intersects(dialog.DialogRec) && Data.Oldms.LeftButton == ButtonState.Released)
                    {
                        Data.CurrentState = Data.Scenes.scene15;
                        Data.CanControl = true;

                    }
                    Data.Oldms = Data.ms;
                }
            }

            for (int i = 0; i < 1280 / wall.Width +1; i++)
            {
                spriteBatch.Draw(wall, new Vector2(0 + wall.Width * i, 300), null, Color.White, 0, Vector2.Zero, 1, 0, 0.5f);
            }
            for (int i = 0; i < 80 / floor.Width + floor.Width; i++)
            {
                for (int j =0;j < (720 - 300 + wall.Height) /floor.Height;j++)
                {
                    spriteBatch.Draw(floor, new Vector2(0,300+ wall.Height) + new Vector2(floor.Width * i, floor.Height*j), null, Color.White, 0, Vector2.Zero, 1, 0, 0.2f);
                }
                
            }
            spriteBatch.Draw(bg, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, 0, 0.1f);

            //var instance1 = sound[0].CreateInstance();
            //var instance2 = sound[1].CreateInstance();

            if (Click == false)
            {
                
                spriteBatch.Draw(Gun, Gunpos, null, Color.White, 0, Vector2.Zero, 0.5f, 0, 0.5f);
            }
            if (Click ==true)
            {
                MediaPlayer.Play(shoot);
                spriteBatch.Draw(FireGun, Gunpos, null, Color.White, 0, Vector2.Zero, 0.5f, 0, 0.5f);
            }
            Data.Oldms = Data.ms;
            if (count == true)
            {
                //MediaPlayer.Play(sound);

            }
            if (count == false)
            {
                

            }

        }
    }
}
