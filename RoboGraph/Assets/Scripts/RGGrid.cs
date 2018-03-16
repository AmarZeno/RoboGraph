using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGGraphCore
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
            if (obj == null)
            {
                return false;
            }
            if (obj is Point)
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

    public class RGGrid
    {

        public enum CellType
        {
            Wall, Empty, Coin, Powerup, Start, GhostBegin
        }

        public enum MoveDirection
        {
            Up, Left, Down, Right
        }

        private CellType[,] grid;
        private int width;
        public int Width { get { return width; } }
        private int height;
        public int Height { get { return height; } }
        public Point GhostBeginPosition { get; private set; }
        private List<Point> openList = new List<Point>();

        public static bool IsCellPassable(CellType cellType)
        {
            return cellType != CellType.Wall;
        }

        public CellType this[int i, int j]
        {
            get
            {
                return grid[i, j];
            }
            set
            {
                if(IsCellPassable(value))
                {
                    openList.Add(new Point(i, j));
                }
                if(value == CellType.GhostBegin)
                {
                    GhostBeginPosition = new Point(i, j);
                }
                grid[i, j] = value;
            }
        }

        public static CellType ParseCellType(string s)
        {
            switch(s)
            {
                case "w":
                    return CellType.Wall;
                case "0":
                    return CellType.Empty;
                case "1":
                    return CellType.Coin;
                case "2":
                    return CellType.Powerup;
                case "s":
                    return CellType.Start;
                case "b":
                    return CellType.GhostBegin;
                default:
                    return CellType.Empty;
            }
        }

        public static RGGrid LoadPacmanLevel(string levelData)
        {
            int width = 28, height = 31; // hardcoded pacman level
            string[] lines = levelData.Split('\n');

            RGGrid grid = new RGGrid(width, height);

            for(int j = 0; j < lines.Length; j++)
            {
                string[] cells = lines[j].Trim().Split(' ');
                for(int i = 0; i < cells.Length; i++)
                {
                    string cell = cells[i];
                    grid[i, j] = ParseCellType(cells[i]);
                }
            }

            return grid;
        }

        public RGGrid(int i_width, int i_height)
        {
            width = i_width;
            height = i_height;
            grid = new CellType[width, height];
        }

        public Point GetRandomOpenPoint()
        {
            System.Random rand = new System.Random();
            return openList[rand.Next(0, openList.Count - 1)];
        }

        public float GetCostOfEnteringCell(Point cell)
        {
            return 1;
        }

        public List<Point> GetAdjacentCells(int x, int y)
        {
            List<Point> adjacentCells = new List<Point>();
            if(x > 0)
            {
                if(IsCellPassable(grid[x - 1, y]))
                {
                    adjacentCells.Add(new Point(x - 1, y));
                }
            }
            if(x < width - 1)
            {
                if (IsCellPassable(grid[x + 1, y]))
                {
                    adjacentCells.Add(new Point(x + 1, y));
                }
            }
            if(y > 0)
            {
                if (IsCellPassable(grid[x, y - 1]))
                {
                    adjacentCells.Add(new Point(x, y - 1));
                }
            }
            if(y < height - 1)
            {
                if (IsCellPassable(grid[x, y + 1]))
                {
                    adjacentCells.Add(new Point(x, y + 1));
                }
            }

            return adjacentCells;
        }

        public static RGGrid LoadPacManLevel(string levelData)
        {
            int width = 28, height = 31;
            string[] lines = levelData.Split('\n');
            RGGrid grid = new RGGrid(width, height);

            for(int j =0; j < lines.Length; j++)
            {
                string[] cells = lines[j].Trim().Split(' ');
                for(int i = 0; j < cells.Length; i++)
                {
                    string cell = cells[i];
                    grid[i, j] = ParseCellType(cells[i]);
                }
            }

            return grid;
        }

        public List<Point> GetAdjacentCells(Point cell)
        {
            return GetAdjacentCells((int)cell.X, (int)cell.Y);
        }
    }

}
