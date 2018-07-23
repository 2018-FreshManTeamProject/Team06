using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Team06.Actor;
using Team06.Device;
using Team06.Util;

namespace Team06.Scene
{
    class GamePlay : IScene,IGameMediator
    {
        private CharacterManager characterManager;    //キャラクター管理者
        private Score score;                          //得点  
        private Timer scoreTimer;                     //スコアになるタイマー
        private CountDownTimer limitTimer;            //制限時間
        private TimerUI timerUI;                      //時間UI
        private bool isEndFlag;                       //シーン終了フラグ
        private Sound sound;
        private Goal goal;
        private Kaito kaito;
        private Stage stage;
        public GamePlay(Timer scoreTimer)
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            this.scoreTimer = scoreTimer;
            limitTimer = new CountDownTimer(60.0f);
        }
        public void Intialize()
        {
            //シーン終了フラグを初期化
            isEndFlag = false;
            //キャラクターマネージャーの実態生成
            characterManager = new CharacterManager();
            kaito = new Kaito(this);
            kaito.Initialize();
            stage = new Stage(kaito);
            goal = new Goal(kaito);
            characterManager.Add(kaito);
            //時間関連
            timerUI = new TimerUI(limitTimer);
            //スコア関連
            score = new Score();
            //制限時間
            limitTimer.Intialize();
            //かかった時間
            scoreTimer.Intialize();
        }
        public void AddActor(Character character)
        {
            characterManager.Add(character);
        }

        public void AddScore()
        {
            score.Add();
        }

        public void AddScore(int num)
        {
            score.Add(num);
        }

        public void Draw(Renderer renderer)
        {
            //描画開始
            renderer.Begin();
            stage.Draw(renderer);
            goal.Draw(renderer);
            kaito.Draw(renderer);
            timerUI.Draw(renderer);
            characterManager.Draw(renderer);        //キャラクター管理者の描画
            //描画終了
            renderer.End();
        }
        public bool IsEnd()
        {
            return isEndFlag;
        }
        public Scene Next()
        {

            return Scene.Ending;
        }
        public void Shutdown()
        {

        }
        public void Update(GameTime gameTime)
        {
            scoreTimer.Update(gameTime);
            limitTimer.Update(gameTime);
            score.Update(gameTime);
            //キャラクターマネージャー更新
            characterManager.Update(gameTime);
            stage.Update();
            goal.Update();
            if (goal.IsGoal()== true)
            {
                //プレイヤーとゴールが当たっているときの処理
                isEndFlag = true;
            }
            //時間切れか？
            if (limitTimer.IsTime())
            {
                //計算途中のスコアを全部加算
                score.Shutdown();
                //シーン終了
                isEndFlag = true;
            }
            if (Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
            }
        }
    }
}
