using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Team06.Device;




namespace Team06.Scene
{
    class Ending : IScene
    {
        private bool isEndFlag;
        private Sound sound;
        IScene backGroundScene;

        public Ending(IScene scene)
        {
            isEndFlag = false;

            backGroundScene = scene;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
        }

        public void Draw(Renderer renderer)
        {
            //シーンごとにrenderer.Begin()～End()を書いているののに注意
            //背景となるゲームプレイシーン
            backGroundScene.Draw(renderer);

            renderer.Begin();
            renderer.DrawTexture("ending", new Vector2(150, 150));
            renderer.End();
        }

        public void Intialize()
        {
            isEndFlag = false;
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.Title;
        }

        public void Shutdown()
        {
            sound.StopBGM();
        }

        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("endingbgm");
            if (Input.GetKeyTrigger(Keys.Space))
            {

                isEndFlag = true;
                sound.PlaySE("endingse");
            }
        }
    }
}
