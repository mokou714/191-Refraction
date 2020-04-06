using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCardsPage : MonoBehaviour
{
    [SerializeField] GameObject[] skillCards;
    public bool isInspecting;


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
