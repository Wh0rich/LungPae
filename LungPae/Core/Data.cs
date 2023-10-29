using lungpae;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungPae.Model;

using Microsoft.Xna.Framework.Input;
using LungPae.CutScenes;
using System.Security;

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
                             Blackscreen,ShotDog,Cowboy}
        
        public static Scenes CurrentState = Scenes.Cowboy;
        public static int DialogCount = 0 ;
        public static int Money = 0 ;

        public static bool CanControl = true; //การควบคุมการเดินplayer
        public static bool cutscene1 = true;
        public static bool fade = false;

        //MiniGames
        public static bool Minigame1 = false , Minigame1Finish = false;

        //Sup-Quest
        public static bool QuestLaab = false;
        public static bool Quest4 = false, Quest4Finish = false, leave =true;



        //Quests
        public static bool Quest1 = false, Q1Finish = false, Panties = false;
        public static bool Quest2 = true, Quest2Finish = false ,mask = false,stick = false, OnFire = false ;
        public static bool Quest3 = false, watermelon = false, slingshot = false, Quest3Finish = false;
        public static bool Quest5 = false, Quest5Finish = false;
        




        public static Rectangle MRec;
        public static Rectangle TpRec, TpRec2 , TpRec3, TpRec4;

        public static Vector2 Plypos;


        public static MouseState ms, Oldms;


        public static Inventory inv = new Inventory();
        
        public static Item Pantie = new Item();
        public static Item Watermelon = new Item();
        public static Item Matchstick = new Item();
        public static Item RobberHAt = new Item();
        public static Item Cash = new Item();
        public static Item Cash2 = new Item();
        public static Item Cash3 = new Item();
        public static Item Pork = new Item();
        public static Item Slingshot = new Item();
        public static Item Glasses = new Item();
        public static Item Joy = new Item();
        public static Item Sweater = new Item();

        public static BlackScreen bs = new BlackScreen();

        //เพิ่มถังขยะ
        //เพิ่มกองไฟ ทำ Quest2
        //เพิ่มลู่วิ่ง กำแพง คนดู เปลี่ยนตอนชนะเป็นรูปอื่นในOther asset
    }
}
