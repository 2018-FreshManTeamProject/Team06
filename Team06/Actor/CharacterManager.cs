using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Team06.Device;


namespace Team06.Actor
{
    class CharacterManager
    {
        private List<Character> players;  //プレイヤーリスト
        private List<Character> enemys;  //エネミーリスト
        private List<Character> addNewCharacter;　//追加するキャラクターリスト

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterManager()
        {
            Initialize();      //初期化
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            //各リストの生成とクリア
            if (players != null)
            {
                players.Clear();
            }
            else
            {
                players = new List<Character>();
            }

            if (enemys != null)
            {
                enemys.Clear();
            }
            else
            {
                enemys = new List<Character>();
            }

            if (addNewCharacter != null)
            {
                addNewCharacter.Clear();
            }
            else
            {
                addNewCharacter = new List<Character>();
            }
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="character">追加するキャラクター</param>
        public void Add(Character character)
        {
            //早朝リターン：登録するものがなければ何もしない
            if (character == null)
            {
                return;
            }
            //追加リストにキャラを追加
            addNewCharacter.Add(character);
        }

        private void HitToCharacters()
        {
            //プレイヤーで繰り返し
            foreach (var player in players)
            {
                //敵で繰り返し
                foreach (var enemy in enemys)
                {
                    //どちらか死んだら次へ
                    if (player.IsDead() || enemy.IsDead())
                    {
                        continue;
                    }
                    //プレイヤーと敵が衝突しているのか？
                    if (player.InCollision(enemy))
                    {
                        //互いにヒット通知
                        player.Hit(enemy);
                        enemy.Hit(player);
                    }
                }

            }
        }

        /// <summary>
        /// 死亡キャラの削除
        /// </summary>
        private void RemoveDeadCharacter()
        {
            //死んでいたら、リストから削除
            players.RemoveAll(p => p.IsDead());
            enemys.RemoveAll(e => e.IsDead());
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public void Update(GameTime gameTime)
        {
            //全キャラクター更新
            foreach (var p in players)
            {
                p.Update(gameTime);
            }
            foreach (var e in enemys)
            {
                e.Update(gameTime);
            }

            ////追加候補者をリストに追加
            foreach (var newChara in addNewCharacter)
            {
                //キャラがプレイヤーだったらプレイやリストに登録
                if (newChara is Kaito)
                {
                    newChara.Initialize();
                    players.Add(newChara);
                }
                //それ以外は敵リストに登録
                else
                {
                    newChara.Initialize();
                    enemys.Add(newChara);
                }
            }
            //追加処理後、追加リストはクリア
            addNewCharacter.Clear();

            //当たり判定
            HitToCharacters();

            //死亡フラグが立っていたら削除
            RemoveDeadCharacter();
        }

        public void Draw(Renderer renderer)
        {
            //全キャラ描画
            foreach (var e in enemys)
            {
                e.Draw(renderer);
            }
            foreach (var p in players)
            {
                p.Draw(renderer);
            }
        }
    }
}
