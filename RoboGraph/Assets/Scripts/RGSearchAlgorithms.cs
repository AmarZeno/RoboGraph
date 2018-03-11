using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RGGraphCore
{
    public class RGSearchAlgorithms
    {

        public static void BreadthFirstSearch<T>(RGGraph<T> graph, RGVertex<T> sourceVertex)
        {
            foreach(RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }

            Queue<RGVertex<T>> queue = new Queue<RGVertex<T>>();
            queue.Enqueue(sourceVertex);

            while(queue.Count > 0)
            {
                RGVertex<T> vertex = queue.Dequeue();
                foreach(RGVertex<T> neighbour in graph.GetAdjacentVertices(vertex))
                {
                    if(!neighbour.Visited)
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
            foreach(RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }

            Queue<RGVertex<T>> queue = new Queue<RGVertex<T>>();
            queue.Enqueue(sourceVertex);

            while(queue.Count > 0)
            {
                RGVertex<T> vertex = queue.Dequeue();

                foreach(RGVertex<T> neighbour in graph.GetAdjacentVertices(vertex))
                {
                    if(!neighbour.Visited)
                    {
                        neighbour.Parent = vertex;
                        neighbour.Distance = vertex.Distance + graph.GetEdgeWeight(vertex, neighbour);
                        neighbour.Visited = true;

                        if(neighbour.Equals(goalVertex))
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

            while(next != null)
            {
                path.Add(next);
                next = next.Parent;
            }

            return path;
        }




        // DFS BEGINS

        public static void DepthFirstSearch<T>(RGGraph<T> graph, RGVertex<T> sourceVertex, bool reverseNeighbours = false)
        {
            foreach(RGVertex<T> vertex in graph.Vertices)
            {
                vertex.Parent = null;
                vertex.Distance = 0;
                vertex.Visited = false;
            }


            Stack<RGVertex<T>> stack = new Stack<RGVertex<T>>();
            stack.Push(sourceVertex);

            while(stack.Count > 0)
            {
                RGVertex<T> vertex = stack.Pop();

                List<RGVertex<T>> neighbours = graph.GetAdjacentVertices(vertex);
                if(reverseNeighbours)
                {
                    neighbours.Reverse();
                }
                foreach(RGVertex<T> neighbour in neighbours)
                {
                    if(!neighbour.Visited)
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
            if(sourceVertex.Equals(goalVertex))
            {
                return new List<RGVertex<T>> { sourceVertex };
            }

            foreach(RGVertex<T> vertex in graph.Vertices)
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

                        if(neighbour.Equals(goalVertex))
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

    }
}

