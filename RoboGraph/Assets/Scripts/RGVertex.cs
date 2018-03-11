
namespace RGGraphCore
{
    public class RGVertex<T>
    {
        public int Index { get; set; }

        private T _data;
        public T Data { get { return _data; } }

        // Track searching
        public RGVertex<T> Parent { get; set; }
        public bool Visited { get; set; }
        public float Distance { get; set; }

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
