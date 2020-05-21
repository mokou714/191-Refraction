using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public int rowSize;
    public int colSize;
    public float tilePositionOffset;

    [SerializeField] private Tile[] tiles;
    [SerializeField] private BallSign[] ballSigns;
    [SerializeField] private Text winText;
    [SerializeField] private GameObject endWindow;
    [SerializeField] private GameObject questionWindow;
    [SerializeField] private Text questionText;

    private Connect4 _gameInstance;
    private QuestionManager _questionManager;

    private bool _isDisplayingQuestion;


    private void Start()
    {
        Init();
    }

    public void Move(int col)
    {
        if (_isDisplayingQuestion) return;

        var currentPlayer = _gameInstance.GetCurrentPlayer();

        if (_gameInstance.IsGameOver() || _gameInstance.BoardFull())
        {
            InvalidMove("Game is over.");
        }
        else
        {
            var result = _gameInstance.Move(col);
            //use 5 because the starting position is calculated twice
            //result == 2: single disc
            //result == 3: two discs in a row
            //result == 4: three disc in a row
            if (result != -1)
            {
                var row = _gameInstance.GetLastMovedRow();
                tiles[row * colSize + col].SetMove(currentPlayer == Player.P1);
                if (_gameInstance.IsGameOver() || _gameInstance.BoardFull())
                    OnGameEnded();
                else
                {
                    //clear all ball signs after making a move
                    for (var c = 0; c < ballSigns.Length; ++c)
                        SetSign(c, false);
                    GenerateQuestion(currentPlayer, result - 2);
                }
            }
            else
            {
                InvalidMove("Invalid move.");
            }
        }

    }

    private void GenerateQuestion(Player player, int tier)
    {
        questionText.text = _questionManager.GetOneQuestion(tier, player == Player.P1);
        questionWindow.SetActive(true);
        _isDisplayingQuestion = true;
        Debug.Log(questionText.text);
    }

    private void OnGameEnded()
    {
        //game has winner
        if (_gameInstance.IsGameOver())
        {
            var currentPlayer = _gameInstance.GetCurrentPlayer();
            endWindow.SetActive(true);
            winText.text = (currentPlayer == Player.P1 ? "CANDIDATE" : "COMPANY") + " WON!";
        }
        //draw
        else
        {
            endWindow.SetActive(true);
            winText.text = "A nice draw!";
        }
    }

    public void OnQuestionEnded()
    {
        _isDisplayingQuestion = false;
    }


    private void InvalidMove(string msg)
    {
        Debug.Log(msg);
    }

    public void SetSign(int col, bool visible)
    {
        if (_isDisplayingQuestion) return;
        var currentPlayer = _gameInstance.GetCurrentPlayer();
        ballSigns[col].SetSign(currentPlayer == Player.P1, visible);
    }

    private void Init()
    {
        _gameInstance = new Connect4();
        _gameInstance.Init(rowSize, colSize);
        _questionManager = new QuestionManager();

        var startRowPosition = rowSize / 2f * tilePositionOffset - tilePositionOffset / 2f + transform.position.y;
        var startColPosition = colSize / 2f * tilePositionOffset - tilePositionOffset / 2f + transform.position.x;

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
        _gameInstance.Init(rowSize, colSize);
        _questionManager.Reset();
        foreach (var tile in tiles)
        {
            tile.Reset();
        }
        foreach (var ballSign in ballSigns)
        {
            ballSign.Reset();
        }
        endWindow.SetActive(false);
    }
}