using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team06.Device; //Rendererなど
using Team06.Scene;
using Team06.Def;
using Team06.Util;
using Microsoft.Xna.Framework; 　　　   //Vector2用
using Microsoft.Xna.Framework.Input;    //入力処理用


namespace Team06.Actor
{
    class Goal
    {
        private Kaito kaito;
        private Rectangle goal;
        private bool isPlayerGoal;  //終了フラグ


        public Goal(Kaito kaito)
        {
            this.kaito = kaito;
            goal = new Rectangle(641, 751, 64, 64);

            //まだプレイヤーがゴールしていないことにする
            isPlayerGoal = false;
        }

        public void Update()
        {
            if (IsCollision())
            {
                isPlayerGoal = true;
            }
        }
       
        private bool IsCollision()
        {
            return goal.Intersects(kaito.GetPlayerRectangle());
        }

        public bool IsGoal()
        {
            return isPlayerGoal;
        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("goalyoko", new Vector2(641,751));
        }

        
    }
}
