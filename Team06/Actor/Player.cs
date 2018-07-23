using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team06.Device; 　　　　　　　　　 //Rendererなど
using Team06.Def;                       //Screenなど
using Team06.Scene;
using Team06.Util;

namespace Team06.Actor
{
    class Player :Character
    {
        //フィールド
        //  private Vector2 position;　　　 //位置  。コメントアウトないし削除
        //モーション管理オブジェクト
        private Motion motion;


        /// <summary>
        /// 向き
        /// </summary>
        private enum Direction
        {
            DOWN, UP, RIGHT, LEFT
        };

        private Direction direction;  //現在の向き
        //向きと範囲を管理
        private Dictionary<Direction, Range> directionRange;

        ///コンストラクタ
        public Player(IGameMediator mediator)
            : base("kaito", mediator)
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            //int width = 64;
            //int height = 64;
            //  playerRect = new Rectangle(x, y, width, height);
        }

        ///初期化メソッド
        public override void Initialize()
        {
            //位置を(300,400)に設定
            position = new Vector2(300, 400);

            motion = new Motion();
            for (int i = 0; i < 16; i++)
            {
                motion.MotionAdd(i, new Rectangle(64 * (i % 4), 64 * (int)(i / 4), 64, 64));
            }

            //最初はすべてのパーツ表示に設定
            motion.Initialize(new Range(0, 3), new CountDownTimer(0.2f));
            //最初は下向きに
            direction = Direction.DOWN;
            directionRange = new Dictionary<Direction, Range>()
            {
                { Direction.DOWN,  new Range(0,3)},
                { Direction.UP,    new Range(4,7)},
                { Direction.RIGHT,new Range(8,11)},
                { Direction.LEFT,new Range(12,15)}
            };
        }
        ///更新処理
        ///<param name="gameTime">ゲームの時間</param>
        public override void Update(GameTime gameTime)
        {
            //移動量
            //移動処理
            float sped = 15.0f;
            position = position + Input.Velocity() * sped;
            Vector2 velocity = Vector2.Zero;

            //当たり判定（衝突判定処理)
            UpdateMotion();
            motion.Update(gameTime);

            var min = Vector2.Zero;
            var max = new Vector2(Screen.Width - 64, Screen.Height - 64);
            position = Vector2.Clamp(position, min, max);
        }


        ///描画メソッド
        ///<parma name="renderer">描画オブジェクト</parma>
        //public void Draw (Renderer renderer)
        //{
        //    //レンダラーで白玉画像を描画
        //    renderer.DrawTexture("white", position);
        //}
        /////終了処理
        public override void Shutdown()
        {

        }
        /// <summary>
        /// ヒット通知
        /// </summary>
        /// <param name="other">衝突した相手</param>
        public override void Hit(Character other)
        {

        }
        /// <summary>
        /// CharacterクラスのDrawメソッドに代わって描画
        /// </summary>
        /// <param name="renderer"></param>
        public override void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position, motion.DrawingRange());
        }
        /// <summary>
        /// モーションの変更
        /// </summary>
        /// <param name="direction">変更したい向き</param>
        private void ChangeMotion(Direction direction)
        {
            this.direction = direction;
            motion.Initialize(directionRange[direction], new CountDownTimer(0.2f));
        }
        /// <summary>
        /// キー入力情報から向きを変更
        /// </summary>
        private void UpdateMotion()
        {
            //キー入力の状態を取得
            Vector2 velocity = Input.Velocity();

            //キーがなければ何もしない
            if (velocity.Length() <= 0.0f)
            {
                return;
            }
            //キー入力があった時
            //下向きに変更
            if ((velocity.Y > 0.0f) && (direction != Direction.DOWN))
            {
                ChangeMotion(Direction.DOWN);
            }
            //上向きに変更
            if ((velocity.Y < 0.0f) && (direction != Direction.UP))
            {
                ChangeMotion(Direction.UP);
            }
            //右向きに変更
            if ((velocity.X > 0.0f) && (direction != Direction.RIGHT))
            {
                ChangeMotion(Direction.RIGHT);
            }
            //左向きに変更
            if ((velocity.X < 0.0f) && (direction != Direction.LEFT))
            {
                ChangeMotion(Direction.LEFT);
            }
        }
}
}
