using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team06.Util
{
    class CountUpTimer : Timer
    {
        public CountUpTimer() : base()
        {
            //自分の初期化メソッドで初期化
            Intialize();
        }

        public CountUpTimer(float second) : base(second)
        {
            Intialize();
        }
        public override void Intialize()
        {
            currentTime = 0f;
        }

        public override bool IsTime()
        {
            //60以上になったら設定した時間を超えたのでtrueを返す
            return currentTime >= limitTime;
        }
        /// <summary>
        /// 割合
        /// </summary>
        /// <returns>はじめ0で、制限時間で1</returns>
        public override float Rate()
        {
            return currentTime / limitTime;
        }

        public override void Update(GameTime gameTime)
        {
            //現在の時間を増やす。ただし最大値は0.0
            currentTime = currentTime + 1f;
        }
    }
}
