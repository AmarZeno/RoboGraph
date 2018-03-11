using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGGraphCore
{
    public class RGGraphTest : MonoBehaviour
    {
        void Start()
        {
            //  TestDirectedGraph();
            //  TestTree();
            //  TestBFS();
            TestDFS();
        }

        void TestDirectedGraph()
        {
            Debug.Log("Begin Testing Directed Graph");

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

            Debug.Log("End of Testing Directed Graph");
        }

        void TestTree()
        {
            Debug.Log("Begin Testing Tree");

            RGTreeNode<string> root = new RGTreeNode<string>("Root");
            RGTreeNode<string> node1 = new RGTreeNode<string>("L1");
            RGTreeNode<string> node2 = new RGTreeNode<string>("L2");
            RGTreeNode<string> node3 = new RGTreeNode<string>("L3");
            RGTreeNode<string> leaf1_1 = new RGTreeNode<string>("L11");
            RGTreeNode<string> leaf1_2 = new RGTreeNode<string>("L12");
            RGTreeNode<string> leaf1_3 = new RGTreeNode<string>("L13");
            RGTreeNode<string> leaf2_1 = new RGTreeNode<string>("L21");
            RGTreeNode<string> leaf2_2 = new RGTreeNode<string>("L22");

            root.AddChild(node1);
            root.AddChild(node2);
            root.AddChild(node3);

            node1.AddChild(leaf1_1);
            node1.AddChild(leaf1_2);
            node1.AddChild(leaf1_3);

            node2.AddChild(leaf2_1);
            node2.AddChild(leaf2_2);

            string tree = root.SubTreeToString();

            Debug.Log("Tree values are " + tree);

            Debug.Log("End Testing Tree");
        }

        void TestBFS()
        {
            Debug.Log("Begin BFS test");

            RGVertex<string> V1 = new RGVertex<string>("V1");
            RGVertex<string> V2 = new RGVertex<string>("V2");
            RGVertex<string> V3 = new RGVertex<string>("V3");
            RGVertex<string> V4 = new RGVertex<string>("V4");
            RGVertex<string> V5 = new RGVertex<string>("V5");
            RGVertex<string> V6 = new RGVertex<string>("V6");
            RGVertex<string> V7 = new RGVertex<string>("V7");

            List<RGVertex<string>> vertices = new List<RGVertex<string>>
            {
                V1, V2, V3, V4, V5, V6, V7
            };

            RGGraph<string> graph = new RGGraph<string>(vertices);

            graph.CreateUnDirectedEdge(V4, V5);
            graph.CreateUnDirectedEdge(V4, V2);
            graph.CreateUnDirectedEdge(V4, V1);
            graph.CreateUnDirectedEdge(V5, V6);
            graph.CreateUnDirectedEdge(V2, V5);
            graph.CreateUnDirectedEdge(V2, V7);
            graph.CreateUnDirectedEdge(V2, V1);
            graph.CreateUnDirectedEdge(V1, V3);
            graph.CreateUnDirectedEdge(V1, V7);
            graph.CreateUnDirectedEdge(V7, V6);

            string graphData = graph.ToString();

            Debug.Log(graphData);

            RGSearchAlgorithms.BreadthFirstSearch<string>(graph, V4);

            List<RGVertex<string>> fromV6 = RGSearchAlgorithms.GetPathToSource<string>(V6);
            Debug.Log("Start vertex : V6");
            foreach(RGVertex<string> vertex in fromV6)
            {
                Debug.Log(vertex);
            }

            List<RGVertex<string>> path = RGSearchAlgorithms.BreadthFirstSearchWithGoal<string>(graph, V6, V3);
            Debug.Log("Path from v3 to v6");
            foreach (RGVertex<string> vertex in path)
            {
                Debug.Log(vertex);
            }

            Debug.Log("End BFS test");
        }

        void TestDFS()
        {
            Debug.Log("Begin BFS test");

            RGVertex<string> V1 = new RGVertex<string>("V1");
            RGVertex<string> V2 = new RGVertex<string>("V2");
            RGVertex<string> V3 = new RGVertex<string>("V3");
            RGVertex<string> V4 = new RGVertex<string>("V4");
            RGVertex<string> V5 = new RGVertex<string>("V5");
            RGVertex<string> V6 = new RGVertex<string>("V6");
            RGVertex<string> V7 = new RGVertex<string>("V7");

            List<RGVertex<string>> vertices = new List<RGVertex<string>>
            {
                V1, V2, V3, V4, V5, V6, V7
            };

            RGGraph<string> graph = new RGGraph<string>(vertices);

            graph.CreateUnDirectedEdge(V4, V5);
            graph.CreateUnDirectedEdge(V4, V2);
            graph.CreateUnDirectedEdge(V4, V1);
            graph.CreateUnDirectedEdge(V5, V6);
            graph.CreateUnDirectedEdge(V2, V5);
            graph.CreateUnDirectedEdge(V2, V7);
            graph.CreateUnDirectedEdge(V2, V1);
            graph.CreateUnDirectedEdge(V1, V3);
            graph.CreateUnDirectedEdge(V1, V7);
            graph.CreateUnDirectedEdge(V7, V6);

            string graphData = graph.ToString();

            Debug.Log(graphData);

            RGSearchAlgorithms.DepthFirstSearch<string>(graph, V4);

            List<RGVertex<string>> fromV6 = RGSearchAlgorithms.GetPathToSource<string>(V6);
            Debug.Log("Start vertex : V6");
            foreach (RGVertex<string> vertex in fromV6)
            {
                Debug.Log(vertex);
            }

            List<RGVertex<string>> path = RGSearchAlgorithms.DepthFirstSearchWithGoal<string>(graph, V6, V3);
            Debug.Log("Path from v3 to v6");
            foreach (RGVertex<string> vertex in path)
            {
                Debug.Log(vertex);
            }

            Debug.Log("End BFS test");
        }
    }
}