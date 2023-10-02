using lungpae;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Model;

using Microsoft.Xna.Framework.Input;

namespace LungPae.Core
{
    public static class Data
    {
        public static int ScreenW = 1280;
        public static int ScreenH = 720;
        public static bool Exit = false;
        public enum Scenes { scene1, scene2, scene3, scene4, scene5, scene6, scene7, scene8, scene9, scene10,
                             scene11, scene12, scene13, scene14, scene15, scene16, scene17, scene18, scene19, scene20,
                             minigame1,minigame2,minigame3,
                             Blackscreen}
        
        public static Scenes CurrentState = Scenes.scene3;
        public static int DialogCount = 0 ;

        public static bool CanControl = true; //การควบคุมการเดินplayer
        public static bool cutscene1 = true;

        //MiniGames
        public static bool Minigame1 = false , Minigame1Finish = false;

        //Quests
        public static bool Quest1 = false, Q1Finish = false, Panties = false;
        public static bool Quest2 = true, Quest2Finish = false ,mask = false,stick = false, OnFire = false ;


        public static Rectangle MRec;
        public static Rectangle TpRec, TpRec2 ;

        public static Vector2 Plypos;


        public static MouseState ms, Oldms;


        public static Inventory inv = new Inventory();
        
        public static Item Pantie = new Item();
        public static Item Watermelon = new Item();
        public static Item Matchstick = new Item();
        public static Item RobberHAt = new Item();
       
        //เพิ่มถังขยะ
        //เพิ่มกองไฟ ทำ Quest2
        //เพิ่มลู่วิ่ง กำแพง คนดู เปลี่ยนตอนชนะเป็นรูปอื่นในOther asset
    }
}
