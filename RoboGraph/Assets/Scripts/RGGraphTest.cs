using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RGGraphCore
{
    public class RGGraphTest : MonoBehaviour
    {
        public TextAsset DirectedGraphFile;
        public TextAsset TreeFile;
        public TextAsset BFSFile;
        public TextAsset DFSFile;
        public TextAsset RandomGeneratorFile;
        public TextAsset SmallRandomGeneratorGraphFile;
        public TextAsset MedRandomGeneratorGraphFile;
        public TextAsset LargeRandomGeneratorGraphFile;

        private Debugging debugClass;
        void Start()
        {
            debugClass = this.gameObject.GetComponent<Debugging>();

            TestDirectedGraph();
            TestTree();
            TestBFS();
            TestDFS();
            TestRandomGeneratorWithString();
            TestRandomGeneratorWithVertexAndEdges();
        }

        void TestDirectedGraph()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Begin Testing Directed Graph").AppendLine();

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

            sb.Append(graph.ToString()).AppendLine();

            sb.Append("End of Testing Directed Graph").AppendLine();

            debugClass.WriteStringToFile(DirectedGraphFile, sb.ToString());
        }

        void TestTree()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Begin Testing Tree").AppendLine();

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

            sb.Append("Tree values are ").Append(tree).AppendLine();
            sb.Append("End Testing Tree").AppendLine();

            debugClass.WriteStringToFile(TreeFile, sb.ToString());
        }

        void TestBFS()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Begin BFS test").AppendLine();

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

            sb.Append(graphData).AppendLine();

            sb.Append("Running BFS from : ").Append(V4.ToString()).AppendLine();
            RGSearchAlgorithms.BreadthFirstSearch<string>(graph, V4);

            List<RGVertex<string>> fromV6 = RGSearchAlgorithms.GetPathToSource<string>(V6);
            sb.Append("Start vertex : V6").AppendLine();
            foreach (RGVertex<string> vertex in fromV6)
            {
                sb.Append(vertex.ToString());
            }

            sb.AppendLine();

            List<RGVertex<string>> path = RGSearchAlgorithms.BreadthFirstSearchWithGoal<string>(graph, V6, V3);
            sb.Append("Path from v3 to v6").AppendLine();
            foreach (RGVertex<string> vertex in path)
            {
                sb.Append(vertex.ToString());
            }

            sb.AppendLine();
            sb.Append("End BFS test").AppendLine();

            debugClass.WriteStringToFile(BFSFile, sb.ToString());
        }

        void TestDFS()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Begin DFS test").AppendLine();

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

            sb.Append(graphData).AppendLine();

            sb.Append("Running DFS from:").Append(V4.ToString()).AppendLine();
            RGSearchAlgorithms.DepthFirstSearch<string>(graph, V4);

            List<RGVertex<string>> fromV6 = RGSearchAlgorithms.GetPathToSource<string>(V6);
            sb.Append("Start vertex : V6").AppendLine();
            foreach (RGVertex<string> vertex in fromV6)
            {
                sb.Append(vertex.ToString());
            }

            sb.AppendLine();

            List<RGVertex<string>> path = RGSearchAlgorithms.DepthFirstSearchWithGoal<string>(graph, V6, V3);
            sb.Append("Path from v3 to v6").AppendLine();
            foreach (RGVertex<string> vertex in path)
            {
                sb.Append(vertex.ToString());
            }

            sb.AppendLine();
            sb.Append("End DFS test").AppendLine();
            debugClass.WriteStringToFile(DFSFile, sb.ToString());
        }

        void TestRandomGeneratorWithString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Begin random generator puzzle solver").AppendLine();

            string state = PuzzleSolver.GenerateRandomSolvableState();
            sb.Append("Solving " + PuzzleSolver.PrintableState(state)).AppendLine();

            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            List<string> path = PuzzleSolver.DepthFirstSearch(state);
            stopWatch.Stop();

            sb.Append("Depth first search took " + stopWatch.ElapsedMilliseconds + " ms").AppendLine();
            sb.Append("Depth first search path contains " + path.Count + " states").AppendLine();

            stopWatch.Reset();
            stopWatch.Start();
            path = PuzzleSolver.BreadthFirstSearch(state);
            stopWatch.Stop();

            sb.Append("Breadth first search took " + stopWatch.ElapsedMilliseconds + " ms").AppendLine();
            sb.Append("Breadth first search path contains " + path.Count + " states").AppendLine();

            sb.Append("Printing Solution");
            foreach(string p in path)
            {
                sb.Append(PuzzleSolver.PrintableState(p));
            }

            sb.Append("End puzzle solver").AppendLine();

            debugClass.WriteStringToFile(RandomGeneratorFile, sb.ToString());
        }

        void TestRandomGeneratorWithVertexAndEdges()
        {
            Debug.Log("Begin random generator graph");

            StringBuilder sb = new StringBuilder();

            sb.Append("Random Graph Min Size").AppendLine();
            RGRandomGraph randomGraph = new RGRandomGraph();

            int NoOfNodesToGenerate = 10;
            randomGraph.GenerateNodes(NoOfNodesToGenerate);
            randomGraph.ApplyDirectedEdge();
            string graphData = randomGraph.ToString();
            sb.Append(graphData).AppendLine().AppendLine();
            debugClass.WriteStringToFile(SmallRandomGeneratorGraphFile, sb.ToString());

            sb.Length = 0;
            sb.Append("Random Graph Medium Size").AppendLine();
            NoOfNodesToGenerate = 50;
            randomGraph.GenerateNodes(NoOfNodesToGenerate);
            randomGraph.ApplyDirectedEdge();
            graphData = randomGraph.ToString();
            sb.Append(graphData).AppendLine().AppendLine();
            debugClass.WriteStringToFile(MedRandomGeneratorGraphFile, sb.ToString());

            sb.Length = 0;
            sb.Append("Random Graph Medium Size").AppendLine();
            NoOfNodesToGenerate = 16000;
            randomGraph.GenerateNodes(NoOfNodesToGenerate);
            randomGraph.ApplyDirectedEdge();
            graphData = randomGraph.ToString();
            sb.Append(graphData).AppendLine().AppendLine();
            debugClass.WriteStringToFile(LargeRandomGeneratorGraphFile, sb.ToString());

            Debug.Log("End random generator graph");
        }
    }
}