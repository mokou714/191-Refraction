



using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Connect4
{
    private class Tile
    {
        public Tile left;
        public Tile right;
        public Tile up;
        public Tile down;
        public Player state;
    }
    
    private int _colSize;
    private int _rowSize;
    private Tile[][] _board;
    private bool _gameOver;
    private Player _currentPlayer;
    
    //helper data
    private int _lastMovedRow;
    private int moveCount;

    public void Init(int rowSize, int colSize)
    {
        _board = new Tile[rowSize][];
        _rowSize = rowSize;
        _colSize = colSize;
        for (var i = 0; i < rowSize; ++i)
        {
            _board[i] = new Tile[colSize];
            for (var j = 0; j < colSize; ++j)
            {
                _board[i][j] = new Tile {state = Player.None};
                if (i > 0)
                {
                    _board[i][j].up = _board[i - 1][j];
                    _board[i - 1][j].down = _board[i][j];
                }
                if (j > 0)
                {
                    _board[i][j].left = _board[i][j - 1];
                    _board[i][j - 1].right = _board[i][j];
                }
            }
        }
        _currentPlayer = Player.P1;
        _gameOver = false;
    }

    public bool Move(int col)
    {
        if (_gameOver || BoardFull()) return false;
        
        for (var i = _rowSize-1; i >= 0; --i)
        {
            if (_board[i][col].state == Player.None)
            {
                _board[i][col].state = _currentPlayer;
                _lastMovedRow = i;
                if (CheckGameState(i, col))
                {
                    _gameOver = true;
                }
                else
                {
                    _currentPlayer = _currentPlayer == Player.P1 ? Player.P2 : Player.P1;
                }

                moveCount++;
                return true;
            }
        }
        return false;
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }

    public Player GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public int GetLastMovedRow()
    {
        return _lastMovedRow;
    }

    private bool CheckGameState(int row, int col)
    {
        //8-direction recursion
        //use 5 because the starting position is calculated twice
        return
            RecurCheck(row, col, 1, -1, 0) 
            + 
            RecurCheck(row, col, 1, 1, 0)
            >=5
            || 
            RecurCheck(row, col, 1, 0, -1) 
            + 
            RecurCheck(row, col, 1, 0, 1)
            >=5
            ||
            RecurCheck(row, col, 1, -1, -1)
            + 
            RecurCheck(row, col, 1, 1, 1)
            >=5
            || 
            RecurCheck(row, col, 1, -1, 1)
            +
            RecurCheck(row, col, 1, 1, -1)
            >=5;
    }

    public bool BoardFull()
    {
        return moveCount == _colSize * _rowSize;
    }

    private int RecurCheck(int row, int col, int count, int rowOffset, int colOffset)
    {
        //check boundary
        if (row + rowOffset < 0
            ||row + rowOffset >= _rowSize 
            ||col + colOffset < 0
            ||col + colOffset >= _colSize
            )
        {
            return count;
        }
        
        //check consecutive
        if (_board[row + rowOffset][col + colOffset].state != _currentPlayer)
            return count;
        
        //check if reaching 4 in a row
        if (count + 1 == 4)
            return count+1;
        
        //continue recursion
        return RecurCheck(row + rowOffset, col + colOffset, count + 1, rowOffset, colOffset);
    }
    
    
}
