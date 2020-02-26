using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZerOneStarter : MonoBehaviour
{

    [SerializeField] ZerOneGenerator generator;
    [SerializeField] Text countDown;
    int time = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator start()
    {
        while (time >= 0)
        {
            countDown.text = time.ToString();
            --time;
            yield return new WaitForSeconds(1);
        }

        countDown.gameObject.SetActive(false);
        generator.turnOn();

    }

}
