using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Team06.Device;
using Team06.Util;

namespace Team06.Scene
{
    class Title : IScene                  //シーンインターフェースを継承
    {
        //終了フラグ
        private bool isEndFlag;   //終了フラグ
        private Sound sound; 　　 //サウンドオブジェクト
        private Motion motion;    //モーション管理


        /// <summary>
        ///コンストラクタ
        /// </summary>
        public Title()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
        }


        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("title", Vector2.Zero);
            renderer.DrawTexture("puddle", new Vector2(200, 370), motion.DrawingRange());
            renderer.End();
        }


        /// <summary>
        /// 初期化
        /// </summary>
        public void Intialize()
        {
            isEndFlag = false;

            motion = new Motion();
            motion.Add(0, new Rectangle(64 * 0, 0, 64, 64));
            motion.Add(1, new Rectangle(64 * 1, 0, 64, 64));
            motion.Add(2, new Rectangle(64 * 2, 0, 64, 64));
            motion.Add(3, new Rectangle(64 * 3, 0, 64, 64));
            motion.Add(4, new Rectangle(64 * 4, 0, 64, 64));
            motion.Add(5, new Rectangle(64 * 5, 0, 64, 64));

            //範囲は0～5、モーション切り替え時間は0.2秒で初期化
            motion.Initialize(new Range(0, 5), new CountDownTimer(0.05f));
        }



        /// <summary>
        /// 終了か？
        /// </summary>
        /// <returns>シーンが終わってたら</returns>
        public bool IsEnd()
        {
            return isEndFlag;
        }

        /// <summary>
        /// 次のシーンへ
        /// </summary>
        /// <returns>次のシーンへ</returns>
        public Scene Next()
        {
            return Scene.GamePlay;
        }
        /// <summary>
        /// 終了
        /// </summary>
        public void Shutdown()
        {
            sound.StopBGM();
        }



        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public void Update(GameTime gameTime)
        {
            //sound.PlayBGM("titlebgm");
            //motion.Update(gameTime);
            ////スペースキーが押されたか？
            //if (Input.GetKeyTrigger(Keys.Space))
            //{
            //    isEndFlag = true;
            //    sound.PlaySE("titlese");
            //}

        }
    }
}
