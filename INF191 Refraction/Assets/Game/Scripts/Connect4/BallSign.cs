using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSign : MonoBehaviour
{
    [SerializeField] private SpriteRenderer p1;
    [SerializeField] private SpriteRenderer p2;

    private void Start()
    {
        p1.enabled = p2.enabled = false;
    }

    public void SetSign(bool isP1, bool visible)
    {
        p1.enabled = isP1 && visible;
        p2.enabled = !isP1 && visible;
    }

    public void Reset()
    {
        p1.enabled = p2.enabled = false;
    }
}
