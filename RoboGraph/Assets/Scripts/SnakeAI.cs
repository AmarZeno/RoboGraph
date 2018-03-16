using RGGraphCore;
using System.Collections;
using System.Collections.Generic;

namespace RGGame
{
    public enum SnakeAIState { Random }

    public class SnakeAI
    {
        private RGGrid grid;
        private Stack<Point> pathList;
        private SnakeAIState AIState;

        public SnakeAI(RGGrid i_Grid)
        {
            grid = i_Grid;
        }

        public void SetAIState(SnakeAIState state)
        {
            AIState = state;
            pathList = null;
        }

        public Point GetNextMoveGoal(Point ghostPosition)
        {
            if(pathList == null || pathList.Count == 0)
            {
                GetNewPath(ghostPosition);
            }
            if(pathList != null && pathList.Count > 0)
            {
                return pathList.Pop();
            }

            return ghostPosition;
        }

        private void GetNewPath(Point ghostPosition)
        {
            List<Point> path = null;

            switch(AIState)
            {
                case SnakeAIState.Random:
                   // path = RGSearchAlgorithms.BestFirstSearch(grid, ghostPosition, grid.GetRandomOpenPoint()).Path;
                    break;
            }

            pathList = new Stack<Point>(path);
        }
    }
}


