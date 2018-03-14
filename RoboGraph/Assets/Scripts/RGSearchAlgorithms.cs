using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public static List<RGGrid.Point> GeneratePath(Dictionary<RGGrid.Point, RGGrid.Point> parentMap, RGGrid.Point endState)
        {
            List<RGGrid.Point> path = new List<RGGrid.Point>();
            RGGrid.Point parent = endState;
            while (parent != null && parentMap.ContainsKey(parent))
            {
                path.Add(parent);
                parent = parentMap[parent];
            }
            return path;
        }


        public struct RGSearchResult
        {
            public List<RGGrid.Point> Path { get; set; }
            public List<RGGrid.Point> Visited { get; set; }
        }

        // This is used to implement the best first search.
        class RGPriorityQueue<T>
        {
            private Dictionary<T, float> list;

            public bool Empty { get { return list.Count == 0; } }

            public RGPriorityQueue()
            {
                list = new Dictionary<T, float>();
            }
            public void Enqueue(T element, float priority)
            {
                list[element] = priority;
            }

            public T Dequeue()
            {
                if(list.Count == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                T bestKey = list.Keys.First();
                float priority = list[bestKey];

                foreach(T candidate in list.Keys)
                {
                    if(list[candidate] < priority)
                    {
                        bestKey = candidate;
                        priority = list[candidate];
                    }
                }

                list.Remove(bestKey);
                return bestKey;
            }
        }

        public static RGSearchResult BestFirstSearch(RGGrid grid, RGGrid.Point StartPosition, RGGrid.Point EndPosition)
        {
            RGPriorityQueue<RGGrid.Point> queue = new RGPriorityQueue<RGGrid.Point>();
            Dictionary<RGGrid.Point, float> distanceMap = new Dictionary<RGGrid.Point, float>();
            Dictionary<RGGrid.Point, RGGrid.Point> visitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            queue.Enqueue(StartPosition, 0);
            distanceMap.Add(StartPosition, 0);
            visitedMap.Add(StartPosition, null);

            while(!queue.Empty)
            {
                RGGrid.Point current = queue.Dequeue();
                if(current.Equals(EndPosition))
                {
                    return new RGSearchResult
                    {
                        Path = GeneratePath(visitedMap, current),
                        Visited = new List<RGGrid.Point>(visitedMap.Keys)
                    };
                }

                foreach(RGGrid.Point neighbor in grid.GetAdjacentCells(current))
                {
                    if(!visitedMap.ContainsKey(neighbor))
                    {
                        float priority = Heuristic(EndPosition, neighbor);
                        queue.Enqueue(neighbor, priority);
                        visitedMap.Add(neighbor, current);
                        distanceMap.Add(neighbor, distanceMap[current] + grid.GetCostOfEnteringCell(neighbor));
                    }
                }
            }
            return new RGSearchResult();
        }

        private static float Heuristic(RGGrid.Point endPosition, RGGrid.Point Point, bool useManhattan = true)
        {
            if(useManhattan)
            {
                return Manhattan(endPosition, Point);
            }
            else
            {
                return Euclidean(endPosition, Point);
            }
        }

        private static float Manhattan(RGGrid.Point FirstPoint, RGGrid.Point SecondPoint)
        {
            return Math.Abs(FirstPoint.X - SecondPoint.X) + Math.Abs(FirstPoint.Y - FirstPoint.Y);
        }

        private static float Euclidean(RGGrid.Point FirstPoint, RGGrid.Point SecondPoint)
        {
            return (float)Math.Sqrt(((FirstPoint.X - SecondPoint.X) * (FirstPoint.X - SecondPoint.X)) + ((FirstPoint.Y - SecondPoint.Y) * (FirstPoint.Y - SecondPoint.Y)));
        }

        public static RGSearchResult DijkstraWithPriorityQueue(RGGrid grid, RGGrid.Point StartPosition, RGGrid.Point EndPosition)
        {
            RGPriorityQueue<RGGrid.Point> queue = new RGPriorityQueue<RGGrid.Point>();
            Dictionary<RGGrid.Point, float> distanceMap = new Dictionary<RGGrid.Point, float>();
            Dictionary<RGGrid.Point, RGGrid.Point> visitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            queue.Enqueue(StartPosition, 0);

            distanceMap.Add(StartPosition, 0);
            visitedMap.Add(StartPosition, null);

            while(!queue.Empty)
            {
                RGGrid.Point current = queue.Dequeue();
                if(current.Equals(EndPosition))
                {
                    return new RGSearchResult
                    {
                        Path = GeneratePath(visitedMap, current),
                        Visited = new List<RGGrid.Point>(visitedMap.Keys)
                    };
                }

                foreach(RGGrid.Point adj in grid.GetAdjacentCells(current))
                {
                    float newDist = distanceMap[current] + grid.GetCostOfEnteringCell(adj);
                    if(!distanceMap.ContainsKey(adj) || newDist < distanceMap[adj])
                    {
                        distanceMap[adj] = newDist;
                        visitedMap[adj] = current;
                        queue.Enqueue(adj, newDist);
                    }
                }
            }

            return new RGSearchResult();
        }

        public static RGSearchResult AStar(RGGrid grid, RGGrid.Point StartPosition, RGGrid.Point EndPosition)
        {
            RGPriorityQueue<RGGrid.Point> queue = new RGPriorityQueue<RGGrid.Point>();
            Dictionary<RGGrid.Point, float> distanceMap = new Dictionary<RGGrid.Point, float>();
            Dictionary<RGGrid.Point, RGGrid.Point> visitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            queue.Enqueue(StartPosition, 0);
            distanceMap.Add(StartPosition, 0);
            visitedMap.Add(StartPosition, null);

            while (!queue.Empty)
            {
                RGGrid.Point current = queue.Dequeue();
                if (current.Equals(EndPosition))
                {
                    return new RGSearchResult
                    {
                        Path = GeneratePath(visitedMap, current),
                        Visited = new List<RGGrid.Point>(visitedMap.Keys)
                    };
                }

                foreach (RGGrid.Point neighbor in grid.GetAdjacentCells(current))
                {
                    float newCost = distanceMap[current] + grid.GetCostOfEnteringCell(neighbor);
                    if (!distanceMap.ContainsKey(neighbor) || newCost < distanceMap[neighbor])
                    {
                        distanceMap[neighbor] = newCost;

                        float priority = newCost + Heuristic(EndPosition, neighbor);
                        queue.Enqueue(neighbor, priority);

                        visitedMap[neighbor] = current;
                    }
                }
            }

            return new RGSearchResult();
        }

        public static RGSearchResult AStarBiDirectional(RGGrid grid, RGGrid.Point StartPosition, RGGrid.Point EndPosition)
        {
            Dictionary<RGGrid.Point, bool> openedBy = new Dictionary<RGGrid.Point, bool>();

            RGPriorityQueue<RGGrid.Point> startQueue = new RGPriorityQueue<RGGrid.Point>();
            RGPriorityQueue<RGGrid.Point> endQueue = new RGPriorityQueue<RGGrid.Point>();

            Dictionary<RGGrid.Point, float> startDistanceMap = new Dictionary<RGGrid.Point, float>();
            Dictionary<RGGrid.Point, RGGrid.Point> startVisitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();
            Dictionary<RGGrid.Point, float> endDistanceMap = new Dictionary<RGGrid.Point, float>();
            Dictionary<RGGrid.Point, RGGrid.Point> endVisitedMap = new Dictionary<RGGrid.Point, RGGrid.Point>();

            startQueue.Enqueue(StartPosition, 0);
            startDistanceMap[StartPosition] = 0;
            startVisitedMap[StartPosition] = null;
            openedBy[StartPosition] = true;

            endQueue.Enqueue(EndPosition, 0);
            endDistanceMap[EndPosition] = 0;
            endVisitedMap[EndPosition] = null;
            openedBy[EndPosition] = false;

            // Even if onequeue is empty, then it means there is no path
            while (!startQueue.Empty && !endQueue.Empty)
            {
                RGGrid.Point current = startQueue.Dequeue();
                if (openedBy.ContainsKey(current) && openedBy[current] == false)
                {
                    // If it enters here, it means the two lookups have met.
                    List<RGGrid.Point> startPath = GeneratePath(startVisitedMap, current);
                    List<RGGrid.Point> endPath = GeneratePath(endVisitedMap, current);

                    List<RGGrid.Point> allPath = new List<RGGrid.Point>(startPath);
                    allPath.AddRange(endPath);

                    List<RGGrid.Point> allVisited = new List<RGGrid.Point>(startVisitedMap.Keys);
                    allVisited.AddRange(endVisitedMap.Keys);

                    return new RGSearchResult
                    {
                        Path = allPath,
                        Visited = allVisited
                    };
                }
                foreach (RGGrid.Point neighbour in grid.GetAdjacentCells(current))
                {
                    float newCost = startDistanceMap[current] + grid.GetCostOfEnteringCell(neighbour);
                    if (!startDistanceMap.ContainsKey(neighbour) || newCost < startDistanceMap[neighbour])
                    {
                        startDistanceMap[neighbour] = newCost;
                        openedBy[neighbour] = true;

                        float priority = newCost + Heuristic(EndPosition, neighbour);
                        startQueue.Enqueue(neighbour, priority);

                        startVisitedMap[neighbour] = current;
                    }
                }
                // From end
                current = endQueue.Dequeue();
                if (openedBy.ContainsKey(current) && openedBy[current] == true)
                {
                    // Found goal or the frontier from the start queue
                    // Return solution
                    List<RGGrid.Point> startPath = GeneratePath(startVisitedMap, current);
                    List<RGGrid.Point> endPath = GeneratePath(endVisitedMap, current);

                    List<RGGrid.Point> allPath = new List<RGGrid.Point>(startPath);
                    allPath.AddRange(endPath);

                    List<RGGrid.Point> allVisited = new List<RGGrid.Point>(startVisitedMap.Keys);
                    allVisited.AddRange(endVisitedMap.Keys);

                    return new RGSearchResult
                    {
                        Path = allPath,
                        Visited = allVisited
                    };
                }
                foreach (RGGrid.Point neighbour in grid.GetAdjacentCells(current))
                {
                    float newCost = endDistanceMap[current] + grid.GetCostOfEnteringCell(neighbour);
                    if (!endDistanceMap.ContainsKey(neighbour) || newCost < endDistanceMap[neighbour])
                    {
                        endDistanceMap[neighbour] = newCost;
                        openedBy[neighbour] = false;

                        float priority = newCost + Heuristic(StartPosition, neighbour);
                        endQueue.Enqueue(neighbour, priority);

                        endVisitedMap[neighbour] = current;
                    }
                }
            }
            return new RGSearchResult();
        }

     }
}

