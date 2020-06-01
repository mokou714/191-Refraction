using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityScript.Scripting.Pipeline;
using System;
using Newtonsoft.Json;
using System.IO;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class SkillCatalouge : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<SkillCardEntry> skillCardList;
    private List<Transform> skillCardTransformList;
    private SkillCards _skillcards;

    private void Awake()
    {
        entryContainer = transform.Find("ButtonListContent");
        entryTemplate = entryContainer.Find("SkillCard");

        entryTemplate.gameObject.SetActive(false);

        /* initializing some skillcards for test
        skillCardList = new List<SkillCardEntry>()
           {
               new SkillCardEntry{ skillName = "SalesForce", cardID = "001", type = 1, description = "A Programming Language", 
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Handshake", cardID = "002", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Windows", cardID = "003", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Handshake", cardID = "004", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Microsoft Office", cardID = "005", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "PowerPoint", cardID = "006", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Excel", cardID = "007", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Slack", cardID = "008", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "QuickBooks", cardID = "008", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Twitter", cardID = "010", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Tableau", cardID = "011", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Grammarly", cardID = "012", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Dropbox", cardID = "013", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Trello", cardID = "014", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Xero", cardID = "015", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
               new SkillCardEntry{ skillName = "Instragram", cardID = "016", type = 1, description = "A Programming Language",
                   comment1 = "", comment2 = "", comment3 = ""},
         };*/

        var json = new StreamReader("./Users/skills.json");
        _skillcards = JsonConvert.DeserializeObject<SkillCards>(json.ReadToEnd());


        for (int i = 0; i < skillCardList.Count; i++)
        {
            for (int j = i + 1; j < skillCardList.Count; j++)
            {
                //if isFirst is -1 then it is First
                int isFirst = (string.Compare(skillCardList[j].skillName,
                    skillCardList[i].skillName, System.StringComparison.CurrentCulture));
                if (isFirst == -1)
                {
                    SkillCardEntry tmp = skillCardList[i];
                    skillCardList[i] = skillCardList[j];
                    skillCardList[j] = tmp;
                }
            }
        }

        skillCardTransformList = new List<Transform>();
        foreach (SkillCardEntry SkillCardEntry in skillCardList)
        {
            CreateListEntryTransform(SkillCardEntry, entryContainer, skillCardTransformList);
        }

        /*var path = "./Users/skills.json";
        var fileWriter = new StreamWriter(path);

        SkillCards skillcards = new SkillCards { skillCardList = skillCardList };
        var json = JsonConvert.SerializeObject(skillCardList);
        Debug.Log(json);
        fileWriter.WriteLine(json);
        fileWriter.Close();*/
  
    }

    private void CreateListEntryTransform(SkillCardEntry skillCardEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 72.806f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string skillName = skillCardEntry.skillName;
        string description = skillCardEntry.description;
        entryTransform.Find("Text").GetComponent<Text>().text = skillName;
        entryTransform.Find("Description").GetComponent<Text>().text = description;

        transformList.Add(entryTransform);
    }

    [System.Serializable]
    private class SkillCards
    {
        public List<SkillCardEntry> skillCardList;
    }

    [System.Serializable]
    private class SkillCardEntry
    {
        public string skillName;
        public string cardID;

        public string description;
        public int type; //1 - technology, 2 - interpersonal, 3 - specialty

        public string comment1;
        public string comment2;
        public string comment3;
  
    }
}
