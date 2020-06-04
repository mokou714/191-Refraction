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
using TMPro;
#if UNITY_EDITOR
using UnityEditorInternal.Profiling.Memory.Experimental;
#endif

public class SkillCatalouge : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<SkillCardEntry> skillCardList;
    private List<Transform> skillCardTransformList;
    private SkillCards _skillcards;

    public GameObject Page;
    private int pagetype;

    private void Awake()

    {
        entryContainer = transform.Find("ButtonListContent");
        entryTemplate = entryContainer.Find("SkillCard");

        entryTemplate.gameObject.SetActive(false);

        var json = new StreamReader("./Users/skills.json");
        skillCardList = JsonConvert.DeserializeObject<List<SkillCardEntry>>(json.ReadToEnd());


        for (int i = 0; i < skillCardList.Count; i++)
        {
            for (int j = i + 1; j < skillCardList.Count; j++)
            {
                //if isFirst is -1 then it is First
                int isFirst = (string.Compare(skillCardList[j].cardID,
                    skillCardList[i].cardID, System.StringComparison.CurrentCulture));
                if (isFirst == -1)
                {
                    SkillCardEntry tmp = skillCardList[i];
                    skillCardList[i] = skillCardList[j];
                    skillCardList[j] = tmp;
                }
            }
        }

        if (Page.name == "Technology Page")
            pagetype = 1;
        if (Page.name == "Interpersonal Page")
            pagetype = 2;
        if (Page.name == "Specialty Page")
            pagetype = 3;


        skillCardTransformList = new List<Transform>();
        for (int i = 0; i < skillCardList.Count; i++)
        {
            if (skillCardList[i].type == pagetype)
            {
                CreateListEntryTransform(skillCardList[i], entryContainer, skillCardTransformList);
            }
        }
        
        /*skillCardTransformList = new List<Transform>();
        foreach (SkillCardEntry SkillCardEntry in skillCardList)
        {
            CreateListEntryTransform(SkillCardEntry, entryContainer, skillCardTransformList);
        }

        /*var path = "./Users/skills.json";
        var fileWriter = new StreamWriter(path);

        SkillCards skillcards = new SkillCards { skillCardList = skillCardList };
        var jsonnew = JsonConvert.SerializeObject(skillCardList);
        Debug.Log(jsonnew);
        fileWriter.WriteLine(jsonnew);
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
        string cardID = skillCardEntry.cardID;
        entryTransform.Find("Text").GetComponent<Text>().text = skillName;
        entryTransform.Find("Description").GetComponent<Text>().text = description;
        entryTransform.Find("CardID").GetComponent<Text>().text = cardID;

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
