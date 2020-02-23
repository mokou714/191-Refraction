using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZerOneType { ZERO, ONE};

public class ZerOne : MonoBehaviour
{

    public Transform catcher;
    public float moveSpeed;
    public ZerOneType zerOneType;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(catcher.transform.position, transform.position) < 0.03f)
        {
            transform.position = Vector3.Lerp(transform.position, catcher.transform.position, moveSpeed*3 * Time.deltaTime);
        }
        else
        {
            Vector3 dir = (catcher.position - transform.position).normalized;
            transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
        }
    }


}
