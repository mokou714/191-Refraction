using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerUI : DeskInterfaceElement, IPointerClickHandler
{

    public GameObject UI;
    public GameObject Text;
    public Camera cam;

    [SerializeField] MainDeskInterface mainDeskInterface;
    [SerializeField] HeaderManager headerManager;

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
        if (mainDeskInterface.GetCurrentDeskElement() != null) return;
        
        cam.orthographicSize = camSize;
        cam.transform.position = new Vector3(cam.transform.position.x, camYPos, cam.transform.position.z);
        UI.gameObject.SetActive(true);
        isDisplayingUI = true;
        headerManager.OnComputer();
        Text.SetActive(false);
        mainDeskInterface.SetCurrentDeskElement(this);
        
        
    }

    public override void Back()
    {
        cam.orthographicSize = _camSize;
        cam.transform.position = new Vector3(cam.transform.position.x, _camYPos, cam.transform.position.z);
        UI.gameObject.SetActive(false);
        isDisplayingUI = false;
        Text.SetActive(true);
        headerManager.OnDesk();
    }
}
