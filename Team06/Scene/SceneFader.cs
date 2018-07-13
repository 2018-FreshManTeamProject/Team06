using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Team06.Device; //Rendererなど
using Team06.Def;    //Screenなど
using Team06.Util;

namespace Team06.Scene
{
    class SceneFader //: IScene
    {
        /// <summary>
        /// フェードシーン状態の列挙型
        /// </summary>
        private enum SceneFaderState
        {
            In, Out, None
        };

        private Timer timer;                              //フェード時間
        private readonly float FADE_TIME = 2.0f;          //2秒で
        private SceneFaderState state;                    //状態
        private IScene scene;                             //現在のシーン
        private bool isEndFlag;                   //終了フラグ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="scene">シーン名</param>
        public SceneFader(IScene scene)
        {
            this.scene = scene;
        }
        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            //switch (state)
            //{
            //    case SceneFaderState.In:
            //        DrawFadeIn(renderer);
            //        break;
            //    case SceneFaderState.Out:
            //        DrawFadeOut(renderer);
            //        break;
            //    case SceneFaderState.None:
            //        DrawFadeNone(renderer);
            //        break;
            //}
        }


        /// <summary>
        /// 初期化
        /// </summary>
        public void Intialize()
        {
            scene.Intialize();
            state = SceneFaderState.In;
            timer = new CountDownTimer(FADE_TIME);
            isEndFlag = false;
        }
        /// <summary>
        /// 終了か？
        /// </summary>
        /// <returns>シーン終了したら</returns>
        public bool IsEnd()
        {
            return isEndFlag;
        }
        /// <summary>
        /// 次のシーン名の取得
        /// </summary>
        /// <returns>次委のシーン</returns>
        public Scene Next()
        {
            return scene.Next();
        }
        /// <summary>
        /// 終了処理
        /// </summary>
        public void Shutdown()
        {
            scene.Shutdown();
        }
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
       
    }
}
