
namespace RGGraphCore
{
    public class RGVertex<T>
    {
        public int Index { get; set; }

        private T _data;
        public T Data { get { return _data; } }

        public RGVertex(T data)
        {
            _data = data;
            Index = -1;
        }

        public override string ToString()
        {
            return "{Vertex}" + Data.ToString();
        }
    }
}
