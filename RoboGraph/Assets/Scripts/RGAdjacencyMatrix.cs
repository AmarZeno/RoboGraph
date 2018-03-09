using System.Collections.Generic;

namespace RGGraphCore
{
    public class RGAdjacencyMatrix
    {
        private float[,] _matrix;
        private int _size;
        public int Size { get { return _size; } }

        public RGAdjacencyMatrix(int size)
        {
            _matrix = new float[size, size];
            _size = size;
        }

        public void AddDirectedEdge(int from, int to, float weight)
        {
            _matrix[from, to] = weight;
        }

        public void AddUndirectedEdge(int V1, int V2, float weight)
        {
            _matrix[V1, V2] = weight;
            _matrix[V2, V1] = weight;
        }

        public float GetEdgeWeight(int x, int y)
        {
            return _matrix[x, y];
        }

        public List<int> GetAdjacencyList(int sourceIndex)
        {
            List<int> adjacencyList = new List<int>();
            for (int i = 0; i < _size; i++)
            {
                if (_matrix[sourceIndex, i] != 0)
                {
                    adjacencyList.Add(i);
                }
            }

            return adjacencyList;
        }
    }
}