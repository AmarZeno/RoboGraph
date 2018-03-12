using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGGraphCore
{
    public class RGSearchAlgorithms
    {

        public static void BreadthFirstSearch<T>(RGGraph<T> graph, RGVertex<T> sourceVertex)
        {
            foreach (RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }

            Queue<RGVertex<T>> queue = new Queue<RGVertex<T>>();
            queue.Enqueue(sourceVertex);

            while (queue.Count > 0)
            {
                RGVertex<T> vertex = queue.Dequeue();
                foreach (RGVertex<T> neighbour in graph.GetAdjacentVertices(vertex))
                {
                    if (!neighbour.Visited)
                    {
                        neighbour.Parent = vertex;
                        neighbour.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, neighbour);
                        neighbour.Visited = true;

                        queue.Enqueue(neighbour);
                    }
                }

                vertex.Visited = true;
            }
        }

        public static List<RGVertex<T>> BreadthFirstSearchWithGoal<T>(RGGraph<T> graph, RGVertex<T> sourceVertex, RGVertex<T> goalVertex)
        {
            if (sourceVertex.Equals(goalVertex))
            {
                return new List<RGVertex<T>> { sourceVertex };
            }
            foreach (RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }

            Queue<RGVertex<T>> queue = new Queue<RGVertex<T>>();
            queue.Enqueue(sourceVertex);

            while (queue.Count > 0)
            {
                RGVertex<T> vertex = queue.Dequeue();

                foreach (RGVertex<T> neighbour in graph.GetAdjacentVertices(vertex))
                {
                    if (!neighbour.Visited)
                    {
                        neighbour.Parent = vertex;
                        neighbour.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, neighbour);
                        neighbour.Visited = true;

                        if (neighbour.Equals(goalVertex))
                        {
                            return GetPathToSource<T>(neighbour);
                        }

                        queue.Enqueue(neighbour);
                    }
                }
                vertex.Visited = true;
            }

            // no path to goal vertex
            return null;
        }

        public static List<RGVertex<T>> GetPathToSource<T>(RGVertex<T> from)
        {
            List<RGVertex<T>> path = new List<RGVertex<T>>();
            RGVertex<T> next = from;

            while (next != null)
            {
                path.Add(next);
                next = next.Parent;
            }

            return path;
        }

        // DFS BEGINS

        public static void DepthFirstSearch<T>(RGGraph<T> graph, RGVertex<T> sourceVertex, bool reverseNeighbours = false)
        {
            foreach (RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }


            Stack<RGVertex<T>> stack = new Stack<RGVertex<T>>();
            stack.Push(sourceVertex);

            while (stack.Count > 0)
            {
                RGVertex<T> vertex = stack.Pop();

                List<RGVertex<T>> neighbours = graph.GetAdjacentVertices(vertex);
                if (reverseNeighbours)
                {
                    neighbours.Reverse();
                }
                foreach (RGVertex<T> neighbour in neighbours)
                {
                    if (!neighbour.Visited)
                    {
                        neighbour.Parent = vertex;
                        neighbour.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, neighbour);
                        neighbour.Visited = true;

                        stack.Push(neighbour);
                    }
                }
                vertex.Visited = true;
            }
        }


        public static List<RGVertex<T>> DepthFirstSearchWithGoal<T>(RGGraph<T> graph, RGVertex<T> sourceVertex, RGVertex<T> goalVertex, bool reverseNeighbours = false)
        {
            if (sourceVertex.Equals(goalVertex))
            {
                return new List<RGVertex<T>> { sourceVertex };
            }

            foreach (RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }

            Stack<RGVertex<T>> stack = new Stack<RGVertex<T>>();
            stack.Push(sourceVertex);


            while (stack.Count > 0)
            {
                RGVertex<T> vertex = stack.Pop();

                List<RGVertex<T>> neighbours = graph.GetAdjacentVertices(vertex);
                if (reverseNeighbours)
                {
                    neighbours.Reverse();
                }
                foreach (RGVertex<T> neighbour in neighbours)
                {
                    if (!neighbour.Visited)
                    {
                        neighbour.Parent = vertex;
                        neighbour.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, neighbour);
                        neighbour.Visited = true;

                        if (neighbour.Equals(goalVertex))
                        {
                            return GetPathToSource<T>(neighbour);
                        }

                        stack.Push(neighbour);
                    }
                }
                vertex.Visited = true;
            }

            // no path found
            return null;
        }

        public static void Dijkstra<T>(RGGraph<T> graph, RGVertex<T> source)
        {
            List<RGVertex<T>> unfinishedVertices = new List<RGVertex<T>>();
            foreach (RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Distance = int.MaxValue;
                vertex.Parent = null;
                unfinishedVertices.Add(vertex);
            }
            source.Distance = 0;
            while (unfinishedVertices.Count > 0)
            {
                RGVertex<T> vertex = GetClosestVertex(unfinishedVertices);
                unfinishedVertices.Remove(vertex);
                foreach (RGVertex<T> adjVertex in graph.GetAdjacentVertices(vertex))
                {
                    if (adjVertex.Distance > vertex.Distance + graph.GetEdgeWeight(vertex, adjVertex))
                    {
                        adjVertex.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, adjVertex);
                        adjVertex.Parent = vertex;
                    }
                }
            }
        }

        public static List<RGVertex<T>> DijkstraWithGoal<T>(RGGraph<T> graph, RGVertex<T> source, RGVertex<T> goal)
        {
            if(source.Equals(goal))
            {
                return new List<RGVertex<T>> { source };
            }

            List<RGVertex<T>> unfinishedVertices = new List<RGVertex<T>>();
            foreach (RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Distance = int.MaxValue;
                vertex.Parent = null;
                unfinishedVertices.Add(vertex);
            }
            source.Distance = 0;
            while (unfinishedVertices.Count > 0)
            {
                RGVertex<T> vertex = GetClosestVertex(unfinishedVertices);
                unfinishedVertices.Remove(vertex);
                if(vertex.Equals(goal))
                {
                    return GetPathToSource(vertex);
                }
                foreach (RGVertex<T> adjVertex in graph.GetAdjacentVertices(vertex))
                {
                    if (adjVertex.Distance > vertex.Distance + graph.GetEdgeWeight(vertex, adjVertex))
                    {
                        adjVertex.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, adjVertex);
                        adjVertex.Parent = vertex;
                    }
                }
            }
            return null;
        }

        private static RGVertex<T> GetClosestVertex<T>(List<RGVertex<T>> list)
        {
            RGVertex<T> candidate = list[0];
            foreach (RGVertex<T> vertex in list)
            {
                if (vertex.Distance < candidate.Distance)
                {
                    // I can use binomial heap if required
                    candidate = vertex;
                }
            }

            return candidate;
        }

        private static RGGrid.Point GetClosestVertex(List<RGGrid.Point> list, Dictionary<RGGrid.Point, float> distanceMap)
        {
            RGGrid.Point candidate = list[0];
            foreach (RGGrid.Point vertex in list)
            {
                if (distanceMap[vertex] < distanceMap[candidate])
                {
                    // I can use binomial heap if required
                    candidate = vertex;
                }
            }

            return candidate;
        }

        public static List<RGGrid.Point> DepthFirstSearchInGrid(RGGrid grid, RGGrid.Point startPos, RGGrid.Point endPos)
        {
            if(startPos.Equals(endPos))
            {
                return new List<RGGrid.Point>() { startPos };
            }

            Dictionary<RGGrid.Point, RGGrid.Point> visitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            Stack<RGGrid.Point> stack = new Stack<RGGrid.Point>();
            stack.Push(startPos);

            while(stack.Count > 0)
            {
                RGGrid.Point node = stack.Pop();

                foreach(RGGrid.Point adj in grid.GetAdjacentCells(node))
                {
                    if(!visitedMap.ContainsKey(adj))
                    {
                        visitedMap.Add(adj, node);
                        stack.Push(adj);

                        if(adj.Equals(endPos))
                        {
                            return GeneratePath(visitedMap, adj);
                        }
                    }
                }
                if(!visitedMap.ContainsKey(node))
                {
                    visitedMap.Add(node, null);
                }
            }
            return null;
        }

        public static List<RGGrid.Point> BreadthFirstSearchInGrid(RGGrid grid, RGGrid.Point startPos, RGGrid.Point endPos)
        {
            if (startPos.Equals(endPos))
            {
                return new List<RGGrid.Point>() { startPos };
            }

            Dictionary<RGGrid.Point, RGGrid.Point> visitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            Queue<RGGrid.Point> queue = new Queue<RGGrid.Point>();
            queue.Enqueue(startPos);

            while (queue.Count > 0)
            {
                RGGrid.Point node = queue.Dequeue();

                foreach (RGGrid.Point adj in grid.GetAdjacentCells(node))
                {
                    if (!visitedMap.ContainsKey(adj))
                    {
                        visitedMap.Add(adj, node);
                        queue.Enqueue(adj);

                        if (adj.Equals(endPos))
                        {
                            return GeneratePath(visitedMap, adj);
                        }
                    }
                }
                if (!visitedMap.ContainsKey(node))
                {
                    visitedMap.Add(node, null);
                }
            }
            return null;
        }

        public static List<RGGrid.Point> DijkstraInGrid(RGGrid grid, RGGrid.Point startPos, RGGrid.Point endPos)
        {
            List<RGGrid.Point> unfinishedVertices = new List<RGGrid.Point>();
            Dictionary<RGGrid.Point, float> distanceMap = new Dictionary<RGGrid.Point, float>();
            Dictionary<RGGrid.Point, RGGrid.Point> visitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            unfinishedVertices.Add(startPos);

            distanceMap.Add(startPos, 0);
            visitedMap.Add(startPos, null);

            while(unfinishedVertices.Count > 0)
            {
                RGGrid.Point vertex = GetClosestVertex(unfinishedVertices, distanceMap);
                unfinishedVertices.Remove(vertex);
                if(vertex.Equals(endPos))
                {
                    return GeneratePath(visitedMap, vertex);
                }
                foreach(RGGrid.Point adj in grid.GetAdjacentCells(vertex))
                {
                    if(!visitedMap.ContainsKey(adj))
                    {
                        unfinishedVertices.Add(adj);
                    }

                    float adjDist = distanceMap.ContainsKey(adj) ? distanceMap[adj] : int.MaxValue;
                    float vDist = distanceMap.ContainsKey(vertex) ? distanceMap[vertex] : int.MaxValue;
                    if(adjDist > vDist + grid.GetCostOfEnteringCell(adj))
                    {
                        if(distanceMap.ContainsKey(adj))
                        {
                            distanceMap[adj] = vDist + grid.GetCostOfEnteringCell(adj);
                        }
                        else
                        {
                            distanceMap.Add(adj, vDist + grid.GetCostOfEnteringCell(adj));
                        }

                        if(visitedMap.ContainsKey(adj))
                        {
                            visitedMap[adj] = vertex;
                        }
                        else
                        {
                            visitedMap.Add(adj, vertex);
                        }
                    }
                }
            }
            return null;
        }
    }
}

