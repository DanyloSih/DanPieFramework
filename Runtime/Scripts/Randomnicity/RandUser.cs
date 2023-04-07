using Random = System.Random;

namespace DanPie.Framework.Randomnicity
{
    public class RandUser
    {
        private Random _rand = new Random();
        private int _seed;

        public void UpdateSeed(int seed)
        {
            _seed = seed;
            _rand = new Random(_seed);
        }

        public int Seed { get => _seed; }
        public Random Rand { get => _rand; }
    }
}
