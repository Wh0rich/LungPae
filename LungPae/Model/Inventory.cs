using LungPae.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LungPae.Model
{
    public class Inventory 
    {
        
        int Max_slot = 10;
        int slot = 0;
        int Slot_size = 100;
        int i;
        int index;
        int prvI = 0; // เก็บค่าIก่อนหน้า
        public List <Vector2> itempos = new List<Vector2>();
        public List<Texture2D> Items = new List<Texture2D>();
       // public List<Item> Items = new List<Item>();
        public Inventory()
        {
            
        }
         
        
        public void AddItem(Item item)
        {
            slot++; // ช่องเก็บของที่ใช้
            if (slot <= Max_slot)
            {
                
                for (; i <= slot;)
                {
                    
                    Items.Add(item.item);
                    itempos.Add(new Vector2(Slot_size * i, 0));
                    i = prvI; 
                    i++;
                    prvI++;
                    break;
                }
                
            }
            

        }

        public void RemoveItem(Item item)
        {
            
            if (slot <= Max_slot&&slot>0)
            {

                prvI--; // ลดค่า I ก่อนหน้าให้สัมพันธ์กับ index ช่องเก็บของ
                index = Items.IndexOf(item.item);
                i = index; // ให้ i = ตัวที่ลบไป เพื่อสั่งแอดทดเเทน
                Items.Remove(item.item);
                itempos.RemoveAt(index);
                slot--;
            }
        }

        internal void Draw(SpriteBatch batch)
        {
            
            for(int i = 0; i < Items.Count; i++)
            {
                
                //batch.Draw(Items[i], itempos[i],new Rectangle((int)itempos[i].X, (int)itempos[i].Y,480,450) ,Color.White,0,Vector2.Zero,0.2f,0,0.3f);
                batch.Draw(Items[i], itempos[i], Color.White);
            }
            
        }

        
    }
}
