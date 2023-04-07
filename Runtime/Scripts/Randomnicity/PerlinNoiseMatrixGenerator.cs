using DanPie.Framework.DMath;
using UnityEngine;

namespace DanPie.Framework.Randomnicity
{
    public class PerlinNoiseMatrixGenerator : RandUser
    {
        private Vector2Int _matrixSize;

        public PerlinNoiseMatrixGenerator(
            Vector2Int matrixSize,
            float noiseScale,
            int offsetRange = 100000,
            int? seed = null)
        {
            _matrixSize = matrixSize;
            NoiseScale = noiseScale;
            OffsetRange = offsetRange;

            if(seed != null)
            {
                UpdateSeed((int)seed);
            }
        }

        public float NoiseScale { get; private set; }
        public int OffsetRange { get; private set; }

        public MatrixRepresentationFloat GenerateNoise()
            => GenerateNoise(NoiseScale, OffsetRange);

        public MatrixRepresentationFloat GenerateNoise(float noiseScale, int offsetRange)
        {
            NoiseScale = noiseScale;
            OffsetRange = offsetRange;
            MatrixRepresentationFloat noiseMap = new MatrixRepresentationFloat(_matrixSize);
            float scale = NoiseScale;
            float offsetX = Rand.Next(-OffsetRange, OffsetRange);
            float offsetY = Rand.Next(-OffsetRange, OffsetRange);

            for (int y = 0; y < noiseMap.Rows; y++)
            {
                for (int x = 0; x < noiseMap.Columns; x++)
                {
                    float sampleX = (float)x / noiseMap.Columns * scale + offsetX;
                    float sampleY = (float)y / noiseMap.Rows * scale + offsetY;

                    float noise = Mathf.PerlinNoise(sampleX, sampleY);
                    noiseMap[y, x] = noise;
                }
            }

            return noiseMap;
        }
    }
}
