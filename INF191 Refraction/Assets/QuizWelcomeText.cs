using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizWelcomeText : MonoBehaviour
{
    void Start()
    {
        if(Data.userData != null)
            GetComponent<Text>().text = "Hi " + Data.userData.accountId + "!";
    }
}
