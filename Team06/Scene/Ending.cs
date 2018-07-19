using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Team06.Device;
using Team06.Util;

namespace Team06.Scene
{
    class Ending : IScene
    {
        private bool isEndFlag;
        private Sound sound;
        private TimerUI timerUI;
        private Timer scoreTimer;
        IScene backGroundScene;

        public Ending(IScene scene,Timer scoreTimer)
        {
            isEndFlag = false;
            backGroundScene = scene;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
            this.scoreTimer = scoreTimer;
        }
        public void Draw(Renderer renderer)
        {
            //シーンごとにrenderer.Begin()～End()を書いているののに注意
            //背景となるゲームプレイシーン
            backGroundScene.Draw(renderer);

            renderer.Begin();
            renderer.DrawTexture("ending", new Vector2(0,0));
            timerUI.Draw(renderer, new Vector2(100, 100));
            renderer.End();
        }
        public void Intialize()
        {
            isEndFlag = false;

            timerUI = new TimerUI(scoreTimer);
            
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
            
            if (Input.GetKeyTrigger(Keys.Space))
            {     
                isEndFlag = true;
            }
        }
    }
}
