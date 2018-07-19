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
       
        public Goal()
        {
            
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

    }
}
