using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Team06.Util
{
    class Motion
    {
        private Range range;      //範囲
        private Timer timer;      //切り替え時間
        private int motionNumber;//現在のモーション番号

        //表示位置を番号で管理
        //Dictionaryを使えば登録順番を気にしなくてもよい
=======

        private Range range;//範囲
        //private Timer timer;//切り替え時間
        private int motionNumber;//現在のモーション番号

        //表示位置を番号で管理
        //Dictionaryを使えば登録順番を気にしなくてよい

        private Dictionary<int, Rectangle> rectangles = new Dictionary<int, Rectangle>();

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Motion()
        {
            //何もしない
            Initialize(new Range(0, 0), new CountDownTimer());
=======
            Initialize(new Range(0, 0)/*, new CountDownTimer()*/);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="range">範囲</param>
        /// <param name="timer">モーションの切り替え時間</param>
        public Motion(Range range, Timer timer)
        {
            Initialize(range, timer);
=======
        /// <param name="timer">モーション切り替え時間</param>
        public Motion(Range range /*,Timer timer*/)
        {
            Initialize(range/*, timer*/);
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="range">範囲</param>
        /// <param name="timer">モーションの切り替え時間</param>
        public void Initialize(Range range, Timer timer)
        {
            this.range = range;
            this.timer = timer;

            //モーション番号は、範囲の最初に設定
=======
        /// <param name="timer">モーション切り替え時間</param>
        public void Initialize(Range range/*, Timer timer*/)
        {
            this.range = range;
            //this.timer = timer;

            //モーション番号は範囲の最初に設定
>>>>>>> origin/negishiwataru
            motionNumber = range.First();
        }

        /// <summary>
<<<<<<< HEAD
        /// モーション短形情報の追加
        /// </summary>
        /// <param name="index">管理番号</param>
        /// <param name="rect">短形</param>
        public void Add(int index, Rectangle rect)
        {
            //すでに登録されていたら何もしない
=======
        /// モーション矩形情報の追加
        /// </summary>
        /// <param name="index">管理番号</param>
        /// <param name="rect">矩形</param>
        public void Add(int index, Rectangle rect)
        {
            //すでに登録されてたら何もしない
>>>>>>> origin/negishiwataru
            if (rectangles.ContainsKey(index))
            {
                return;
            }
<<<<<<< HEAD

=======
>>>>>>> origin/negishiwataru
            //登録
            rectangles.Add(index, rect);
        }

        /// <summary>
        /// モーションの更新
        /// </summary>
<<<<<<< HEAD
        private void MotionUpdate()
=======
        public void MotionUpdate()
>>>>>>> origin/negishiwataru
        {
            //モーション番号をインクリメント
            motionNumber += 1;

            //範囲外なら最初に戻す
            if (range.IsOutOfRange(motionNumber))
            {
                motionNumber = range.First();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public void Update(GameTime gameTime)
        {
<<<<<<< HEAD
            //ガード説(範囲外なら何もしない)
=======
            //ガード説（範囲外なら何もしない）
>>>>>>> origin/negishiwataru
            if (range.IsOutOfRange())
            {
                return;
            }

            //時間を更新
<<<<<<< HEAD
            timer.Update(gameTime);
            //指定時間になってたらモーション更新
            if (timer.IsTime())
            {
                timer.Intialize();
                MotionUpdate();
            }

        }

=======
            //timer.Update(gameTime);
            //指定時間になってたらモーション更新
            //if (timer.IsTime())
            //{
            //    timer.Initialize();
            //    MotionUpdate();
            //}
        }

        /// <summary>
        /// 描画範囲の取得
        /// </summary>
        /// <returns></returns>
>>>>>>> origin/negishiwataru
        public Rectangle DrawingRange()
        {
            return rectangles[motionNumber];
        }
    }
}
