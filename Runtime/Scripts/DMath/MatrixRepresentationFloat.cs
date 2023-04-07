using System;
using UnityEngine;

namespace DanPie.Framework.DMath
{
    /// <summary>
    /// Created for working with Unity Inspector and JsonConverter;
    /// </summary>
    [Serializable]
    public class MatrixRepresentationFloat : MatrixRepresentation<float>
    {
        public MatrixRepresentationFloat(Vector2Int size) : base(size)
        {
        }

        public MatrixRepresentationFloat(float[] data, int columns) : base(data, columns)
        {
        }

        public MatrixRepresentationFloat(int columns, int rows) : base(columns, rows)
        {
        }
    }
}
