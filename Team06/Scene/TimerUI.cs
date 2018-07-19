using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Team06.Device;
using Team06.Util;


namespace Team06.Scene
{
    class TimerUI
    {
        private Timer timer;

        public TimerUI(Timer timer)
        {
            this.timer = timer;
        }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("timer", new Vector2(400, 10));
            renderer.DrawNumber("number", new Vector2(600, 13), timer.Now());
        }

        public void Draw(Renderer renderer,Vector2 position)
        {
            renderer.DrawTexture("timer", position);
            renderer.DrawNumber("number", position + new Vector2(200, 3), timer.Now());
        }
    }
}
