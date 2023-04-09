using DanPie.Framework.Extensions;
using Random = System.Random;

namespace DanPie.Framework.Randomnicity
{
    public class RandUser
    {
        private Random _rand = new Random();
        private int? _seed = null;

        public int Seed 
        { 
            get => (int)(_seed = _seed == null ? _rand.NextInt() : _seed);

            set
            {
                _seed = value;
                _rand = new Random(Seed);
            }
        }
        public Random Rand { get => _rand; }

        public RandUser(int? seed)
        {
            _seed = seed;
        }

        public RandUser()
        {
        }
    }
}
