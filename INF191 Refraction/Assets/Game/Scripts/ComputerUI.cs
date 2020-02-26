using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerUI : MonoBehaviour, IPointerClickHandler
{

    public GameObject UI;
    public Camera cam;

    private float camSize = 180;
    private float camYPos = -35f;
    private bool isDisplayingUI = false;

    //for reset
    private float _camSize;
    private float _camYPos;

    // Start is called before the first frame update
    void Start()
    {
        _camSize = cam.orthographicSize;
        _camYPos = cam.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    //input events
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isDisplayingUI)
        {
            cam.orthographicSize = camSize;
            cam.transform.position = new Vector3(cam.transform.position.x, camYPos, cam.transform.position.z);
            UI.gameObject.SetActive(true);
            isDisplayingUI = true;
        }
        
    }

    public void Back()
    {
        cam.orthographicSize = _camSize;
        cam.transform.position = new Vector3(cam.transform.position.x, _camYPos, cam.transform.position.z);
        UI.gameObject.SetActive(false);
        isDisplayingUI = false;
    }
}
