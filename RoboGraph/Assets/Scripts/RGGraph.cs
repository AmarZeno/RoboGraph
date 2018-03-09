
using RGGraphCore;
using System.Collections.Generic;
using System.Text;
namespace RGGraphCore
{
    public class RGGraph<T>
    {
        private List<RGVertex<T>> _vertices;
        public List<RGVertex<T>> Vertices { get { return _vertices; } }

        private RGAdjacencyMatrix _adjacencyMatrix;

        public RGGraph(List<RGVertex<T>> Vertices)
        {
            _vertices = Vertices;
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i].Index = i;
            }
            _adjacencyMatrix = new RGAdjacencyMatrix(_vertices.Count);
        }

        public void CreateDirectedEdge(int fromIndex, int toIndex, float weight = 1)
        {
            _adjacencyMatrix.AddDirectedEdge(fromIndex, toIndex, weight);
        }

        public void CreateDirectedEdge(RGVertex<T> from, RGVertex<T> to, float weight = 1)
        {
            this.CreateDirectedEdge(from.Index, to.Index, weight);
        }

        public void CreateUnDirectedEdge(int fromIndex, int toIndex, float weight = 1)
        {
            _adjacencyMatrix.AddUndirectedEdge(fromIndex, toIndex, weight);
        }

        public void CreateUnDirectedEdge(RGVertex<T> from, RGVertex<T> to, float weight = 1)
        {
            this.CreateUnDirectedEdge(from.Index, to.Index, weight);
        }

        public List<RGVertex<T>> GetAdjacentVertices(int sourceIndex)
        {
            List<int> adjacentIndices = _adjacencyMatrix.GetAdjacencyList(sourceIndex);
            List<RGVertex<T>> adjacentVertices = new List<RGVertex<T>>();

            foreach (int vertexIndex in adjacentIndices)
            {
                adjacentVertices.Add(_vertices[vertexIndex]);
            }

            return adjacentVertices;
        }

        public List<RGVertex<T>> GetAdjacentVertices(RGVertex<T> source)
        {
            return GetAdjacentVertices(source.Index);
        }

        public float GetEdgeWeight(RGVertex<T> V1, RGVertex<T> V2)
        {
            return _adjacencyMatrix.GetEdgeWeight(V1.Index, V2.Index);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Graph:");
            foreach (RGVertex<T> vertex in _vertices)
            {
                sb.AppendLine(vertex.Data.ToString());
                sb.Append("\t");
                List<RGVertex<T>> adjacentVertices = GetAdjacentVertices(vertex);
                if (adjacentVertices.Count > 0)
                {
                    sb.Append("Edge to: ");
                    foreach (RGVertex<T> adjVertex in adjacentVertices)
                    {
                        sb.Append(adjVertex.Data.ToString());
                        sb.Append("(w=");
                        sb.Append(GetEdgeWeight(vertex, adjVertex));
                        sb.Append(") ");
                    }
                }
                else
                {
                    sb.Append("No outgoing edges");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}