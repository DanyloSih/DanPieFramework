using System;
using UnityEngine;

namespace DanPie.Framework.DMath
{
    /// <summary>
    /// Created for working with Unity Inspector and JsonConverter;
    /// </summary>
    [Serializable]
    public class MatrixRepresentationInt : MatrixRepresentation<int>
    {
        public MatrixRepresentationInt(Vector2Int size) : base(size)
        {
        }

        public MatrixRepresentationInt(int[] data, int columns) : base(data, columns)
        {
        }

        public MatrixRepresentationInt(int columns, int rows) : base(columns, rows)
        {
        }
    }
}
