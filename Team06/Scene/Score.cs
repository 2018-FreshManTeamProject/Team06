using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team06.Device;

namespace Team06.Scene
{
    class Score
    {
        //フィールド
        private int score;           //合計得点
        private int poolScore;       //一時保存用のプール得点

        //コンストラクタ
        public Score()
        {
            Intialize();
        }


        //メソッド
        public void Intialize()
        {
            score = 0;
            poolScore = 0;
        }

        public void Add()
        {
            poolScore = poolScore + 1;
        }

        public void Add(int num)
        {
            poolScore = poolScore + num;
        }

        public void Update(GameTime gameTime)
        {
            //プール得点に得点があるか？
            if (poolScore > 0)
            {
                score = score + 1;　　　　//合計を増やす
                poolScore = poolScore - 1;　//プール得点を減らす
            }

            else if (poolScore < 0)
            {
                score -= 1;
                poolScore += 1;
            }

        }

        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("score", new Vector2(50, 10));
            renderer.DrawNumber("number", new Vector2(250, 13), score);

        }
        public void Shutdown()
        {
            //    score++;
            //    poolScore--;
            score += poolScore;
            if (score < 0)
            {
                score = 0;
            }
            poolScore = 0;
        }
    }
}
