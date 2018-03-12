using RGGraphCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGRandomGraph : MonoBehaviour {

    List<RGVertex<string>> vertices;
    RGGraph<string> graph;

    private const int MINEDGECOST = 1;
    private const int MAXEDGECOST = 2;
    private const int MINEDGECOUNT = 0;
    private const int MAXEDGECOUNT = 4;

    public void GenerateNodes(int nodeCount)
    {
        vertices = new List<RGVertex<string>>();

        vertices.Clear();

        for(int i = 0; i < nodeCount; i++)
        {
            RGVertex<string> newVertexNode = new RGVertex<string>("V" + i);
            vertices.Add(newVertexNode);
        }
    }

    public void ApplyDirectedEdge()
    {
        graph = new RGGraph<string>(vertices);

        int noOfVertices = vertices.Count;
        for(int i = 0; i < noOfVertices; i++)
        {
            int randomEdgeCount = Random.Range(MINEDGECOUNT, MAXEDGECOUNT + 1);
            for(int j = 1; j <= randomEdgeCount; j++)
            {
                RGVertex<string> randomVertex = GetRandomVertex();
                int randomEdgeCost = Random.Range(MINEDGECOST, MAXEDGECOST + 1);
                graph.CreateDirectedEdge(vertices[i], randomVertex, randomEdgeCost);
            }
        }
    }

    RGVertex<string> GetRandomVertex()
    {
        int randomSeed = Random.Range(0, vertices.Count);
        return vertices[randomSeed];
    }

    public override string ToString()
    {
        return graph.ToString();
    }
}
