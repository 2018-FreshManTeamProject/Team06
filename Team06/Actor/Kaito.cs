using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;//Vector2用
using Microsoft.Xna.Framework.Input;//入力処理用
using Team06.Device;
using Team06.Def;
using Team06.Scene;
using Team06.Util;

namespace Team06.Actor
{
    class Kaito : Character
    {
        //フィールド
        //private Vector2 position;//位置
        //親クラスで定義したのでいらない

        private Rectangle playerRect;
        //モーション管理オブジェクト
        private Motion motion;
        private Vector2 velocity;
        /// <summary>
        /// 向き
        /// </summary>
        private enum Direction
        { DOWN, UP, RIGHT, LEFT };
        
        private Direction direction;//現在の向き
        //向きと範囲を管理
        private Dictionary<Direction, Range> directionRange;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Kaito(IGameMediator mediator)
            : base("kaito", mediator)//base()<=親クラスのコンストラクタの呼び出し
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            int width = 64;
            int height = 64;
            playerRect = new Rectangle(x, y, width, height);
            velocity = Vector2.Zero;
        }

        /// <summary>
        /// 初期化メソッド
        /// </summary>
        public override void Initialize()
        {
           
            //位置を(300,400)に設定
            position = new Vector2(110, 20);

                 motion = new Motion();
          
            for (int i = 0; i < 16; i++)
            {
                motion.MotionAdd(i, new Rectangle(64 * (i % 4), 64 * (i / 4), 64, 64));
            }
           
            #region
            //int num = 0;
            ////下向き
            //for (int i = 0; i < 4; i++)
            //{
            //    motion.Add(num, new Rectangle(64 * i, 64 * 0, 64, 64));
            //    num++;
            //}

            ////上向き
            //for (int i = 0; i < 4; i++)
            //{
            //    motion.Add(num, new Rectangle(64 * i, 64 * 1, 64, 64));
            //    num++;
            //}
            ////右向き
            //for (int i = 0; i < 4; i++)
            //{
            //    motion.Add(num, new Rectangle(64 * i, 64 * 2, 64, 64));
            //    num++;
            //}

            ////左向き
            //for (int i = 0; i < 4; i++)
            //{
            //    motion.Add(num, new Rectangle(64 * i, 64 * 3, 64, 64));
            //    num++;
            //}
            #endregion
            //最初はすべてのパーツ表示に設定
          //  motion.Initialize(new Range(0, 15), new CountDownTimer(0.2f));

            //最初は下向きに
            direction = Direction.DOWN;
            directionRange = new Dictionary<Direction, Range>()
            {
                {Direction.DOWN,new Range(0,3) },
                {Direction.UP,new Range(4,7) },
                {Direction.RIGHT,new Range(8,11) },
                {Direction.LEFT,new Range(12,15) },
            };
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public override void Update(GameTime gameTime)
        {       
            #region
            //    //移動量
            //    Vector2 velocity = Vector2.Zero;

            //    //右
            //    if (Input.GetKeyState(Keys.Right))
            //    {
            //        velocity.X = 1f;
            //    }

            //    //左
            //    if (Input.GetKeyState(Keys.Left))
            //    {
            //        velocity.X = -1f;
            //    }
            //    //上
            //    if (Input.GetKeyState(Keys.Up))
            //    {
            //        velocity.Y = -1f;
            //    }
            //    //下
            //    if (Input.GetKeyState(Keys.Down))
            //    {
            //        velocity.Y = 1f;
            //    }

            //    //正規化
            //    if (velocity.Length() != 0)
            //    {
            //        velocity.Normalize();
            //    }

            #endregion
            //移動処理
            float speed = 10.0f;
            velocity = Input.Velocity() * speed;

            position = position + velocity;
           
            //Vector2 velocity = Vector2.Zero;

            //当たり判定
            #region if文を使ったもの（コメントアウト)
            //左
            //if (position.X<0)
            //{
            //    position.X = 0;
            //}
            ////右
            //if (position.X > Screen.Width-64)
            //{
            //    position.X = Screen.Width-64;
            //}
            ////上
            //if (position.Y < 0)
            //{
            //    position.Y = 0;
            //}
            ////下
            //if (position.Y > Screen.Height-64)
            //{
            //    position.Y = Screen.Height-64;
            //}
            #endregion
            var min = Vector2.Zero;
            var max = new Vector2(Screen.Width - 164, Screen.Height - 64);
            position = Vector2.Clamp(position, min, max);
            Scene.Scene scene = new Scene.Scene();
            if ((int)scene == 1)
            {
                //Stage1();
            }      
            //プレイヤーの矩形位置を更新
            playerRect.X = (int)position.X;
            playerRect.Y = (int)position.Y;
            UpdateMotion(gameTime);
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public Vector2 GetVelocity()
        {
            return velocity;
        }
        public override void Shutdown()
        {

        }
        /// <summary>
        ///ヒット通知 
        /// </summary>
        /// <param name="other">衝突した相手</param>
        public override void Hit(Character other)
        {
        }

        public override void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position, motion.DrawingRange());
        }

