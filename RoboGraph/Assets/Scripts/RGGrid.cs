using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGGraphCore
{
    public class RGGrid
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override bool Equals(object obj)
            {
                if(obj == null)
                {
                    return false;
                }
                if(obj is Point)
                {
                    Point p = obj as Point;
                    return this.X == p.X && this.Y == p.Y;
                }
                return false;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 6949;
                    hash = hash * 7907 + X.GetHashCode();
                    hash = hash * 7907 + Y.GetHashCode();
                    return hash;
                }
            }
        }

        private int[,] grid;
        private int width;
        public int Width { get { return width; } }
        private int height;
        public int Height { get { return height; } }

        public int this[int i, int j]
        {
            get
            {
                return grid[i, j];
            }
            set
            {
                grid[i, j] = value;
            }
        }

        public RGGrid(int i_width, int i_height)
        {
            width = i_width;
            height = i_height;
            grid = new int[width, height];
        }

        public float GetCostOfEnteringCell(Point cell)
        {
            return grid[(int)cell.X, (int)cell.Y];
        }

        public List<Point> GetAdjacentCells(int x, int y)
        {
            List<Point> adjacentCells = new List<Point>();
            if(x > 0)
            {
                adjacentCells.Add(new Point(x - 1, y));
            }
            if(x < width - 1)
            {
                adjacentCells.Add(new Point(x + 1, y));
            }
            if(y > 0)
            {
                adjacentCells.Add(new Point(x, y - 1));
            }
            if(y < height - 1)
            {
                adjacentCells.Add(new Point(x, y + 1));
            }

            return adjacentCells;
        }

        public List<Point> GetAdjacentCells(Point cell)
        {
            return GetAdjacentCells((int)cell.X, (int)cell.Y);
        }
    }

}
