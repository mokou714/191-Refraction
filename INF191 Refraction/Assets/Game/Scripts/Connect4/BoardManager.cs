using System;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public int rowSize;
    public int colSize;
    public float tilePositionOffset;

    [SerializeField] private Tile[] tiles;
    [SerializeField] private BallSign[] ballSigns;
    [SerializeField] private Text winText;
    [SerializeField] private GameObject dialogueBox;
    
    private Connect4 _gameInstance;

    private void Start()
    {
        Init();
    }

    public void Move(int col)
    {
        var currentPlayer = _gameInstance.GetCurrentPlayer();

        if (_gameInstance.IsGameOver())
        {
            InvalidMove("Game is over.");
        }
        else if (_gameInstance.Move(col))
        {
            var row = _gameInstance.GetLastMovedRow();
            tiles[row*colSize + col].SetMove(currentPlayer == Player.P1);
            SetSign(col,true);
            if (_gameInstance.IsGameOver())
                OnGameEnded();
        }
        else
        {
            InvalidMove("Invalid move.");
        }
    }

    private void OnGameEnded()
    {
        var currentPlayer = _gameInstance.GetCurrentPlayer();
        dialogueBox.SetActive(true);
        winText.text = (currentPlayer == Player.P1 ? "Player 1" : "Player 2") + " won!";
    }
    
    
    private void InvalidMove(string msg)
    {
        Debug.Log(msg);
    }

    public void SetSign(int col, bool visible)
    {
        var currentPlayer = _gameInstance.GetCurrentPlayer();
        ballSigns[col].SetSign(currentPlayer == Player.P1, visible);
    }
    
    private void Init()
    {
        _gameInstance = new Connect4();
        _gameInstance.Init(rowSize,colSize);
        
        var startRowPosition = rowSize / 2f * tilePositionOffset - tilePositionOffset/2f + transform.position.y;
        var startColPosition = colSize / 2f * tilePositionOffset - tilePositionOffset/2f + transform.position.x;

        for (var i = 0; i < colSize; ++i)
        {
            ballSigns[i].gameObject.SetActive(true);
            ballSigns[i].transform.position = new Vector3(
                -startColPosition + i * tilePositionOffset,
                startRowPosition + tilePositionOffset,
                0
                );
        }

        for (var i = 0; i < tiles.Length; ++i)
        {
            var row = i / colSize;
            var col = i % colSize;
            
            tiles[i].gameObject.SetActive(true);
            tiles[i].transform.position = new Vector3(
                -startColPosition + col * tilePositionOffset,
                +startRowPosition - row * tilePositionOffset,
                0
            );

            tiles[i].col = col;
        }
    }

    public void Restart()
    {
        _gameInstance = new Connect4();
        _gameInstance.Init(rowSize,colSize);
        foreach(var tile in tiles)
        {
            tile.Reset();
        }
        foreach (var ballSign in ballSigns)
        {
           ballSign.Reset();
        }
        dialogueBox.SetActive(false);
    }
}
