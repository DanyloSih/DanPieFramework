using System;
using System.Collections;
using UnityEngine;

namespace DanPie.Framework.DMath
{
    [Serializable]
    public class MatrixRepresentation<T>
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

        public Vector2Int FormIDToVector(int dataID)
            => new Vector2Int(dataID % _columns, dataID / _columns);

        public IEnumerable GetEnumerable() => _data;

        public T Get(Vector2Int columnRowVector)
            => this[columnRowVector.x, columnRowVector.y];

        public void Set(Vector2Int columnRowVector, T value)
            => this[columnRowVector.x, columnRowVector.y] = value;
    }
}
