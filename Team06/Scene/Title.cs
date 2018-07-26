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
            motion = new Motion();
        }
        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("title", Vector2.Zero);
            renderer.End();
        }
        /// <summary>
        /// 初期化
        /// </summary>
        public void Intialize()
        {
            isEndFlag = false;
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

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public void Update(GameTime gameTime)
        {
            //motion.Update(gameTime);
            //スペースキーが押されたか？
            if (Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
            }
        }
    }
}
