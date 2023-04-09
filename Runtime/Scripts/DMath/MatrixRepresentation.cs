using System;
using System.Collections.Generic;
using UnityEngine;

namespace DanPie.Framework.DMath
{
    [Serializable]
    public class MatrixRepresentation<T> : IReadonlyMatrixRepresentation<T>
    {
        [HideInInspector]
        [SerializeField] private T[] _data;

        private int _rows;
        private int _columns;

        public int Rows { get => _rows; }
        public int Columns { get => _columns; }
        public int FullLength { get => _data.Length; }
        public Vector2Int Size { get => new Vector2Int(_columns, _rows); }

        public T this[int id]
        {
            get => _data[id];
            set => _data[id] = value;
        }

        public T this[int column, int row]
        {
            get
            {
                if (row < 0 || row >= _rows || column < 0 || column >= _columns)
                {
                    throw new IndexOutOfRangeException($"Index out of range. Row:{row}; Column:{column}");
                }
                return _data[row * _columns + column];
            }
            set
            {
                if (row < 0 || row >= _rows || column < 0 || column >= _columns)
                {
                    throw new IndexOutOfRangeException($"Index out of range. Row:{row}; Column:{column}");
                }
                _data[row * _columns + column] = value;
            }
        }

        public MatrixRepresentation(T[] data, int columns)
        {
            if (columns <= 0)
            {
                throw new ArgumentException($"Invalid columns count: {columns};");
            }

            if (data.Length % columns != 0)
            {
                throw new ArgumentException($"Invalid columns count: {columns}; or data.");
            }

            _rows = data.Length / columns;
            _columns = columns;
            _data = data;
        }

        public MatrixRepresentation(int columns, int rows)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Invalid matrix size");
            }
            _rows = rows;
            _columns = columns;
            _data = new T[rows * columns];
        }

        public MatrixRepresentation(Vector2Int size) : this(size.x, size.y)
        {

        }

        public int VectorToID(Vector2Int vector)
        {
            return vector.y * _columns + vector.x;
        }

        public Vector2Int FromIDToVector(int dataID)
            => new Vector2Int(dataID % _columns, dataID / _columns);

        public IEnumerable<T> GetEnumerable() => _data;

        public bool IsPointInside(Vector2Int point)
        {
            return point.x >= 0 && point.x < Columns
                && point.y >= 0 && point.y < Rows;
        }

        public void SetMatrixMember(MatrixMember<T> matrixMember)
        {
            _data[matrixMember.ID] = matrixMember.Data;
        }

        public MatrixMember<T> GetMatrixMember(Vector2Int columnRowVector)
        {
            return new MatrixMember<T>(GetData(columnRowVector), VectorToID(columnRowVector));
        }

        public T GetData(Vector2Int columnRowVector)
            => this[columnRowVector.x, columnRowVector.y];

        public void SetData(Vector2Int columnRowVector, T value)
            => this[columnRowVector.x, columnRowVector.y] = value;

        public Neighbours2D<T> GetNeighboursOfMatrixMember(Vector2Int matrixMemberPosition)
        {
            MatrixMember<T>?[] neighbours = new MatrixMember<T>?[9];
            int id = 0;
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    var neighborPosition = matrixMemberPosition + new Vector2Int(x, -y);
                    try
                    {
                        neighbours[id] = GetMatrixMember(neighborPosition);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        continue;
                    }
                    id++;
                }
            }
            return new Neighbours2D<T>(neighbours);
        }
    }
}
