using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Team06.Util
{
    abstract class Timer
    {
        //子クラスでも利用できるようprotected
        protected float limitTime;    //制限時間
        protected float currentTime;  //現在の時間
        protected float elapsedTime;  //経過時間
        /// <summary>
        /// コンストラクタコンストラクタ
        /// </summary>
        /// <param name="second"></param>
        public Timer(float second)
        {
            limitTime = 60 * second;   //60fps*秒
        }
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Timer()
            : this(1) //1秒
        {

        }
        //抽象メソッド
        public abstract void Intialize();

        public abstract void Update(GameTime gameTime);

        public abstract bool IsTime();

        public abstract float Rate();

        public void SetTime(float second)
        {
            limitTime = 60 * second;
        }
        public float Now()
        {
            return currentTime / 60f;  //60fps想定なので60で割る
        }
        public float Result()
        {
          return  elapsedTime = limitTime - currentTime;
            
        }
        
    }
}
