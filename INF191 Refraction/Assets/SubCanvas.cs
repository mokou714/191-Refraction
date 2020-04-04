using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCanvas : MonoBehaviour
{
    private Transform currentChild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChild(Transform child)
    {
        child.parent = transform;
        currentChild = child;
    }

    public void RemoveChild()
    {
        currentChild = null;
    }
}
