using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using RGGraphCore;

public class RGGridManager : MonoBehaviour {


    [SerializeField]
    private RGCell _CellPrefab;

    [SerializeField]
    public int _GridSize = 10;

    [SerializeField]
    private Text _PathText, _VisitedText;

    private RGGrid _grid;

    private RGCell _startCell, _endCell;

    private List<RGCell> _cells = new List<RGCell>();

    [SerializeField]
    private string _LevelPath = "level";

    void Start () {
        LoadLevel(_LevelPath);
    }

    private void LoadLevel(string level)
    {
        _LevelPath = level;
        _PathText.text = "";
        _VisitedText.text = "";
        // ReadGridFromFile(_LevelPath);
        GenerateRandomGrid();
        CreateGrid(_grid);
    }

    private void GenerateRandomGrid()
    {
        _GridSize = Random.Range(5, 9);
        _grid = new RGGrid(_GridSize, _GridSize);

        for (int i = 0; i < _GridSize; i++)
        {
            for (int j = 0; j < _GridSize; j++)
            {
                string cell = Random.Range(1, 9).ToString();
                int val = int.Parse(cell);
                print("i: " + i + ", j: " + j + " = " + cell);
                _grid[i, j] = int.Parse(cell);
            }
        }
    }

    private void ReadGridFromFile(string filename)
    {
        TextAsset levelData = Resources.Load(filename) as TextAsset;

        string[] lines = levelData.text.Split('\n');

        _GridSize = int.Parse(lines[0]);
        _grid = new RGGrid(_GridSize, _GridSize);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cells = lines[i].Split(' ');
            for (int j = 0; j < cells.Length; j++)
            {
                string cell = cells[j];
                int val = int.Parse(cell);
                print("i: " + i + ", j: " + j + " = " + cell);
                _grid[i - 1, j] = int.Parse(cells[j]);
            }
        }
    }

    private void CreateGrid(RGGrid grid)
    {
        float startX = -1 * grid.Width / 2 + 0.5f;
        float startY = -1 * grid.Height / 2 + 0.5f;
        for (int i = 0; i < grid.Width; i++)
        {
            for (int j = 0; j < grid.Height; j++)
            {
                RGCell cell = Instantiate(_CellPrefab) as RGCell;
                cell.transform.position = new Vector2(startX + i, startY + j);
                cell.Clicked += Cell_Clicked;
                cell.SetPosition(i, j);
                cell.SetState(RGCell.CellState.Normal, grid.GetCostOfEnteringCell(cell.GetPosition()));
                _cells.Add(cell);
            }
        }
    }

    public void Reset()
    {
        _startCell = null;
        _endCell = null;
        _PathText.text = "";
        for (int i = 0; i < _grid.Width; i++)
        {
            for (int j = 0; j < _grid.Height; j++)
            {
                RGGrid.Point pos = new RGGrid.Point(i, j);
                _cells.FirstOrDefault(c => c.GetPosition().Equals(pos)).SetState(RGCell.CellState.Normal, _grid.GetCostOfEnteringCell(pos));
            }
        }
    }

    public void BFS()
    {
        var path = RGSearchAlgorithms.BreadthFirstSearchInGrid(_grid, _startCell.GetPosition(), _endCell.GetPosition());

        StartCoroutine(ShowPath(path));
    }

    public void DFS()
    {
        var path = RGSearchAlgorithms.DepthFirstSearchInGrid(_grid, _startCell.GetPosition(), _endCell.GetPosition());

        StartCoroutine(ShowPath(path));
    }

    public void Dijkstra()
    {
        var path = RGSearchAlgorithms.DijkstraInGrid(_grid, _startCell.GetPosition(), _endCell.GetPosition());

        StartCoroutine(ShowPath(path));
    }

    public void DijkstraPriority()
    {
        ClearPath();
        var result = RGSearchAlgorithms.DijkstraWithPriorityQueue(_grid, _startCell.GetPosition(), _endCell.GetPosition());
        ShowVisited(result.Visited);
        StartCoroutine(ShowPath(result.Path));
    }

    public void AStar()
    {
        ClearPath();
        var result = RGSearchAlgorithms.AStar(_grid, _startCell.GetPosition(), _endCell.GetPosition());
        ShowVisited(result.Visited);
        StartCoroutine(ShowPath(result.Path));
    }

    public void BestFirst()
    {
        ClearPath();
        var result = RGSearchAlgorithms.BestFirstSearch(_grid, _startCell.GetPosition(), _endCell.GetPosition());
        ShowVisited(result.Visited);
        StartCoroutine(ShowPath(result.Path));
    }

    public void BiAStar()
    {
        ClearPath();
        var result = RGSearchAlgorithms.AStarBiDirectional(_grid, _startCell.GetPosition(), _endCell.GetPosition());
        ShowVisited(result.Visited);
        StartCoroutine(ShowPath(result.Path));
    }

    private void ShowVisited(List<RGGrid.Point> visited)
    {
        _VisitedText.text = "Visited: " + visited.Count;
        foreach (RGGrid.Point point in visited)
        {
            RGCell cell = _cells.FirstOrDefault(c => c.GetPosition().Equals(point));
            if (cell.State == RGCell.CellState.Normal)
            {
                cell.SetState(RGCell.CellState.Visited);
            }
        }
    }

    private IEnumerator ShowPath(List<RGGrid.Point> path)
    {
        print("Path");
        path.Reverse();

        float totalWeight = 0;

        for (int i = 1; i < path.Count - 1; i++)
        {
            RGGrid.Point step = path[i];
            RGCell cell = _cells.FirstOrDefault(c => c.GetPosition().Equals(step));

            if (cell.State == RGCell.CellState.End || cell.State == RGCell.CellState.Start)
            {
                continue;
            }

            cell.SetState(RGCell.CellState.Highlight);

            totalWeight += _grid.GetCostOfEnteringCell(step);
            _PathText.text = "Total weight: " + totalWeight;
            yield return new WaitForSeconds(0.1f);
        }

        _PathText.text = "Total weight: " + totalWeight;
    }

    private void Cell_Clicked(object sender, System.EventArgs e)
    {
        RGCell cell = sender as RGCell;
        if (_startCell == null)
        {
            _startCell = cell;
            cell.SetState(RGCell.CellState.Start);
            return;
        }
        if (_endCell == null)
        {
            _endCell = cell;
            cell.SetState(RGCell.CellState.End);
            return;
        }
    }

    public void ClearPath()
    {
        _PathText.text = "";
        _VisitedText.text = "";
        for (int i = 0; i < _grid.Width; i++)
        {
            for (int j = 0; j < _grid.Height; j++)
            {
                RGGrid.Point pos = new RGGrid.Point(i, j);
                RGCell cell = _cells.FirstOrDefault(c => c.GetPosition().Equals(pos));

                if (cell.State == RGCell.CellState.End || cell.State == RGCell.CellState.Start)
                {
                    continue;
                }
                cell.SetState(RGCell.CellState.Normal, _grid.GetCostOfEnteringCell(pos));
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
