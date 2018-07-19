using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team06.Device; //Rendererなど
using Team06.Scene;
using Team06.Def;
using Team06.Util;

using Microsoft.Xna.Framework; 　　　   //Vector2用
using Microsoft.Xna.Framework.Input;    //入力処理用


namespace Team06.Actor
{
    class Enemy : Character
    {
        //フィールド
        private AI ai;
        private Random rnd;
        ///コンストラクタ
        public Enemy(IGameMediator mediator, AI ai) : base("black", mediator)

        {
            this.ai = ai;
            //    position = Vector2.Zero;
            //    var gameDevice = GameDevice.Instance();
            //sound = gameDevice.GetSound();

        }

        //初期化メソッド
        public override void Initialize()
        {
            //位置を（100,100)に設定
            var gameDevice = GameDevice.Instance();
            rnd = gameDevice.GetRandom();
            position = new Vector2(
                rnd.Next(Screen.Width - 64),
                rnd.Next(Screen.Height - 64));
            //position = new Vector2(320,240);
            //time = 0;
            //velocity.X = random.Next(-1, 2);
            //velocity.Y = random.Next(-1, 2);
        }

        //
        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public override void Update(GameTime gameTime)
        {
            //移動量
            //Vector2 velocity = Vector2.Zero;
            //AIが考えて決定した位置に
            position = ai.Think(this);
          
        }
        ///描画メソッド
        ///<parma name="renderer">描画オブジェクト</parma>
        //public void Draw(Renderer renderer)
        //{
        //    レンダラーで黒玉画像を描画
        //    renderer.DrawTexture("black", position);
        //}
        ///終了処理
        public override void Shutdown()
        {

        }

        /// <summary>
        /// ヒット通知
        /// </summary>
        /// <param name="other">衝突した相手</param>
        public override void Hit(Character other)
        {
            //得点処理
           // int score = 0;
        }
    }
}