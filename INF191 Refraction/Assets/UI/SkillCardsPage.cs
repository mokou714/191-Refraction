using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardsPage : MonoBehaviour
{
    [SerializeField] GameObject[] skillCards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display()
    {
        foreach(GameObject obj in skillCards)
        {
            obj.SetActive(true);
        }
    }

    public void Hide()
    {
        foreach (GameObject obj in skillCards)
        {
            obj.SetActive(false);
        }
    }
}
