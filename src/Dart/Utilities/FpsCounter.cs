using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public class FpsCounter
    {
        private readonly TimeSpan _oneSecond = TimeSpan.FromSeconds(1);

        private int _counter;
        private TimeSpan _elapsed;
        public int FPS { get; private set; }

        public FpsCounter()
        {
            _counter = 0;
            _elapsed = TimeSpan.Zero;
        }

        public bool Update(GameTime gameTime)
        {
            _counter++;
            _elapsed += gameTime.ElapsedGameTime;

            if(_elapsed >= _oneSecond)
            {
                FPS = _counter;
                _counter = 0;
                _elapsed -= _oneSecond;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{FPS} fps";
        }
    }
}
