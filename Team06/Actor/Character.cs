using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team06.Device;
using Team06.Scene;


namespace Team06.Actor
{
   abstract class Character
    {
        ///キャラクター 抽出クラス


        //親と子クラスだけの共通部分はprotectedで宣言
        protected Vector2 position;   //位置
        protected string name;        //画像の名前
        protected bool isDeadFlag;    //死亡フラグ
        protected IGameMediator mediator;   //仲介者
        protected Kaito kaito;

       protected enum State
        {
            Preparation,
            Alive,
            Dying,
            Dead
        };

        ///コンストラクタ
        public Character(string name, IGameMediator mediator)
        {
           
            this.name = name;
            position = Vector2.Zero;
            isDeadFlag = false;
            this.mediator = mediator;
        }
        //抽出メソッド（子クラスで必ず再定義しなければならないメソッドメソッド）
        public abstract void Initialize();          //初期化
        public abstract void Update(GameTime gameTime);   //更新
        public abstract void Shutdown();                  //終了
        public abstract void Hit(Character other);    //ヒット通知


        ///死んでいるか？
        public bool IsDead()
        {
            return isDeadFlag;
        }

        ///描画
        public virtual void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position);
        }
        /// <summary>
        /// 衝突判定（2点間の距離と円の半径）
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool InCollision(Character other)
        {
            //じぶんと相手の位置の長さを計算（2点間の距離）
            float length = (position - other.position).Length();
            //白玉画像のサイズは64なので、半径は32
            float radiusSum = 32f + 32f;
            //自分半径の和と距離を比べて、等しいかまたは小さいか（以下か）
            if (length <= radiusSum)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 位置の受け渡し
        /// (引数で渡された変数に自分の位置を渡す)
        /// </summary>
        /// <param name="other">位置を送りたい相手</param>
        public void SetPosition(ref Vector2 other)
        {
            other = position;
        }
    }
}
