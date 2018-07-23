using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team06.Device;

namespace Team06.Actor
{
    class Stage
    {
        private Kaito kaito;

        private List<Rectangle> wallList;

        public Stage(Kaito kaito)
        {
            this.kaito = kaito;

            wallList = new List<Rectangle>();

            Add();
        }

        private void Add()
        {
            wallList.Add(new Rectangle(0, 0, 100, 800)); //左壁
            wallList.Add(new Rectangle(180, 0, 50, 690));//L字壁縦
            wallList.Add(new Rectangle(231, 640, 259, 50));//L字壁横
            wallList.Add(new Rectangle(480, 0, 170, 540));//真ん中
            wallList.Add(new Rectangle(641, 541, 9, 29));//チョコ
            wallList.Add(new Rectangle(641, 690, 258, 30));//ゴール↑
            wallList.Add(new Rectangle(900, 0, 99, 799));//UIスぺ

        }

        public void Update()
        {
            foreach(var rect in wallList)
            {
                if (IsCollisoin(rect))
                {
                    //プレイヤーとステージの四角形が当たっていた時の処理
                    StagePush(rect);
                }
            }
        }

        //ステージによる押し出し
        private void StagePush(Rectangle rect)
        {
            int cnt = 0;
            do
            {
                cnt++;
                if (cnt >10) break;
                bool isZeroVelocity = kaito.GetVelocity().Length() < 0.0001f;
                Vector2 velocityN = isZeroVelocity ? Vector2.Zero :
                Vector2.Normalize(kaito.GetVelocity());
                kaito.AddVelocity(-velocityN);
            }
            while (IsCollisoin(kaito.GetPlayerRectangle()));
        }
        private bool IsCollisoin(Rectangle wall)
        {
            //引数のステージの四角形とプレイヤーの四角形が重なっているかどうか
            return wall.Intersects(kaito.GetPlayerRectangle());
        }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("stage", new Vector2(0, 0));
        }

    }
}
