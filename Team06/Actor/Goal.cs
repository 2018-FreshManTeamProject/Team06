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
        //ゴールの四角形
        private Rectangle goalRect;
       
        public Goal(Vector2 position)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            int width = 64;
            int height = 17;
            goalRect = new Rectangle(x, y, width, height);
        }
       
        /////終了処理
        public  void Shutdown()
        {
            
        }
    
        /// <summary>
        /// ヒット通知
        /// </summary>
        /// <param name="other">衝突した相手</param>
        public  void Hit(Character other)
        {
           
        }

        public void Draw(Renderer renderer)
        {
            Vector2 position = new Vector2(goalRect.X, goalRect.Y);
            renderer.DrawTexture("goalyoko",position);
        }

        public bool IsCollision(Rectangle playerRect)
        {
            //引数のプレイヤーの「Rectangle」とゴールの「Rectangle」が重なっているかどうか(当たっているかどうか)
            return goalRect.Contains(playerRect);
        }

        //public Rectangle GetPlayerRect()
        //{
        //    return playerRect;
        //}

    }
}