        private void ChangeMotion(Direction direction)
        {
            this.direction = direction;
            motion.Initialize(directionRange[direction], new
                CountDownTimer(0.1f));
        }

        private void UpdateMotion(GameTime gameTime)
        {         
            //キー入力の状態を取得
            Vector2 velocity = Input.Velocity();
            //DeviceのInputでのUpdateVelocityのキーボード入力を変更

            //キー入力がなければなにもしない
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
            //上向き
            if ((velocity.Y < 0.0f) && (direction != Direction.UP))
            {
                ChangeMotion(Direction.UP);
            }
            //右
            if ((velocity.X > 0.0f) && (direction != Direction.RIGHT))
            {
                ChangeMotion(Direction.RIGHT);
            }
            //左
            if ((velocity.X < 0.0f) && (direction != Direction.LEFT))
            {
                ChangeMotion(Direction.LEFT);
            }
            motion.Update(gameTime);
        }
        public Rectangle GetPlayerRectangle()
        {
            return playerRect;
        }

        public void AddVelocity(Vector2 velocity)
        {
            position += velocity;
            //プレイヤーの矩形位置を更新
            playerRect.X = (int)position.X;
            playerRect.Y = (int)position.Y;
        }

        public Vector2 GetCenter()
        {
            return position + new Vector2(32f, 32f);
        }

        //public void Stage1()
        //{
        //    if (position.X < 100)
        //    {
        //        position.X = 100;
        //    }

        //    if (position.X > 180 - 64 && position.Y < 689 && position.X < 180)
        //    {
        //        if (Input.GetKeyState(Keys.Right))
        //        {
        //            position.X = 180 - 64;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 200 && position.Y < 689 && position.X < 230)
        //    {
        //        if (Input.GetKeyState(Keys.Left))
        //        {
        //            position.X = 230;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 180 - 64 && position.Y < 690 && position.X < 230)
        //    {
        //        if (Input.GetKeyState(Keys.Up))
        //        {
        //            position.Y = 690;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 475 && position.X < 490 && position.Y < 690 && position.Y > 640 - 64)
        //    {
        //        if (Input.GetKeyState(Keys.Left))
        //        {
        //            position.X = 490;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 180 && position.X < 490 && position.Y < 690 && position.Y > 640 - 64)
        //    {
        //        if (Input.GetKeyState(Keys.Up))
        //        {
        //            position.Y = 690;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 180 && position.X < 490 && position.Y < 690 && position.Y > 640 - 64)
        //    {
        //        if (Input.GetKeyState(Keys.Down))
        //        {
        //            position.Y = 640 - 64;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 480 - 64 && position.Y < 539 && position.X < 478)
        //    {
        //        if (Input.GetKeyState(Keys.Right))
        //        {
        //            position.X = 480 - 64;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 480 - 64 && position.Y < 540 && position.X < 650)
        //    {
        //        if (Input.GetKeyState(Keys.Up))
        //        {
        //            position.Y = 540;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 600 && position.Y < 539 && position.X < 650)
        //    {
        //        if (Input.GetKeyState(Keys.Left))
        //        {
        //            position.X = 650;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 640 && position.Y < 570 && position.X < 650)
        //    {
        //        if (Input.GetKeyState(Keys.Left))
        //        {
        //            position.X = 650;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 640 - 64 && position.Y < 570 && position.X < 640)
        //    {
        //        if (Input.GetKeyState(Keys.Right))
        //        {
        //            position.X = 640 - 64;
        //            Input.Update();
        //        }
        //    }
        //    if (position.X > 640 - 64 && position.Y < 570 && position.X < 650 && position.Y > 560)
        //    {
        //        if (Input.GetKeyState(Keys.Up))
        //        {
        //            position.Y = 570;
        //            Input.Update();
        //        }

        //    }

        //}

       
    }
}
