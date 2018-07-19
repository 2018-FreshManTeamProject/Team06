using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Team06.Device;

namespace Team06.Scene
{ 
        /// <summary>
        /// シーン型の列挙型
        /// </summary>
        enum Scene
        {
            Title,
           //ステージ選択
            GamePlay,
            //リスタート画面
            //リザルト画面
            Ending
        }

        interface IScene
        {
            void Intialize();                 //初期化
            void Update(GameTime gameTime);   //更新
            void Draw(Renderer renderer);     //描画
            void Shutdown();                  //終了

            //シーン管理用
            bool IsEnd();                     //終了チェック
            Scene Next();                     //次のシーンへ
        }
   
}
