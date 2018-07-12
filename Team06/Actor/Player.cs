using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Team06.Actor
{
    class Player
    {
        private enum Direction
        {DOWN,UP,RIGHT,LEFT};
        private Direction direction;//現在の向き

        private Vector2 position;//位置
        private string name;//画像の名前
        private bool isDeadFlag;//死亡フラグ

        public Player(string name)
        {
            this.name = name;
            isDeadFlag = false;
            position = Vector2.Zero;
        }

        public void Initialize()
        { }

        public void Update(GameTime gameTime)
        {
            //Inputクラス使って移動処理
        }

        public void Shutdown()
        { }

        public bool IsDead()
        {
            return isDeadFlag;
        }

        public void Draw()
        { }

        private void ChangeMotion()
        { }

        private void UpdateMotion()
        { }
    }
}
