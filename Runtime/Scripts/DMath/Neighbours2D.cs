using System;
using System.Collections.Generic;

namespace DanPie.Framework.DMath
{
    public struct Neighbours2D<T>
    {
        private MatrixMember<T>? _leftTopMember;
        private MatrixMember<T>? _middleTopMember;
        private MatrixMember<T>? _rightTopMember;
        private MatrixMember<T>? _leftCenterMember;
        private MatrixMember<T>? _middleCenterMember;
        private MatrixMember<T>? _rightCenterMember;
        private MatrixMember<T>? _leftBottomMember;
        private MatrixMember<T>? _middleBottomMember;
        private MatrixMember<T>? _rightBottomMember;

        public MatrixMember<T>? LeftTopMember { get => _leftTopMember; }
        public MatrixMember<T>? MiddleTopMember { get => _middleTopMember; }
        public MatrixMember<T>? RightTopMember { get => _rightTopMember; }
        public MatrixMember<T>? LeftCenterMember { get => _leftCenterMember; }
        public MatrixMember<T>? MiddleCenterMember { get => _middleCenterMember; }
        public MatrixMember<T>? RightCenterMember { get => _rightCenterMember; }
        public MatrixMember<T>? LeftBottomMember { get => _leftBottomMember; }
        public MatrixMember<T>? MiddleBottomMember { get => _middleBottomMember; }
        public MatrixMember<T>? RightBottomMember { get => _rightBottomMember; }

        public Neighbours2D(
            MatrixMember<T>? leftTopMember = null,
            MatrixMember<T>? middleTopMember = null,
            MatrixMember<T>? rightTopMember = null,
            MatrixMember<T>? leftCenterMember = null,
            MatrixMember<T>? middleCenterMember = null,
            MatrixMember<T>? rightCenterMember = null,
            MatrixMember<T>? leftBottomMember = null,
            MatrixMember<T>? middleBottomMember = null,
            MatrixMember<T>? rightBottomMember = null)
        {
            _leftTopMember = leftTopMember;
            _middleTopMember = middleTopMember;
            _rightTopMember = rightTopMember;
            _leftCenterMember = leftCenterMember;
            _middleCenterMember = middleCenterMember;
            _rightCenterMember = rightCenterMember;
            _leftBottomMember = leftBottomMember;
            _middleBottomMember = middleBottomMember;
            _rightBottomMember = rightBottomMember;
        }

        /// <summary>
        /// The array must contain 9 elements. The array may contain null if it 
        /// means that there is no neighbor at such a position. A one-dimensional
        /// array actually contains a 3x3 matrix "123/456/789". The elements must be in this order:
        /// LeftTop, MiddleTop, RightTop, LeftCenter, MiddleCenter, RightCenter, 
        /// LeftBottom, MiddleBottom, RightBottom.
        /// </summary>
        public Neighbours2D(MatrixMember<T>?[] matrixMembers)
        {
            if (matrixMembers == null || matrixMembers.Length != 9)
            {
                throw new ArgumentException($"Invalid array format! Read the description of the method.");
            }

            _leftTopMember = matrixMembers[0];
            _middleTopMember = matrixMembers[1];
            _rightTopMember = matrixMembers[2];
            _leftCenterMember = matrixMembers[3];
            _middleCenterMember = matrixMembers[4];
            _rightCenterMember = matrixMembers[5];
            _leftBottomMember = matrixMembers[6];
            _middleBottomMember = matrixMembers[7];
            _rightBottomMember = matrixMembers[8];
        }

        /// <summary>
        /// Returns a stream of all non-null matrix members.
        /// </summary>
        public IEnumerable<MatrixMember<T>?> GetAllAvailableMembers()
        {
            if (_leftTopMember != null) yield return _leftTopMember;
            if (_middleTopMember != null) yield return _middleTopMember;
            if (_rightTopMember != null) yield return _rightTopMember;
            if (_leftCenterMember != null) yield return _leftCenterMember;
            if (_middleCenterMember != null) yield return _middleCenterMember;
            if (_rightCenterMember != null) yield return _rightCenterMember;
            if (_leftBottomMember != null) yield return _leftBottomMember;
            if (_middleBottomMember != null) yield return _middleBottomMember;
            if (_rightBottomMember != null) yield return _rightBottomMember;
        }

        /// <summary>
        /// Returns a stream of non-null neighbors, without central matrix member.
        /// </summary>
        public IEnumerable<MatrixMember<T>?> GetAvailableNeighbours()
        {
            if (_leftTopMember != null) yield return _leftTopMember;
            if (_middleTopMember != null) yield return _middleTopMember;
            if (_rightTopMember != null) yield return _rightTopMember;
            if (_leftCenterMember != null) yield return _leftCenterMember;
            if (_rightCenterMember != null) yield return _rightCenterMember;
            if (_leftBottomMember != null) yield return _leftBottomMember;
            if (_middleBottomMember != null) yield return _middleBottomMember;
            if (_rightBottomMember != null) yield return _rightBottomMember;
        }

        /// <summary>
        /// Returns a stream of such non-null neighbors: middle top, left center, right center, middle bottom.
        /// </summary>
        public IEnumerable<MatrixMember<T>?> GetAvailableNeighboursOnMainAxes()
        {
            if (_middleTopMember != null) yield return _middleTopMember;
            if (_leftCenterMember != null) yield return _leftCenterMember;
            if (_rightCenterMember != null) yield return _rightCenterMember;
            if (_middleBottomMember != null) yield return _middleBottomMember;
        }
    }
}
