namespace DanPie.Framework.DMath
{
    public struct MatrixMember<T>
    {
        private T _data;
        private int _id;

        public T Data { get => _data; }
        public int ID { get => _id; }

        public MatrixMember(T data, int id)
        {
            _data = data;
            _id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is MatrixMember<T>)
            {
                MatrixMember<T> member = (MatrixMember<T>)obj;
                return member.ID == _id && member.Data.Equals(_data);   
            }

            return  false;
        }
    }
}
