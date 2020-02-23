using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ZerOneCatcher catcher;
    void Start()
    {
        catcher = GetComponent<ZerOneCatcher>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        //0
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            catcher.Catch(0);
        }
        //1
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            catcher.Catch(1);
        }
    }
}
