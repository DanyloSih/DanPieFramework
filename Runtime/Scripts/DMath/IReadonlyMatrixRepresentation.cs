using System.Collections.Generic;
using UnityEngine;

namespace DanPie.Framework.DMath
{
    public interface IReadonlyMatrixRepresentation<T>
    {
        T this[int id] { get; }
        T this[int column, int row] { get; }

        int Columns { get; }
        int FullLength { get; }
        int Rows { get; }
        Vector2Int Size { get; }

        Vector2Int FromIDToVector(int dataID);
        T GetData(Vector2Int columnRowVector);
        MatrixMember<T> GetMatrixMember(Vector2Int columnRowVector);
        IEnumerable<T> GetEnumerable();
        Neighbours2D<T> GetNeighboursOfMatrixMember(Vector2Int matrixMemberPosition);
        bool IsPointInside(Vector2Int point);
        int VectorToID(Vector2Int vector);
    }
}