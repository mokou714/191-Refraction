using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(width, height, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
