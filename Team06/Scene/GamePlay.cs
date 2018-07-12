using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using Team06.Actor;
using Team06.Device;
using Team06.Util;

namespace Team06.Scene
{
    class GamePlay : IScene, IGameMediator
    {
        //private Player player;          //プレイヤーとなる白玉
        //private List<Character> characters;//キャラクターを一括管理

        private CharacterManager characterManager;    //キャラクター管理者
        private Score score;                          //得点
        private Timer timer;　　　　　　　　　　　　　//ゲームプレイ時間
        private TimerUI timerUI;           //時間UI


        private bool isEndFlag;            //シーン終了フラグ
        private Sound sound;

        public GamePlay()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();


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
            //背景を描画
            renderer.DrawTexture("stage", Vector2.Zero);

            //キャラクター一括管理
            //characters.ForEach(c => c.Draw(renderer));
            ////プレイヤーを描画
            //player.Draw(renderer);
            //////エネミーを描画
            //enemy.Draw(renderer);
            //enemy2.Draw(renderer);
            //randomenemy.Draw(renderer);
            score.Draw(renderer);
            timerUI.Draw(renderer);


            characterManager.Draw(renderer);        //キャラクター管理者の描画
            //if (timer.IsTime())
            //{
            //    renderer.DrawTexture("ending", new Vector2(150, 150));
            //}
            //描画終了
            renderer.End();

        }

        public void Intialize()
        {
            //シーン終了フラグを初期化
            isEndFlag = false;

            //キャラクターマネージャーの実態生成
            characterManager = new CharacterManager();


            //------------プレイヤー追加処理---------------
            //キャラクターマネージャーにプレイヤー追加
            //characterManager.Add(new Player(this));
           

            //------------エネミー追加処理------------------
            ////動かない敵を追加
            //characterManager.Add(new Enemy(this));


           

            //時間関連
            timer = new CountDownTimer(5);
            timerUI = new TimerUI(timer);

            //スコア関連
            score = new Score();
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
            sound.StopBGM();
        }

        public void Update(GameTime gameTime)
        {
            timer.Update(gameTime);
            score.Update(gameTime);

            sound.PlayBGM("gameplaybgm");

            //キャラクターマネージャー更新
            characterManager.Update(gameTime);


            //時間切れか？
            if (timer.IsTime())
            {
                //計算途中のスコアを全部加算
                score.Shutdown();
                //シーン終了
                isEndFlag = true;
                sound.PlaySE("gameplayse");
            }
            ////キャラクターを一括更新（ForEachメソッド版
            //characters.ForEach(c => c.Update(gameTime));
            ////Playerの更新
            //player.Update(gameTime);

            ////衝突判定
            ////敵キャラすべてと判定
            //foreach (var c in characters)
            //{    
            //     //衝突した敵は初期化メソッドで初期化                 
            //     int num = 10;
            //     if (c is BoundEnemy)
            //     {
            //        num = 200;
            //     } 

            //    //リストから取り出した1体分の敵cとプレイヤーの衝突判定
            //    if (player.InCollision(c))
            //    {
            //        c.Initialize();
            //        if (!timer.IsTime())
            //        {
            //            score.Add(num);
            //        }
            //    }






        }
    }
}
