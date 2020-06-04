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

    private string dateTimeString;

    public GameObject Page;
    private int pagetype;

    private void Awake()
    {
        System.DateTime dateTime = System.DateTime.Now;

        entryContainer = transform.Find("ButtonListContent");
        entryTemplate = entryContainer.Find("Button");

        entryTemplate.gameObject.SetActive(false);

        var json = new StreamReader("./Users/candidates.json");
        candidateList = JsonConvert.DeserializeObject<List<CandidateEntry>>(json.ReadToEnd());

        if (Page.name == "AtoZPage")
        {
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
        }
        if (Page.name == "TypeIntPage")
        {
            for (int i = 0; i < candidateList.Count; i++)
            {
                for (int j = i + 1; j < candidateList.Count; j++)
                {
                    //if isFirst is -1 then it is First
                    int isFirst = (string.Compare(candidateList[j].position,
                        candidateList[i].position, System.StringComparison.CurrentCulture));
                    if (isFirst == -1)
                    {
                        CandidateEntry tmp = candidateList[i];
                        candidateList[i] = candidateList[j];
                        candidateList[j] = tmp;
                    }
                }
            }
        }
        if ((Page.name == "ThisWeekIntPage") || (Page.name == "FutureIntPage") || (Page.name == "PastIntPage"))
        {
            for (int i = 0; i < candidateList.Count; i++)
            {
                for (int j = i + 1; j < candidateList.Count; j++)
                {
                    //if isFirst is -1 then it is First
                    int isFirst = (string.Compare(candidateList[j].date,
                        candidateList[i].date, System.StringComparison.CurrentCulture));
                    if (isFirst == -1)
                    {
                        CandidateEntry tmp = candidateList[i];
                        candidateList[i] = candidateList[j];
                        candidateList[j] = tmp;
                    }
                    else if (isFirst == 0)
                    {
                        int isFirstTime = (string.Compare(candidateList[j].time,
                            candidateList[i].time, System.StringComparison.CurrentCulture));
                        if (isFirstTime == -1)
                        {
                            CandidateEntry tmp = candidateList[i];
                            candidateList[i] = candidateList[j];
                            candidateList[j] = tmp;
                        }
                    }
                }
            }
        }





                candidateTransformList = new List<Transform>();

        if ((Page.name == "ThisWeekIntPage") || (Page.name == "FutureIntPage") || (Page.name == "PastIntPage"))
        {
            dateTime = System.DateTime.Now;
            dateTimeString = dateTime.ToString("MM/dd/yy");

            DateTime nextWeek = dateTime.AddDays(7);
            string nextWeekString = nextWeek.ToString("MM/dd/yy");

            if (Page.name == "ThisWeekIntPage")
            {
                for (int i = 0; i < candidateList.Count; i++)
                {
                    // if interview is scheduled for this week
                    if (candidateList[i].isScheduled == true)
                    {
                        if (
                            ((string.Compare(dateTimeString,
                            candidateList[i].date, System.StringComparison.CurrentCulture)) <= 0)
                            &&
                            ((string.Compare(candidateList[i].date, nextWeekString, System.StringComparison.CurrentCulture)) == -1)
                            )
                        {
                            CreateListEntryTransform(candidateList[i], entryContainer, candidateTransformList);
                        }
                    }
                }
            }

            if (Page.name == "FutureIntPage")
            {
                for (int i = 0; i < candidateList.Count; i++)
                {
                    // if interview is scheduled for any time after next week
                    if (candidateList[i].isScheduled == true)
                    {
                        if (
                            ((string.Compare(candidateList[i].date, nextWeekString, System.StringComparison.CurrentCulture)) >= 0)
                           )
                        {
                            CreateListEntryTransform(candidateList[i], entryContainer, candidateTransformList);
                        }
                    }
                }
            }


            if (Page.name == "PastIntPage")
            {
                for (int i = 0; i < candidateList.Count; i++)
                {
                    // if interview was scheduled in the past before this date
                    if (candidateList[i].isScheduled == true)
                    {
                        if (
                            ((string.Compare(candidateList[i].date, dateTimeString, System.StringComparison.CurrentCulture)) < 0)
                           )
                        {
                            CreateListEntryTransform(candidateList[i], entryContainer, candidateTransformList);
                        }
                    }
                }
            }
        }
        else
        {
            foreach (CandidateEntry candidateEntry in candidateList)
            {
                CreateListEntryTransform(candidateEntry, entryContainer, candidateTransformList);
            }
        }
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

        if (MI != "")
            entryTransform.Find("IntervieweeName").GetComponent<TextMeshProUGUI>().text = firstName + " " + MI +
                ". " + lastName + " <#999999>| " + position;
        else
            entryTransform.Find("IntervieweeName").GetComponent<TextMeshProUGUI>().text = firstName +
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
