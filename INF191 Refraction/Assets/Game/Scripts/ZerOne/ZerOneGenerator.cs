using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZerOneGenerator : MonoBehaviour
{
    [SerializeField] GameObject zeroPrefab;
    [SerializeField] GameObject onePrefab;
    public float frequency;
    public Transform catcher;
    public float minDistance;
    public float maxDistance;
    bool isGenerating = true;

    // Start is called before the first frame update
    void Start()
    {
        turnOn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        while (isGenerating)
        {
            int n = (int)Random.Range(0.0f, 2.0f);
            GameObject zerOne;
            zerOne = (n == 0) ? Instantiate(zeroPrefab) : Instantiate(onePrefab);
            float dx = Random.Range(-1.0f, 1.0f);
            float dy = Random.Range(-1.0f, 1.0f);
            Vector3 dir = new Vector3(dx, dy, 0).normalized;
            float dist = Random.Range(minDistance, maxDistance);
            zerOne.transform.position = catcher.position + dir * dist;
            zerOne.GetComponent<ZerOne>().catcher = catcher;
            yield return new WaitForSecondsRealtime(frequency);
        }

    }

    public void turnOn()
    {
        isGenerating = true;
        StartCoroutine(Generate());
    }

    public void turnOff()
    {
        isGenerating = false;
    }


}
