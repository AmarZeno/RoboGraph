using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGGraphCore
{
    public class RGGraphTest : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("Begin Testing");

            RGVertex<string> V1 = new RGVertex<string>("v1");
            RGVertex<string> V2 = new RGVertex<string>("v2");
            RGVertex<string> V3 = new RGVertex<string>("v3");
            RGVertex<string> V4 = new RGVertex<string>("v4");

            List<RGVertex<string>> Vertices = new List<RGVertex<string>> {
                V1, V2, V3, V4
            };

            RGGraph<string> graph = new RGGraph<string>(Vertices);

            graph.CreateDirectedEdge(V1, V2, 3);
            graph.CreateDirectedEdge(V4, V1, 1);
            graph.CreateDirectedEdge(V2, V3, 1);
            graph.CreateDirectedEdge(V2, V4, -5);

            string test = graph.ToString();
            Debug.Log(graph.ToString());

            Debug.Log("End of Testing");
        }
    }
}