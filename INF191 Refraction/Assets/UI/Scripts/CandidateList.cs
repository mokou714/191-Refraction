using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityScript.Scripting.Pipeline;
using System;
using Newtonsoft.Json;
using System.IO;

public class CandidateList : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<CandidateEntry> candidateList;
    private List<Transform> candidateTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("ButtonListContent");
        entryTemplate = entryContainer.Find("Button");

        entryTemplate.gameObject.SetActive(false);


        candidateList = new List<CandidateEntry>()
        {
            new CandidateEntry{ firstName = "Nevin", lastName = "Vo", MI = "Q", position = "Intern",
                isScheduled = true, date = "5/31/20", time = "3:30PM PST" },
            new CandidateEntry{ firstName = "Kevin", lastName = "Smith", MI = "Q", position = "Intern",
                isScheduled = true, date = "5/31/20", time = "3:30PM PST" },
            new CandidateEntry{ firstName = "Devin", lastName = "Apple", MI = "Q", position = "Intern",
                isScheduled = false, date = "5/31/20", time = "3:30PM PST" },
            new CandidateEntry{ firstName = "Sevin", lastName = "Za", MI = "Q", position = "Intern",
                isScheduled = true, date = "5/31/20", time = "3:30PM PST" },
        };

        //string jsonString = PlayerPrefs.GetString("canidateList");
        //Candidates candidates = JsonUtility.FromJson<Candidates>(jsonString);

        for (int i = 0; i < candidateList.Count; i++)
        {
            for (int j = i + 1; j < candidateList.Count; j++)
            {
                //if isFirst is -1 then it is First
                int isFirst = (string.Compare(candidateList[j].lastName,
                    candidateList[i].lastName, System.StringComparison.CurrentCulture));
                if (isFirst == -1)
                {
                    CandidateEntry tmp = candidateList[i];
                    candidateList[i] = candidateList[j];
                    candidateList[j] = tmp;
                }
            }
        }


        candidateTransformList = new List<Transform>();
        foreach (CandidateEntry candidateEntry in candidateList)
        {
            CreateListEntryTransform(candidateEntry, entryContainer, candidateTransformList);
        }

        Candidates candidates = new Candidates { candidateList = candidateList };
        string jsonString = JsonUtility.ToJson(candidates);

        Debug.Log("Saving...");
        if (Data.userData == null) return;
        var path = "./Users/" + Data.userData.accountId + "/candidates.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        var fileWriter = new StreamWriter(path);
        var json = JsonConvert.SerializeObject(candidates);
        Debug.Log(json);
        fileWriter.WriteLine(json);
        fileWriter.Close();

        /*PlayerPrefs.SetString("candidateList", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("candidateList"));
        */



        /*float templateHeight = 110f;
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("IntervieweeName").GetComponent<TextMeshProUGUI>().text = "Interviewee Name <#999999>| Position";
            entryTransform.Find("InterviewDate").GetComponent<TextMeshProUGUI>().text = "NOT PLANNED";
        }
        */
    }

    protected void OnApplicationQuit()
    {

    }
    

    private void CreateListEntryTransform(CandidateEntry candidateEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 110f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string firstName = candidateEntry.firstName;
        string MI = candidateEntry.MI;
        string lastName = candidateEntry.lastName;
        string position = candidateEntry.position;

        entryTransform.Find("IntervieweeName").GetComponent<TextMeshProUGUI>().text = firstName + " " + MI + 
            " " + lastName + " <#999999>| " + position;

        string date = candidateEntry.date;
        string time = candidateEntry.time;

        if (candidateEntry.isScheduled)
            entryTransform.Find("InterviewDate").GetComponent<TextMeshProUGUI>().text = date + ", " + time;
        else
            entryTransform.Find("InterviewDate").GetComponent<TextMeshProUGUI>().text = "NOT PLANNED";

        transformList.Add(entryTransform);
    }

    private class Candidates
    {
        public List<CandidateEntry> candidateList;
    }
    [System.Serializable]
    private class CandidateEntry
    {
        public string firstName;
        public string MI;
        public string lastName;
        public string position;

        public bool isScheduled;
        public string date;
        public string time;
    }
}
