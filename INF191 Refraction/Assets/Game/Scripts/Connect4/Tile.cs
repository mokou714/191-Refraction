using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer p1;
    [SerializeField] private SpriteRenderer p2;
    [SerializeField] private BoardManager gameBoard;
    public int col;

    private bool _buttonDown;
    
    private void Start()
    {
        p1.enabled = p2.enabled = false;
    }
    
    public void OnMouseDown()
    {
        
        _buttonDown = true;
        
    }

    public void OnMouseEnter()
    {
        gameBoard.SetSign(col,true);
    }

    public void OnMouseUp()
    {
        if (_buttonDown)
        {
            Debug.Log("Try a move");
            gameBoard.Move(col);
        }

        _buttonDown = false;
    }

    public void OnMouseExit()
    {
        gameBoard.SetSign(col,false);
        _buttonDown = false;
    }

    public void SetMove(bool isP1)
    {
        Debug.Log(isP1?"P1 moved":"P2 moved");
        p1.enabled = isP1;
        p2.enabled = !isP1;
    }

    public void Reset()
    {
        p1.enabled = p2.enabled = false;
    }
}
