using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team06.Device;
using Team06.Util;
using Team06.Def;
using Team06.Scene;
using Microsoft.Xna.Framework;

namespace Team06.Actor
{
    class SearchLight : Character
    {

        private AI ai;
        private Random rnd;
        private State state;//状態
        private Timer timer;//表示用切り替え時間
        private bool isDisplay;//表示中か？
        private readonly int Impression = 10;//表示回数
        private int displayCount;//表示カウンタ
        //private Watch watch;
        private Rectangle searchrect;
        private bool isPlayerGoal;  //終了フラグ
       
        //private Renderer renderer;
        //private Motion motion;
        //private GamePlay gamePlay;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SearchLight(IGameMediator mediator, AI ai,Kaito kaito)
            : base("searchlight", mediator)
        {
            this.ai = ai;
            this.kaito = kaito;
            state = State.Preparation;
            int x = (int)position.X;
            int y = (int)position.Y;
            int width = 96;
            int height = 96;
            searchrect = new Rectangle(x, y, width, height);
            timer = new CountDownTimer(0.25f);
            isPlayerGoal = false;

        }

        /// <summary>
        /// 初期化メソッド
        /// </summary>
        public override void Initialize()
        {
            //位置を(100,100)に設定
            var gameDevice = GameDevice.Instance();
            rnd = gameDevice.GetRandom();
            position = new Vector2(
                rnd.Next(Screen.Width - 64),
                rnd.Next(Screen.Height - 64));

          

            //初期状態では準備に
            state = State.Preparation;

        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public override void Update(GameTime gameTime)
        {
            switch (state)
            {
                case State.Preparation:
                    PreparationUpdate(gameTime);
                    break;
                case State.Alive:
                    AliveUpdate(gameTime);
                    break;
                case State.Dying:
                    DyingUpdate(gameTime);
                    break;
                case State.Dead:
                    DeadUpdate(gameTime);
                    break;
            }
            if (IsCollision())
            {
                isPlayerGoal = true;
            }
            searchrect.X = (int)position.X;
            searchrect.Y = (int)position.Y;
            ////AIが考えて決定した位置に
            //position = ai.Think(this);
        }
        public bool IsCollision()
        {
            return searchrect.Intersects(kaito.GetPlayerRectangle());
        }
        public bool IsGameEnd()
        {
            return isPlayerGoal;
        }

        public override void Draw(Renderer renderer)
        {
            switch (state)
            {
                case State.Preparation:
                    PreparationDraw(renderer);
                    break;
                case State.Alive:
                    AliveDraw(renderer);
                    break;
                case State.Dying:
                    DyingDraw(renderer);
                    break;
                case State.Dead:
                    DeadDraw(renderer);
                    break;
            }
        }

        public override void Shutdown()
        {

        }

        //public void Change()
        //{
        //    if (watch.IsChange()==true)
        //    {
        //        Vector2 hozon = position;
        //        state = State.Dead;
        //        renderer.DrawTexture(name, position, motion.DrawingRange());

        //    }
        //}

        /// <summary>
        ///ヒット通知 
        /// </summary>
        /// <param name="other">衝突した相手</param>

        public override void Hit(Character other)
        {
            if (state != State.Dead)
            {
                return;
            }
            //状態変更
            state = State.Dying;
            //gamePlay.IsEnd();
            //gamePlay.Next();
        }

        private void PreparationUpdate(GameTime gameTime)
        {
            timer.Update(gameTime);
            if (timer.IsTime())
            {
                isDisplay = !isDisplay;//フラグ反転
                displayCount -= 1;
               // timer.Initialize();
            }
            if (displayCount == 0)
            {
                state = State.Alive;
             //   timer.Initialize();
                displayCount = Impression;
                isDisplay = true;
            }
        }

        private void PreparationDraw(Renderer renderer)
        {
            if (isDisplay)
            {
                base.Draw(renderer);
            }
        }

        private void AliveUpdate(GameTime gameTime)
        {
            position = ai.Think(this);
        }

        private void AliveDraw(Renderer renderer)
        {
            base.Draw(renderer);
        }

        private void DyingUpdate(GameTime gameTime)
        {
            timer.Update(gameTime);
            if (timer.IsTime())
            {
                displayCount -= 1;
            //    timer.Initialize();
                isDisplay = !isDisplay;
            }

            if (displayCount == 0)
            {
                state = State.Dead;
            }
        }

        private void DyingDraw(Renderer renderer)
        {
            if (isDisplay)
            {
            }
            else
            {
                base.Draw(renderer);
            }
        }

        private void DeadUpdate(GameTime gameTime)
        {
            isDeadFlag = true;
        }

        private void DeadDraw(Renderer renderer)
        {

        }

       
    }
}
