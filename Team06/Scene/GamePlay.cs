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
            goal = new Goal(new Vector2(641,721));
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
            characterManager.Add(kaito);
            //時間関連
            timerUI = new TimerUI(limitTimer);

            //スコア関連
            score = new Score();
            //制限時間
            limitTimer.Intialize();
            //かかった時間
            scoreTimer.Intialize();

            //------------プレイヤー追加処理---------------
            //キャラクターマネージャーにプレイヤー追加
            //characterManager.Add(new Player(this));

            //------------エネミー追加処理------------------
            ////動かない敵を追加
            //characterManager.Add(new Enemy(this));

            ////プレイヤーの実態生成
            //player = new Player();
            ////プレイヤーを初期化
            //player.Initialize();

            ////Listの実態生成
            //characters = new List<Character>();
            ////ListにCharacterのオブジェクト(継承したキャラ）を登録
            //characters.Add(new Enemy());   //動かない敵を登録
            ////10体登録
            //for (int i = 0; i < 10; i++)
            //{
            //    characters.Add(new RandomEnemy());
            //}
            //characters.Add(new BoundEnemy());

            ////登録したキャラクターを一気に初期化（foreach文）
            //foreach (var c in characters)
            //{
            //    c.Initialize();
            //}

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

            //背景を描画
            //renderer.DrawTexture("stage", Vector2.Zero);
            goal.Draw(renderer);

            //   renderer.DrawTexture("kabe", Vector2.Zero);

            //キャラクター一括管理

            ////プレイヤーを描画
            kaito.Draw(renderer);
            //////エネミーを描画
            //enemy.Draw(renderer);

            //score.Draw(renderer);
            timerUI.Draw(renderer);


            characterManager.Draw(renderer);        //キャラクター管理者の描画
            //if (timer.IsTime())
            //{
            //    renderer.DrawTexture("ending", new Vector2(150, 150));
            //}
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

            //if (goal.IsCollision() == true) 
            //{
            //    //プレイヤーとゴールが当たっているときの処理

            //}


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
