using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team06.Util;

namespace Team06.Actor
{
    class Player
    {
        private Motion motion;
        private enum Direction
        { DOWN, UP, RIGHT, LEFT };
        private Direction direction;//現在の向き
         //向きと範囲を管理
        private Dictionary<Direction, Range> directionRange;


        private Vector2 position;//位置
        private string name;//画像の名前
        private bool isDeadFlag;//死亡フラグ

        public Player(string name)
        {
            this.name = name;
        }

        public void Initialize()
        {
            position = Vector2.Zero;
            isDeadFlag = false;

            for (int i = 0; i < 16; i++)
            {
                motion.Add(i, new Rectangle(64 * (i % 4), 64 * (i / 4), 64, 64));
            }

            direction = Direction.DOWN;
            directionRange = new Dictionary<Direction, Range>()
            {

                {Direction.DOWN,new Range(0,3) },
                {Direction.UP,new Range(4,7) },
                {Direction.RIGHT,new Range(8,11) },
                {Direction.LEFT,new Range(12,15) },
            };
        }

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
