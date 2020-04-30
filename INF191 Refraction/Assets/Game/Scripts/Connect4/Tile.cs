using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer p1;
    [SerializeField] private SpriteRenderer p2;
    [SerializeField] private BoardManager gameBoard;
    public int col;

    private void Start()
    {
        p1.enabled = p2.enabled = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("Try a move");
        gameBoard.Move(col);
    }

    public void OnMouseEnter()
    {
        gameBoard.SetSign(col,true);
    }

    public void OnMouseExit()
    {
        gameBoard.SetSign(col,false);
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
